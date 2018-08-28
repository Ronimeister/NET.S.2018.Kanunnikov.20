using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BLL.Interface;

namespace BLL.Concrete
{
    /// <summary>
    /// Class that implements xml storage functionality
    /// </summary>
    public class XMLStorage : IStorage<Uri>
    {
        #region Readonly fields
        private readonly string _storageName;
        #endregion

        #region .ctors
        /// <summary>
        /// .ctor for <see cref="XMLStorage"/> class
        /// </summary>
        /// <param name="storageName">Storage name</param>
        /// <exception cref="ArgumentException">Throws when <param name="storageName"></param> is equal to null or empty</exception>
        /// <exception cref="FileNotFoundException">Throws when there is no such file with <param name="storageName"></param></exception>
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
        #endregion

        #region Public API
        /// <summary>
        /// Save changes in storage
        /// </summary>
        /// <param name="values">Changed elements</param>
        /// <exception cref="ArgumentNullException">Throws when <param name="values"></param> is equal to null</exception>
        public void Save(IEnumerable<Uri> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException($"{nameof(values)} can't be equal to null!");
            }

            SaveInner(values);
        }
        #endregion

        #region Private methods
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
        #endregion
    }
}
