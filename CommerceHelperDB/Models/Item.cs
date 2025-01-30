using System.ComponentModel.DataAnnotations;
using CommerceHelperDB.Migrations;
using Microsoft.EntityFrameworkCore;

namespace CommerceHelperDB.Models;

[Index("InGameID", IsUnique = true)]
public class Item
{
	public int ItemId { get; set; }
	public int InGameId { get; set; }
	public string ItemName { get; set; }
	public string ItemDescription { get; set; }
	public int ItemLvl { get; set; }
}