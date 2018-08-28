using System;
using System.Collections.Generic;
using BLL.Interface;

namespace BLL.Concrete
{
    public class UriParser : IParser<Uri, string>
    {
        private readonly IEnumerable<IValidator<string>> _validators;

        public UriParser(IEnumerable<IValidator<string>> validators)
        {
            _validators = validators ?? throw new ArgumentNullException($"{nameof(validators)} can't be equal to null!");
        }

        public UriParser(IValidator<string> validator)
        {
            if (validator == null)
            {
                throw new ArgumentNullException($"{nameof(validator)} can't be equal to null!");
            }

            _validators = new List<IValidator<string>> {validator};
        }

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
    }
}
