using Microsoft.EntityFrameworkCore;

namespace CommerceHelperDB.Models;

public class CommerceHelperContext: DbContext
{
	public string DbPath { get; }
	public CommerceHelperContext()
	{
		var folder = Environment.SpecialFolder.LocalApplicationData;
		var path = "/home/salvatore/RiderProjects/CommerceHelper/CommerceHelperDB/";
		DbPath = System.IO.Path.Join(path, "CommerceHelper.sqlite");
		if (!File.Exists(DbPath))
		{
			File.Create(DbPath);
		}
	}

	// The following configures EF to create a Sqlite database file in the
	// special "local" folder for your platform.
	protected override void OnConfiguring(DbContextOptionsBuilder options)
		=> options.UseSqlite($"Data Source={DbPath}");
	public DbSet<Item> Items { get; set; }
	public DbSet<Price> Prices { get; set; }
}