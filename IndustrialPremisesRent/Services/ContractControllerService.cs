using IndustrialPremisesRent.Data;
using IndustrialPremisesRent.Interfaces;
using IndustrialPremisesRent.Models;
using Microsoft.EntityFrameworkCore;

namespace IndustrialPremisesRent.Services
{
    public class ContractControllerService : IContractControllerService
    {
        IndustrialPremisesRentContext _context;

        public ContractControllerService(IndustrialPremisesRentContext context) 
        { 
            _context = context;
        }

        public async Task<bool> CreateContract(int premiseCode, int equipmentTypeCode, int equipmentAmount)
        {
            try
            {
                var industrialPremise = _context.IndustrialPremises.Where(p => p.Code == premiseCode).FirstOrDefault();
                var equipmentType = _context.EquipmentTypes.Where(p => p.Code == equipmentTypeCode).FirstOrDefault();
                Contract contract = new Contract();

                if (industrialPremise != null && equipmentType != null && industrialPremise.AvailableSquare > equipmentType.RequiredSquare * equipmentAmount)
                {
                    contract = new Contract { IndustrialPremise = industrialPremise, EquipmentType = equipmentType, EquipmentAmount = equipmentAmount };
                }
                else
                {
                    return false;
                }

                _context.Contracts.Add(contract);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Contract> GetContract(int id)
        {
            return await _context.Contracts
                .Where(c => c.Id == id)
                .Include(c => c.IndustrialPremise)
                .Include(c => c.EquipmentType)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contract>> GetContracts()
        {
            return await _context.Contracts
                    .Include(c => c.EquipmentType)
                    .Include(c => c.IndustrialPremise)
                    .ToListAsync();
        }
    }
}
