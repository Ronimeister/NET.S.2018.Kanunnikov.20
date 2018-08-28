using System.Text.RegularExpressions;
using BLL.Interface;

namespace BLL.Concrete
{
    /// <summary>
    /// Class that implements validation for uri's
    /// </summary>
    public class UriValidator : IValidator<string>
    {
        #region Constants
        private const string URI_PATTERN = @"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
        #endregion

        #region Public API
        /// <summary>
        /// Check if <param name="value"></param> is valid to some rules
        /// </summary>
        /// <param name="value">Checked value</param>
        /// <returns>Result of checking</returns>
        public bool IsValid(string value) => Regex.IsMatch(value, URI_PATTERN, RegexOptions.IgnoreCase);
        #endregion
    }
}
