using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TripsAPI.Models
{
    public class TaxiZone
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int TaxiZoneId { get; set; }
        public string Borough { get; set; }
        public string Zone { get; set; }
        
    }
}