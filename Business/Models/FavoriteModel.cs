#nullable disable

using System.ComponentModel;

namespace Business.Models
{
    public class FavoriteModel
    {
        public int GameId { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Game Name")]
        public string GameName { get; set; }

        public decimal? TotalSalesPrice { get; set; }

        [DisplayName("Total Sales Price")]
        public string TotalSalesPriceOutput { get; set; }
    }
}
