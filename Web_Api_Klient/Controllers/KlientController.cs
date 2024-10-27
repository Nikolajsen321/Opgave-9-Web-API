using Microsoft.AspNetCore.Mvc;
using Opgave_9_Rest_webapplikationer;
using System.IO.Compression;
using System.Text.Json;

namespace Web_Api_Klient.Controllers
{
    public class KlientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]

        public async Task<IActionResult> GetPersoner(IFormCollection formData)
        {
            HttpClient client = new HttpClient();
            List<Person> personer = await client.GetFromJsonAsync<List<Person>>("https://localhost:7288/api/Values/GetPersoner");

            //if (formData.ContainsKey("getPersoner") != null)
            //{  


            //}
            return View("Index", personer);
        }




[HttpGet]
    public async Task<IActionResult> GetQuote()
    {
        HttpClient client = new HttpClient();

            //// Tilføj standardbrowserens User-Agent og andre nødvendige headers
            //client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            //client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");  // Accepter komprimerede svar

            // Hent HTTP-responsen fra API'et
            HttpResponseMessage responseMessage = await client.GetAsync("https://www.tronalddump.io/random/quote");

            JsonElement response = await client.GetFromJsonAsync<JsonElement>("https://www.tronalddump.io/random/quote");
            string quote = response.GetProperty("value").ToString();

            // Kontroller om anmodningen lykkedes
            //if (!responseMessage.IsSuccessStatusCode)
            //{
            //    string errorMessage = await responseMessage.Content.ReadAsStringAsync();
            //        Console.WriteLine(responseMessage + " og " + errorMessage);
            //    return View("Quote", $"Fejl: {responseMessage.StatusCode}, {errorMessage}");
            //}

            // Håndter komprimeret indhold
            //var contentStream = await responseMessage.Content.ReadAsStreamAsync();
            //var encoding = responseMessage.Content.Headers.ContentEncoding;

            // Hvis indholdet er komprimeret, dekomprimer det
            //if (encoding.Contains("gzip"))
            //{
            //    using (var decompressedStream = new GZipStream(contentStream, CompressionMode.Decompress))
            //    using (var streamReader = new StreamReader(decompressedStream))
            //    {
            //        var decompressedContent = await streamReader.ReadToEndAsync();
            //        var jsonData = JsonDocument.Parse(decompressedContent);
            //        var quote = jsonData.RootElement.GetProperty("value").GetString();
            //        return View("Quote", quote);
            //    }
            //}
            //else if (encoding.Contains("deflate"))
            //{
            //    using (var decompressedStream = new DeflateStream(contentStream, CompressionMode.Decompress))
            //    using (var streamReader = new StreamReader(decompressedStream))
            //    {
            //        var decompressedContent = await streamReader.ReadToEndAsync();
            //        var jsonData = JsonDocument.Parse(decompressedContent);
            //        var quote = jsonData.RootElement.GetProperty("value").GetString();
            //        return View("Quote", quote);
            //    }
            //}
            //else
            //{
            // Hvis indholdet ikke er komprimeret, behandl det som almindelig tekst
            //var jsonData = JsonDocument.Parse(await responseMessage.Content.ReadAsStringAsync());
            //var quote = jsonData.RootElement.GetProperty("value").GetString();
            return View("Quote", quote);
        //}
    }




}
}

