namespace CommerceHelperDB.Models;

public class Prices
{
	public int PriceId { get; set; }
	public long Value { get; set; }
	public DateTime Date { get; set; }
	public virtual Items Items { get; set; }
}