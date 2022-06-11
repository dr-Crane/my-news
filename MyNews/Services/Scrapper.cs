using HtmlAgilityPack;
using MyNews.Models;

namespace MyNews.Services
{
    public class Scrapper
    {
        private HtmlWeb web = new HtmlWeb();

        public NewsModel Run()
        {
            HtmlDocument doc = web.Load("https://bilim.akipress.org/ru/news:1786380?from=portal&place=last&b=2");
            NewsModel model = new NewsModel();

            model.Title = doc.DocumentNode.SelectNodes("//*[@id=\"col-left-sidebar\"]/div/div/div[2]/h2").First().InnerText;
            var text = doc.DocumentNode.SelectNodes("//*[@id=\"col-left-sidebar\"]/div/div/div[2]/div[4]/p");
            model.DateTime = doc.DocumentNode.SelectNodes("//*[@id=\"col-left-sidebar\"]/div/div/div[2]/div[2]/span[2]").First().InnerText;

            model.Description = text.First().InnerText;

            foreach (var item in text)
            {
                model.Content += item.InnerText;
                model.Content += "\n";
            }

            return model;
        }
    }
}
