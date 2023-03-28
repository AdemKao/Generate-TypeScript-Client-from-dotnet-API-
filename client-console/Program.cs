// See https://aka.ms/new-console-template for more information

using DemoAPI;
using Newtonsoft.Json;
Console.WriteLine("Start Console App Query API !");

string URL = "http://127.0.0.1:5001";
HttpClient httpClient = new HttpClient()
{
    BaseAddress = new Uri(URL),
};

UserClient client = new UserClient(httpClient);


var response = await client.GetAsync();
// var result = response.ToList();


Console.WriteLine("RESULT:" + response);

response.ToList().ForEach(res =>
{
    Console.WriteLine($"User Name:{res.Name}");
    Console.WriteLine($"User Email:{res.Email}");
}
);

Console.ReadKey();