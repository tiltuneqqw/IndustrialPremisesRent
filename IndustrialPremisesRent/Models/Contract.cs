using System.ComponentModel.DataAnnotations;

namespace IndustrialPremisesRent.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public IndustrialPremise IndustrialPremise { get; set; }

        public EquipmentType EquipmentType { get; set; }

        public int EquipmentAmount { get; set; }
    }
}
