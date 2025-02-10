namespace CommerceHelperDB.Models;

public class Category
{
	public int CategoryId { get; set; }
	public int CategoryInGameId { get; set; }
	public string CategoryName { get; set; }
	public SuperCategory SuperCategory { get; set; }
}