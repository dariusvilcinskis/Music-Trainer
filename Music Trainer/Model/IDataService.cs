using System.Threading.Tasks;

namespace Music_Trainer.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}