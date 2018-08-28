using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BLL.Interface;

namespace BLL.Concrete
{
    public class XMLStorage : IStorage<Uri>
    {
        private readonly string _storageName;

        public XMLStorage(string storageName)
        {
            if (string.IsNullOrEmpty(storageName))
            {
                throw new ArgumentException($"{nameof(storageName)} can't be equal to null or empty!");
            }

            if (!File.Exists(storageName))
            {
                throw new FileNotFoundException($"There is no such file : {storageName}");
            }

            _storageName = storageName;
        }

        public void Save(IEnumerable<Uri> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException($"{nameof(values)} can't be equal to null!");
            }

            SaveInner(values);
        }

        private void SaveInner(IEnumerable<Uri> values)
        {
            XDocument xDocument = new XDocument();
            XElement root = new XElement("urlAdresses");

            foreach (Uri u in values)
            {
                XElement element = new XElement("urlAdress");
                AddXMLHost(element, u);
                AddXMLUri(element, u);
                AddXMLParams(element, u);
                root.Add(element);
            }

            xDocument.Add(root);
            xDocument.Save(_storageName);
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
            string queryString = uri.Query;
            var queryDictionary = System.Web.HttpUtility.ParseQueryString(queryString);

            if (queryDictionary.HasKeys())
            {
                var keys = queryDictionary.AllKeys;

                XElement element = new XElement("parameters");
                for (int i = 0; i < queryDictionary.Count; i++)
                {
                    XElement param = new XElement("parametr");
                    XAttribute valueAttr = new XAttribute("value", queryDictionary[i]);
                    param.Add(valueAttr);

                    XAttribute keyAttr = new XAttribute("key", keys[i]);
                    param.Add(keyAttr);

                    element.Add(param);
                }

                root.Add(element);
            }
        }
    }
}
