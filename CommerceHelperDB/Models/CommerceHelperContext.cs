using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Data.SQLite;

namespace CommerceHelperDB.Models;

public class CommerceHelperContext: DbContext
{
	public string DbPath { get; }
	public CommerceHelperContext()
	{
		string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
		string filename = "CommerceHelper.sqlite";
		DbPath = System.IO.Path.Join(folder, filename);
		if (!File.Exists(DbPath))
		{
			SQLiteConnection.CreateFile(DbPath);
		}
	}

	// The following configures EF to create a Sqlite database file in the
	// special "local" folder for your platform.
	protected override void OnConfiguring(DbContextOptionsBuilder options)
		=> options.UseSqlite($"Data Source={DbPath}");
	public DbSet<Item> Item { get; set; }
	public DbSet<Price> Price { get; set; }
	public DbSet<SuperCategory> SuperCategory { get; set; }
	public DbSet<Category> Category { get; set; }
}