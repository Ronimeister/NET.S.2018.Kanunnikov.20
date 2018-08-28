namespace BLL.Interface
{
    /// <summary>
    /// Interface for all data services
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Transfer data of one storage to another with some changes
        /// </summary>
        void Transfer();
    }
}
