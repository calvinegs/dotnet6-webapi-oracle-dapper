using System.Data;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using OracleDapperRepository.Models;
using OracleDapperRepository.Repositories.Interfaces;

namespace OracleDapperRepository.Repositories
{
    public class SysmstafRepository : ISysmstafRepository
    {
        private readonly string _connectionString;

        public SysmstafRepository(string connectionStr)
        {
            _connectionString = connectionStr;
        }

        public IDbConnection Connection
        {
            get
            {
                return new OracleConnection(_connectionString);
            }
        }

        public async Task<sysmstaf> GetByLoginID(string loginID)
        {
            using (IDbConnection conn = Connection)
            {
                string sSQL = "select * from sysmstaf where login_tx= :LOGIN_ID";
                return await conn.QueryFirstOrDefaultAsync<sysmstaf>(sSQL, new { LOGIN_ID = loginID });
            }
        }

        public async Task<sysmstaf> GetByStaffID(string staffId)
        {
            using (IDbConnection conn = Connection)
            {
                string sSQL = "select * from sysmstaf where staff_id= :STAFF_ID";
                return await conn.QueryFirstOrDefaultAsync<sysmstaf>(sSQL, new { STAFF_ID = staffId });
            }
        }

        public async Task<List<sysmstaf>> GetDatas()
        {
            using (IDbConnection conn = Connection)
            {
                string sSql = "select * from sysmstaf Order by login_tx";
                var result = await conn.QueryAsync<sysmstaf>(sSql);
                return result.ToList();
            }
        }

        public async Task<IEnumerable<sysmstaf>> GetAllData()
        {
            using (IDbConnection conn = Connection)
            {
                string sSql = "select * from sysmstaf Order by login_tx";
                var result = await conn.QueryAsync<sysmstaf>(sSql);
                return result.ToList();
            }
        }
    }
}