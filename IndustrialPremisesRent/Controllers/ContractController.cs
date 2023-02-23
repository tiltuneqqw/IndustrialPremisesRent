using IndustrialPremisesRent.Interfaces;
using IndustrialPremisesRent.Models;
using Microsoft.AspNetCore.Mvc;

namespace IndustrialPremisesRent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContractController : ControllerBase
    {
        private readonly IContractControllerService _service;

        public ContractController(IContractControllerService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetContractsList")]
        public async Task<IEnumerable<Contract>> Get()
        {
            return await _service.GetContracts();
        }

        [HttpGet("{Id}", Name = "GetContractById")]
        public async Task<ActionResult<Contract>> Get(int Id)
        {
            var contract = await _service.GetContract(Id);

            return contract == null ? NotFound() : contract;
        }

        [HttpPost(Name = "CreateContract")]
        public async Task<ActionResult> Add(int premiseCode, int equipmentTypeCode, int equipmentAmount)
        {
            return await _service.CreateContract(premiseCode, equipmentTypeCode, equipmentAmount) ? Ok() : NotFound();
        }
    }
}