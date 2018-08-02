using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Web;

namespace Serializer
{
    public class UriSerializer : ISerializer<Uri>
    {
        private readonly string _fileName;

        public UriSerializer(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException($"{nameof(fileName)} can't be equal to null or empty!");
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException($"There is no such file : {fileName}");
            }

            _fileName = fileName;
        }

        public void Serialize(IEnumerable<Uri> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException($"{nameof(collection)} can't be equal to null!");
            }
            
            SerializeInner(collection);
        }

        private void SerializeInner(IEnumerable<Uri> collection)
        {
            XDocument xDocument = new XDocument();
            XElement root = new XElement("urlAdresses");

            foreach (Uri u in collection)
            {
                XElement element = new XElement("urlAdress");
                AddXMLHost(element, u);
                AddXMLUri(element, u);
                AddXMLParams(element, u);
                root.Add(element);
            }

            xDocument.Add(root);
            xDocument.Save(_fileName);
        }

        private void AddXMLHost(XElement root, Uri uri)
        {
            XElement element = new XElement("host");
            XAttribute attribute = new XAttribute("name", uri.Host);
            element.Add(attribute);
            root.Add(element);
        }

        private void AddXMLUri(XElement root, Uri uri)
        {
            XElement element = new XElement("uri");
            foreach (var item in uri.Segments.Where(x => x != "/"))
            {
                element.Add(new XElement("segment", item.Where(x => x != '/')));
            }

            root.Add(element);
        }

        private void AddXMLParams(XElement root, Uri uri)
        {
            XElement element = new XElement("parameters");
            //HttpUtility not found
        }
    }
}
