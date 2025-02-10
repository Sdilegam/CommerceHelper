using CommerceHelperDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;


using (HttpClient ClientHttp = new HttpClient())
{
	List<Data> DataList = new();
	using (var Context = new CommerceHelperContext())
	{
		Context.Database.EnsureCreated();
		if (true)
			ClearDB(Context);
		DataList = await GetDatalist(ClientHttp, Context);
		ListToDb(DataList, Context);
		Context.SaveChanges();
	}
}

void ClearDB(CommerceHelperContext context)
{
	context.Item.ExecuteDeleteAsync();
	context.Category.ExecuteDeleteAsync();
	context.SuperCategory.ExecuteDeleteAsync();
}

async Task<Data[]> GetItems(HttpClient ClientHttp, int start, int limit)
{
	RootObject data;
	string path = $"https://api.dofusdb.fr/items?typeId[$ne]=203&$sort=slug.fr&$skip={start}&$limit={limit}";
	HttpResponseMessage Response = await ClientHttp.GetAsync(path);
	data = await Response.Content.ReadFromJsonAsync<RootObject>();
	return (data.data);
}

void ListToDb(List<Data> QueryReturn, CommerceHelperContext Context)
{
	List<Item>? ItemsList = Context.Item.AsNoTracking().ToList();
	List<Category>? CategoryList = Context.Category.AsNoTracking().ToList();
	List<SuperCategory>? SuperCategoryList = Context.SuperCategory.AsNoTracking().ToList();

	foreach (var QueryItem in QueryReturn)
	{
		int SuperCategoryId = QueryItem.type.superTypeId;
		int CategoryId = QueryItem.typeId;
		SuperCategory? superCategory = SuperCategoryList.FirstOrDefault(Item => Item.SuperCategoryInGameId == SuperCategoryId);
		Category? category = CategoryList.FirstOrDefault(Item => Item.CategoryInGameId == CategoryId);

		if (superCategory == null)
		{
			superCategory = new SuperCategory
			{
				SuperCategoryInGameId = SuperCategoryId,
				SuperCategoryName = QueryItem.type.superType.name.fr
			};
			SuperCategoryList.Add(superCategory);
		}

		if (category == null)
		{
			category = new Category
			{
				CategoryInGameId = CategoryId,
				CategoryName = QueryItem.type.name.fr,
				SuperCategory = superCategory,
			};
			CategoryList.Add(category);
		}

		if (ItemsList.All(x => x.InGameId != QueryItem.id))
		{
			Item item = new Item
			{
				InGameId = QueryItem.id,
				ItemName = QueryItem.name.fr,
				ItemDescription = QueryItem.description.fr,
				ItemLvl = QueryItem.level,
				Category = category,
				IconUrl = QueryItem.img
			};
			ItemsList.Add(item);
		}
	}
	Context.AddRange(SuperCategoryList);
	Context.AddRange(CategoryList);
	Context.AddRange(ItemsList);
}

async Task<List<Data>> GetDatalist(HttpClient ClientHttp, CommerceHelperContext Context)
{
	List<Data>? DataList = new();
	Data[] QueryReturn;

	int step = 50;
	int CurrentIndex = 0;
	bool IsDev = false;
	bool Logging = false;

	do
	{
		QueryReturn = (GetItems(ClientHttp, CurrentIndex, step).Result);
		if (QueryReturn.Length > 0 && Logging)
		{
			Console.Clear();
			Console.WriteLine($"Current Item: [{QueryReturn[0]?.id}] {QueryReturn[0]?.name.fr}");
			Console.WriteLine($"Current number: {CurrentIndex}");
		}
		DataList.AddRange<Data>(QueryReturn);
		CurrentIndex += step;
	} while (QueryReturn.Count() == step && (IsDev ? CurrentIndex < 300 : true));
	return (DataList);
}


async Task<int> GetTotalItems(HttpClient ClientHttp)
{
	string path = "https://api.dofusdb.fr/items?$limit=0";
	HttpResponseMessage Response = await ClientHttp.GetAsync(path);
	var data = await Response.Content.ReadFromJsonAsync<RootObject>();
	return (data.total);
}