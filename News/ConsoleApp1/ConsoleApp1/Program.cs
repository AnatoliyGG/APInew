using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ConsoleApp1.models;

namespace ConsoleApp1
{
    class Program
    {
        const string Api_Key = "4b945e4bcbc74a0a9410cffcf453c62b";
        static void Main(string[] args)
        {
            string response = "";

            Console.WriteLine("Новости \n");
            Show_API();
        }
        static void Show_API()
        {
            var client = new HttpClient();
            var response = client.GetAsync(new Uri(
                   $"http://newsapi.org/v2/top-headlines?country=ru&apiKey={Api_Key}")).GetAwaiter().GetResult();
            var jsonResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var newsInfo = JsonConvert.DeserializeObject<NewsInfo>(jsonResult);

            foreach (Article article in newsInfo.Articles)
            {
                Console.Write("Источник: " + article.Source.Name + "\nЗаголовок: " + article.Title + "\nОписание: " + article.Description + "\nСсылка на новость в источнике: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(article.Url);
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
