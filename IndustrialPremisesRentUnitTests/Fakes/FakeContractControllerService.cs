using IndustrialPremisesRent.Interfaces;
using IndustrialPremisesRent.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace IndustrialPremisesRentUnitTests.Fakes
{
    public class FakeContractControllerService : IContractControllerService
    {
        List<Contract> contracts = new List<Contract>
            {
                new Contract()
                {
                    IndustrialPremise = new IndustrialPremise() { Code = 1, Name = "First Premise", AvailableSquare = 12 },
                    EquipmentType = new EquipmentType() { Code = 1, Name = "First equipment", RequiredSquare = 3 },
                    EquipmentAmount = 3
                },
                new Contract()
                {
                    IndustrialPremise = new IndustrialPremise() { Code = 2, Name = "Second Premise", AvailableSquare = 22 },
                    EquipmentType = new EquipmentType() { Code = 2, Name = "Second equipment", RequiredSquare = 2 },
                    EquipmentAmount = 5
                }
            };
        public Task<bool> CreateContract(int premiseCode, int equipmentTypeCode, int equipmentAmount)
        {
            var industrialPremise = contracts.Find(c => c.IndustrialPremise.Code == premiseCode);
            var equipmentType = contracts.Find(i => i.EquipmentType.Code == equipmentTypeCode);

            if (industrialPremise == null || equipmentType == null || industrialPremise.IndustrialPremise.AvailableSquare < equipmentAmount * equipmentType.EquipmentType.RequiredSquare)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(premiseCode > 0 && equipmentTypeCode > 0 && equipmentAmount > 0);
        }

        public async Task<Contract> GetContract(int id)
        {
            if (id != 0) return contracts.ElementAt(0);

            return new Contract();
        }

        public async Task<IEnumerable<Contract>> GetContracts()
        {
            return contracts;
        }
    }
}
