using Contact.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contact.API
{
    public class ContactAPIContext : DbContext
    {
        public ContactAPIContext(DbContextOptions<ContactAPIContext> options) : base(options){}
        public DbSet<Person> People { get; set;}

    }
}
