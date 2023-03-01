using System.Xml.Linq;

namespace ReadDataFromWebsite;

class Program
{
    static async Task Main(string[] args)
    {
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync("https://books.toscrape.com/");

            if (response.IsSuccessStatusCode)
            {
                var xml = await response.Content.ReadAsStringAsync();
                var doc = XDocument.Parse(xml);

                var titles = from el in doc.Descendants("title")
                             select el.Value;

                foreach (var title in titles)
                {
                    Console.WriteLine(title);
                }
            }
        }
    }
}