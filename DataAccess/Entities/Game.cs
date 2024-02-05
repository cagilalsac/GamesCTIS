#nullable disable

using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Game : Record
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public DateTime? PublishDate { get; set; } // not required
        public decimal? TotalSalesPrice { get; set; } // double, float, not required
    }
}
