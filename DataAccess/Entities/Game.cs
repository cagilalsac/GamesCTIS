namespace DataAccess.Entities
{
    public class Game
    {
        //private int _id; // field

        //public void SetId(int id) // behaviors, setter
        //{
        //    _id = id;
        //}

        //public int GetId() // behaviors, getter
        //{
        //    return _id;
        //}

        public int Id { get; set; } // property
        public string Guid { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public decimal TotalSalesPrice { get; set; } // double, float
    }
}
