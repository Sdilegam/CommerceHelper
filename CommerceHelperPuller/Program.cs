using System.Net.Http.Json;
using CommerceHelperDB.Models;
using Microsoft.EntityFrameworkCore;

RootObject data;

using (HttpClient ClientHttp = new HttpClient())
{
	 await GetRessourceslist(ClientHttp);
}


async Task GetRessourceslist(HttpClient ClientHttp)
{
	using (var Context = new CommerceHelperContext())
	{
		Context.Database.EnsureCreated();
		List<Item> listItems= Context.Items.ToList();
		int step = 50;
		int CurrentIndex = 0;
		bool test = false;
		do
		{
			string path =
				$"https://api.dofusdb.fr/items?typeId[$ne]=203&$sort=slug.fr&$skip={CurrentIndex}&$limit={step}";
			HttpResponseMessage Response = await ClientHttp.GetAsync(path);
			data = await Response.Content.ReadFromJsonAsync<RootObject>();
			foreach (var ParsedItem in data.data)
			{
				Item item = new Item
				{
					InGameId = ParsedItem.id,
					ItemName = ParsedItem.name.fr,
					ItemDescription = ParsedItem.description.fr,
					ItemLvl = ParsedItem.level,
				};
				if (!listItems.Any(x => x.InGameId == ParsedItem.id))
					Context.Items.AddAsync(item);
			}
			CurrentIndex += step;
		} while (data.data.Count() == step && (test ? CurrentIndex < 300 : true));

		Context.SaveChanges();
	}
}


async Task<int> GetTotalItems(HttpClient ClientHttp)
{
	string path = "https://api.dofusdb.fr/items?$limit=0";
	HttpResponseMessage Response = await ClientHttp.GetAsync(path);
	var data = await Response.Content.ReadFromJsonAsync<RootObject>();
	return (data.total);
}