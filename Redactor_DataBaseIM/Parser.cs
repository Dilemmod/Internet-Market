using AngleSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using AngleSharp.Html.Parser;
using System.Net.Http;
using AngleSharp.Io;

namespace ParserTelmart
{
    public class Info
    {
        public string Header { get; set; }
        public List<string> Title { get; set; } = new List<string>();
        public List<string> Characteristics { get; set; } = new List<string>();
        public List<string> Images { get; set; } = new List<string>();
        public List<string> Price { get; set; } = new List<string>();
    }
    public class Parser
    {
        public async Task<Info> GetInfo(string address)
        {
            // конфигурация
            var config = Configuration.Default.WithDefaultLoader();
            // асинхронно загружаем страницу    
            var document = await BrowsingContext.New(config).OpenAsync(address);

            Info result = new Info();
            //--Заголовок
            var header = document.QuerySelectorAll("div.b-pagehead h1");
            foreach (var item in header)
            {
                result.Header = item.TextContent;
            }
            //--Название
            var title = document.QuerySelectorAll("div.b-i-product-inner-b div.b-i-product-name a");
            foreach (var item in title)
            {
                result.Title.Add(item.GetAttribute("title"));
            }
            //--Картинки
            var images = document.QuerySelectorAll("div.b-i-product-inner-b div.b-i-product-pic div.b-td a.lazy_wrapper img");
            foreach (var item in images)
            {
                result.Images.Add(item.GetAttribute("data-src"));
            }
            //-Цена
            var price = document.QuerySelectorAll("div.b-i-product-inner-b div.b-price");
            foreach (var item in price)
            {
                result.Price.Add(item.TextContent);
            }
            //--Разное
            var characteristic = document.QuerySelectorAll("div.b-i-product-inner-b div.b-i-product-hide-info div.b-i-product-short-char");
            foreach (var item in characteristic)
            {
                var html = item.ToHtml();
                result.Characteristics.Add(html);
            }
            return result;
        }
    }
}
