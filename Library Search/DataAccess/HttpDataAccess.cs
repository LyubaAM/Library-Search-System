using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library_Search.DataAccess
{
    public class HttpDataAccess
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task<Models.Books> GetStringAsync(string path)
        {
            //Models.Books str = null;

            HttpResponseMessage response = await client.GetAsync(path);

            //if (response.IsSuccessStatusCode)
            //{
            //    str = await response.Content.ReadAsStringAsync();
            //}

            if (response.Content is object && response.Content.Headers.ContentType.MediaType == "application/json")
            {
                var contentStream = await response.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(contentStream);
                using var jsonReader = new JsonTextReader(streamReader);

                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();

                try
                {
                    return serializer.Deserialize<Models.Books>(jsonReader);
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }
            else
            {
                Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            }

            return null;
        }
    }
}
