using IndustrialPremisesRent.Models;

namespace IndustrialPremisesRent.Interfaces
{
    public interface IContractControllerService
    {
        Task<IEnumerable<Contract>> GetContracts();

        Task<Contract> GetContract(int id);

        Task<bool> CreateContract(int premiseCode, int equipmentTypeCode, int equipmentAmount);
    }
}
