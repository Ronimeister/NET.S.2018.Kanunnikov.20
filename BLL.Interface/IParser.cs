namespace BLL.Interface
{
    /// <summary>
    /// Interface for all data parsers
    /// </summary>
    /// <typeparam name="TResult">Output type result</typeparam>
    /// <typeparam name="TSource">Inout type result</typeparam>
    public interface IParser<out TResult, in TSource>
    {
        /// <summary>
        /// Parse <param name="data"/>
        /// </summary>
        /// <param name="data">Parsing value</param>
        /// <returns>Parsed value</returns>
        TResult Parse(TSource data);
    }
}
