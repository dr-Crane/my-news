using HtmlAgilityPack;

namespace MyNews.Services
{
    public class Scrapper
    {
        private HtmlWeb web = new HtmlWeb();
        //private string _address;

        //public Scrapper(string url)
        //{
        //    _address = url;
        //}

        public Tuple<string, string> Run()
        {
            HtmlDocument doc = web.Load("https://bilim.akipress.org/ru/news:1786380?from=portal&place=last&b=2");

            var title = doc.DocumentNode.SelectNodes("//*[@id=\"col-left-sidebar\"]/div/div/div[2]/h2").First().InnerText;
            var text = doc.DocumentNode.SelectNodes("//*[@id=\"col-left-sidebar\"]/div/div/div[2]/div[4]/p");
            string result="";
            foreach (var item in text)
            {
                result += item.InnerText;
                result += "\n";
            }

            return new Tuple<string, string>(title, result);
        }
    }
}
