namespace BLL.Interface
{
    /// <summary>
    /// Interface for all validator types
    /// </summary>
    /// <typeparam name="TSource">Source type</typeparam>
    public interface IValidator <in TSource>
    {
        /// <summary>
        /// Check if <param name="value"></param> is valid to some rules
        /// </summary>
        /// <param name="value">Checked value</param>
        /// <returns>Result of checking</returns>
        bool IsValid(TSource value);
    }
}
