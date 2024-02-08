#nullable disable

using DataAccess.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Publisher : Record
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public List<Game> Games { get; set; }
    }
}
