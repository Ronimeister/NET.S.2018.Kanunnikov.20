using System;
using System.Collections.Generic;
using BLL.Interface;

namespace BLL.Concrete
{
    /// <summary>
    /// Class that parse some data for uri
    /// </summary>
    public class UriParser : IParser<Uri, string>
    {
        #region Readonly fields
        private readonly IEnumerable<IValidator<string>> _validators;
        #endregion

        #region .ctors
        /// <summary>
        /// .ctor for <see cref="UriParser"/> class
        /// </summary>
        /// <param name="validator">Needed validator</param>
        /// <exception cref="ArgumentNullException">Throws when <param name="validator"></param> is equal to null</exception>
        public UriParser(IValidator<string> validator)
        {
            if (validator == null)
            {
                throw new ArgumentNullException($"{nameof(validator)} can't be equal to null!");
            }

            _validators = new List<IValidator<string>> { validator };
        }

        /// <summary>
        /// .ctor for <see cref="UriParser"/> class
        /// </summary>
        /// <param name="validators">Some amount of needed validators</param>
        /// <exception cref="ArgumentNullException">Throws when <param name="validators"></param> is equal to null</exception>
        public UriParser(IEnumerable<IValidator<string>> validators)
        {
            _validators = validators ?? throw new ArgumentNullException($"{nameof(validators)} can't be equal to null!");
        }
        #endregion

        #region Public API
        /// <summary>
        /// Parse <param name="data"/>
        /// </summary>
        /// <param name="data">Parsing value</param>
        /// <exception cref="UriFormatException">Throws when <param name="data"></param> isn't in correct URI form</exception>
        /// <returns>Parsed value</returns>
        public Uri Parse(string data)
        {
            foreach (var val in _validators)
            {
                if (!val.IsValid(data))
                {
                    throw new UriFormatException($"{nameof(data)} is not valid Uri!");
                }
            }

            return new Uri(data);
        }
        #endregion
    }
}
