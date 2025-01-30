using Microsoft.EntityFrameworkCore;

namespace CommerceHelperDB.Models;

public class CommerceHelperContext: DbContext
{
	public DbSet<Items> Items { get; set; }
	public DbSet<Prices> Prices { get; set; }
}