using System.Diagnostics;
using System.Net.Http.Json;
using CommerceHelperDB.Models;
using EFCore.BulkExtensions;
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
		Context.Item.ExecuteDelete();
		Context.Category.ExecuteDelete();
		Context.SuperCategory.ExecuteDelete();
		List<Item> ListItems= Context.Item.AsNoTracking().ToList();
		List<Category> ListCategory= Context.Category.AsNoTracking().ToList();
		List<SuperCategory> ListSuperCategory= Context.SuperCategory.AsNoTracking().ToList();
		int step = 50;
		int CurrentIndex = 0;
		bool test = true;
		do
		{
			string path =
				$"https://api.dofusdb.fr/items?typeId[$ne]=203&$sort=slug.fr&$skip={CurrentIndex}&$limit={step}";
			HttpResponseMessage Response = await ClientHttp.GetAsync(path);
			data = await Response.Content.ReadFromJsonAsync<RootObject>();
			foreach (var ParsedItem in data.data)
			{
				int SuperCategoryId = ParsedItem.type.superTypeId;
				SuperCategory? superCategory = ListSuperCategory.Find(x => x.SuperCategoryInGameId == SuperCategoryId);
				if (superCategory == null)
				{
					superCategory = new SuperCategory
					{
						SuperCategoryInGameId = SuperCategoryId,
						SuperCategoryName = ParsedItem.type.superType.name.fr
					};
					Context.SuperCategory.Add(superCategory);
				}
				int CategoryId = ParsedItem.typeId;
				Category? category = ListCategory.Find(x => x.CategoryInGameId == CategoryId);
				if (category == null)
				{
					category = new Category
					{
						CategoryInGameId = CategoryId,
						CategoryName = ParsedItem.type.name.fr,
						SuperCategory = superCategory,
					};
					Context.Category.Add(category);
				}
				Item item = new Item
				{
					InGameId = ParsedItem.id,
					ItemName = ParsedItem.name.fr,
					ItemDescription = ParsedItem.description.fr,
					ItemLvl = ParsedItem.level,
					Category = category,
					IconUrl = ParsedItem.img
				};
				if (ListItems.All(x => x.InGameId != ParsedItem.id))
					Context.Item.Add(item);
			}
			CurrentIndex += step;
		} while (data.data.Count() == step && (test ? CurrentIndex < 300 : true));

		await Context.SaveChangesAsync();
	}
}


async Task<int> GetTotalItems(HttpClient ClientHttp)
{
	string path = "https://api.dofusdb.fr/items?$limit=0";
	HttpResponseMessage Response = await ClientHttp.GetAsync(path);
	var data = await Response.Content.ReadFromJsonAsync<RootObject>();
	return (data.total);
}