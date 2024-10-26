using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BLL;
using Newtonsoft.Json.Linq;
using System.Data;

namespace DAL
{
    
        public class BDYoutube_DAL
        {
            private readonly string apiKey = "AIzaSyBHtTQc8vZTNZZI2NUB28cTawjH9EfQioo"; 

            public async Task<List<BDYoutube_BLL>> BuscarVideos(string Informacion)
            {
                using (var client = new HttpClient())
                {
                    string url = $"https://www.googleapis.com/youtube/v3/search?part=snippet&q={Informacion}&key={apiKey}&type=video"; // Usa apiKey aquí
                    var response = await client.GetStringAsync(url);
                    var json = JObject.Parse(response);
                    var videos = new List<BDYoutube_BLL>();

                    foreach (var item in json["items"])
                    {
                        videos.Add(new BDYoutube_BLL
                        {
                            Title = item["snippet"]["title"].ToString(),
                            VideoId = item["id"]["videoId"].ToString(),
                            Description = item["snippet"]["description"].ToString()
                        });
                    }

                    return videos;
                }
            }
       }
  
}

