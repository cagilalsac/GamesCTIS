namespace DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        //public Statuses Status { get; set; } // junior, senior, master
    }
}
