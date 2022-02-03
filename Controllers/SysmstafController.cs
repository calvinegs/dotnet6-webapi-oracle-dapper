// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using OracleDapperRepository.Models;
using OracleDapperRepository.Repositories.Interfaces;

namespace OracleDapperRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysmstafController : ControllerBase
    {
        private readonly ISysmstafRepository _sysmstafRepo;

        public SysmstafController(ISysmstafRepository sysmstafRepo)
        {
            _sysmstafRepo = sysmstafRepo;
        }

        [HttpGet]
        [Route("StaffId/{staffId}")]
        public async Task<ActionResult<sysmstaf>> GetByStaffID(string staffId)
        {
            return await _sysmstafRepo.GetByStaffID(staffId);
        }

        [HttpGet]
        [Route("LoginId/{loginId}")]
        public async Task<ActionResult<sysmstaf>> GetByLoginID(string loginId)
        {
            return await _sysmstafRepo.GetByLoginID(loginId);
        }

        [HttpGet]
        [Route("GetDatas")]
        public async Task<ActionResult<List<sysmstaf>>> GetDatas()
        {
            return await _sysmstafRepo.GetDatas();
        }

        [HttpGet]
        [Route("GetAllData")]
        public async Task<IEnumerable<sysmstaf>> GetAllData()
        {
            return await _sysmstafRepo.GetAllData(); ;
            // var _sysmstaf = await _sysmstafRepo.GetAllData();
            // return Newtonsoft.Json.JsonConvert.SerializeObject(_sysmstaf);
        }
    }
}