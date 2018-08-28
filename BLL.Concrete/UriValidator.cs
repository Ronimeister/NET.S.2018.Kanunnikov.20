using System.Text.RegularExpressions;
using BLL.Interface;

namespace BLL.Concrete
{
    public class UriValidator : IValidator<string>
    {
        private const string URI_PATTERN = @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

        public bool IsValid(string value) => Regex.IsMatch(value, URI_PATTERN, RegexOptions.IgnoreCase);
    }
}
