using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using var client = new HttpClient();

string requestUri = "http://webcode.me";
string requestUri2 = "http://webcode.me/ua.php";

var result = await client.GetAsync(requestUri);
// Console.WriteLine(result.StatusCode);

// ------------------------------

var context = await client.GetStringAsync(requestUri);
// Console.WriteLine(context);

// ------------------------------

#region HttpClient HEAD Request
var headResult = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, requestUri2));
// Console.WriteLine(headResult);
#endregion

#region HttpClient User-Agent
client.DefaultRequestHeaders.Add("User-Agent", "C# program");

var res = await client.GetStringAsync(requestUri2);
// Console.WriteLine(res);
#endregion

#region HttpClient HttpRequestMessage
// var msg = new HttpRequestMessage(HttpMethod.Get, requestUri);
// msg.Headers.Add("User-Agent", "C# Program");
// var res2 = await client.SendAsync(msg);

// var content = await res2.Content.ReadAsStringAsync();
// Console.WriteLine(content); 
#endregion

#region HttpClient query strings
// string u = "http://webcode.me/qs.php";
// var builder = new UriBuilder(u);
// builder.Query = "name=John Doe&occupation=gardener";
// var url = builder.ToString();
// var res3 = await client.GetAsync(url);
// var content2 = await res3.Content.ReadAsStringAsync();

// Console.WriteLine(content2);
#endregion

#region HttpClient multiple async requests
/* var urls = new string[] { "http://webcode.me", "http://example.com", "http://httpbin.org", "https://ifconfig.me", "http://termbin.com", "https://github.com" };

var rx = new Regex(@"<title>\s*(.+?)\s*</title>", RegexOptions.Compiled);

var tasks = new List<Task<string>>();

foreach (var url in urls)
{
    tasks.Add(client.GetStringAsync(url));
}

Task.WaitAll(tasks.ToArray());

var data = new List<string>();

foreach (var task in tasks)
{
    data.Add(await task);
}

foreach (var content in data)
{
    var matches = rx.Matches(content);

    foreach (var match in matches)
    {
        Console.WriteLine(match);
    }
} */
#endregion

#region HttpClient POST request
/* var person = new Person("John Doe", "gardener");

var json = JsonConvert.SerializeObject(person);
var data2 = new StringContent(json, Encoding.UTF8, "application/json");

string url2 = "https://httpbin.org/post";

var response = await client.PostAsync(url2, data2);
var result2 = await response.Content.ReadAsStringAsync();

Console.WriteLine(result2);

record Person(string Name, string Occupation); */
#endregion

#region  HttpClient JSON request
/* client.BaseAddress = new Uri("https://api.github.com");
client.DefaultRequestHeaders.Add("User-Agent", "C# Console Program");
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

var url = "repos/symfony/symfony/contributors";
HttpResponseMessage response = await client.GetAsync(url);
response.EnsureSuccessStatusCode();
var resp = await response.Content.ReadAsStringAsync();

List<Contributor> contributors = JsonConvert.DeserializeObject<List<Contributor>>(resp);
contributors.ForEach(Console.WriteLine);

record Contributor(string Login, short Contributions); */
#endregion

#region HttpClient POST form data
/* var url = "https://httpbin.org/post";

var data = new Dictionary<string, string>
{
    {"name", "John Doe"},
    {"occupation", "gardener"}
};

var res2 = await client.PostAsync(url, new FormUrlEncodedContent(data));

var content = await res2.Content.ReadAsStringAsync();
Console.WriteLine(content); */
#endregion

#region HttpClient Proxy
/* var port = 7302;
var proxy = "example.com";
var url = "http://webcode.me";

var handler = new HttpClientHandler()
{
    Proxy = new WebProxy(new Uri($"socks5://{proxy}:{port}")),
    UseProxy = true,
};

var res3 = await client.GetAsync(url);
var content = await res3.Content.ReadAsStringAsync();

Console.WriteLine(content); */
#endregion

#region HttpClient download image
/* var url = "https://asset.tureng.com/images/tureng-logo-top-mini-new.png";
byte[] imageBytes = await client.GetByteArrayAsync(url);

string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

string localFilename = "favicon.png";
string localPath = Path.Combine(documentPath, localFilename);

Console.WriteLine(localPath);
File.WriteAllBytes(localPath, imageBytes); */
#endregion

#region HttpClient streaming
/* var url3 = "https://cdn.netbsd.org/pub/NetBSD/NetBSD-9.2/images/NetBSD-9.2-amd64-install.img.gz";
var fname = Path.GetFileName(url3);
var resp = await client.GetAsync(url3, HttpCompletionOption.ResponseHeadersRead);
resp.EnsureSuccessStatusCode();
using Stream ms = await resp.Content.ReadAsStreamAsync();
using FileStream fs = File.Create(fname);
await ms.CopyToAsync(fs);

Console.WriteLine("file downloaded"); */
#endregion

#region HttpClient Basic authentication
var userName = "user7";
var passwd = "passwd";
var url4 = "https://httpbin.org/basic-auth/user7/passwd";

var authToken = Encoding.ASCII.GetBytes($"{userName}:{passwd}");
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

var result3 = await client.GetAsync(url4);
var content3 = await result3.Content.ReadAsStringAsync();

Console.WriteLine(content3);
#endregion