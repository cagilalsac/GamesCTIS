#nullable disable

using DataAccess.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
	public class GameModel : Record
	{
		#region Entity Properties
		[Required(ErrorMessage = "{0} is required!")]
		// Way 1:
		//[StringLength(100, MinimumLength = 2, ErrorMessage = "{0} must be minimum {2} maximum {1} characters!")]
		// Way 2:
		[MinLength(2, ErrorMessage = "{0} must be minimum {1} characters!")]
		[MaxLength(100, ErrorMessage = "{0} must be maximum {1} characters!")]
		[DisplayName("Game Name")]
		public string Name { get; set; }

		[DisplayName("Publish Date")]
		public DateTime? PublishDate { get; set; }

		[DisplayName("Price")]
		[Range(0, double.MaxValue, ErrorMessage = "{0} must be positive!")]
		public decimal? TotalSalesPrice { get; set; }

		[DisplayName("Publisher")]
		public int? PublisherId { get; set; }
		#endregion
	}
}
