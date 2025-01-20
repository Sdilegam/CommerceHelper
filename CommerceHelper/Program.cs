
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

RootObject data;

using (HttpClient ClientHttp = new HttpClient())
{
	int total = await GetTotalItems(ClientHttp);
	Console.WriteLine(total);
	List<string> Liste = await GetRessourceslist(ClientHttp, total);
	Console.WriteLine(Liste.Count);
}


async Task<List<string>> GetRessourceslist(HttpClient ClientHttp, int total)
{
	List<string> result = new();
	string path = "https://api.dofusdb.fr/items?$limit=50";
	HttpResponseMessage Response = await ClientHttp.GetAsync(path);
	var data = await Response.Content.ReadFromJsonAsync<RootObject>();
	result.AddRange(data.data.Select(item => item.name.fr));
	int CurrentIndex = 50;
	while (CurrentIndex < total)
	{
		path = $"https://api.dofusdb.fr/items?$limit=50$skip={CurrentIndex}";
		Response = await ClientHttp.GetAsync(path);
		data = await Response.Content.ReadFromJsonAsync<RootObject>();
		result.AddRange(data.data.Select(item => item.name.fr));
		CurrentIndex += 50;
	}
	return result;
}

async Task<int> GetTotalItems(HttpClient ClientHttp)
{
	string path = "https://api.dofusdb.fr/items?$limit=0";
	HttpResponseMessage Response = await ClientHttp.GetAsync(path);
	var data = await Response.Content.ReadFromJsonAsync<RootObject>();
	return (data.total);
}

// internal class Program
// 	public static async Task<int> Main(string[] args)
// 	{
// 		
// 		
// 		HttpClient client = new HttpClient();
// 		RootObject Data = null;
// 		string path = "https://api.dofusdb.fr/items?$limit=0";
// 		HttpResponseMessage response = await client.GetAsync(path);
// 		if (response.IsSuccessStatusCode)
// 		{
// 			// Ensure the response is successful
// 			response.EnsureSuccessStatusCode();
//
// 			// Read the response content as a string
// 			// var jsonResponse = await response.Content.ReadAsStringAsync();
// 			var APIresponse = await response.Content.ReadAsStringAsync();
// 			Data = JsonSerializer.Deserialize<RootObject>(APIresponse);
// 		}
// 		Console.WriteLine("test");
// 		return 1;
// 	}
// }
