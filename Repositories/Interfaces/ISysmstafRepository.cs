using OracleDapperRepository.Models;

namespace OracleDapperRepository.Repositories.Interfaces
{
    public interface ISysmstafRepository
    {
        Task<sysmstaf> GetByStaffID(string staffId);
        Task<sysmstaf> GetByLoginID(string loginID);
        Task<List<sysmstaf>> GetDatas();
        Task<IEnumerable<sysmstaf>> GetAllData();
    }
}