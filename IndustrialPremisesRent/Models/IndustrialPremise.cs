using System.ComponentModel.DataAnnotations;

namespace IndustrialPremisesRent.Models
{
    public class IndustrialPremise
    {
        [Key]
        public int Code { get; set; }

        public string Name { get; set; }

        public int AvailableSquare { get; set; }
    }
}
