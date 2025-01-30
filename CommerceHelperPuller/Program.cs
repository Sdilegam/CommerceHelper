using System.Net.Http.Json;

RootObject data;

using (HttpClient ClientHttp = new HttpClient())
{
	using (StreamWriter fs = File.CreateText("/home/salvatore/Documents/liste.txt"))
	{
		List<string> Liste = await GetRessourceslist(ClientHttp);
		Console.WriteLine(Liste.Count);
		foreach (var item in Liste)	
		{
			fs.WriteLine(item);
		}
	}
}


async Task<List<string>> GetRessourceslist(HttpClient ClientHttp)
{
	int step = 50;
	int CurrentIndex = 0;
	bool test = false;
	List<string> result = new();
	do
	{
		string path = $"https://api.dofusdb.fr/items?typeId[$ne]=203&$sort=slug.fr&$skip={CurrentIndex}&$limit={step}";
		HttpResponseMessage Response = await ClientHttp.GetAsync(path);
		data = await Response.Content.ReadFromJsonAsync<RootObject>();
		result.AddRange(data.data.Select(item => item.name.fr));
		Console.WriteLine(CurrentIndex);
		CurrentIndex += step;
	} while (data.data.Count() == step && (test ? CurrentIndex < 300 : true));
	return result;
}


async Task<int> GetTotalItems(HttpClient ClientHttp)
{
	string path = "https://api.dofusdb.fr/items?$limit=0";
	HttpResponseMessage Response = await ClientHttp.GetAsync(path);
	var data = await Response.Content.ReadFromJsonAsync<RootObject>();
	return (data.total);
}