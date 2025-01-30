using Microsoft.EntityFrameworkCore;

namespace CommerceHelperDB.Models;

public class Price
{
	public int PriceId { get; set; }
	public long Value { get; set; }
	public DateTime Date { get; set; }
	public virtual Item Item { get; set; }
}