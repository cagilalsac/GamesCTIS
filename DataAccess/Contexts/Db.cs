namespace DataAccess.Contexts
{
    public class Db : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
    }
}
