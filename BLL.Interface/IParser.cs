namespace BLL.Interface
{
    public interface IParser<out TResult, in TSource>
    {
        TResult Parse(TSource data);
    }
}
