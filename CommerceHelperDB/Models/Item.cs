namespace CommerceHelperDB.Models;

// [Index("InGameID", IsUnique = true)]
public class Item
{
	public int ItemId { get; set; }
	public int InGameId { get; set; }
	public string ItemName { get; set; }
	public string ItemDescription { get; set; }
	public int ItemLvl { get; set; }
	public string IconUrl { get; set; }
	public Category Category { get; set; }
}