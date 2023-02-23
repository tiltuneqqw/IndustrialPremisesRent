using System.ComponentModel.DataAnnotations;

namespace IndustrialPremisesRent.Models
{
    public class EquipmentType
    {
        [Key]
        public int Code { get; set; }

        public string Name { get; set; }

        public int RequiredSquare { get; set; }
    }
}
