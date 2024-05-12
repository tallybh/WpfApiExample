using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApiExample
{
    public static class ApiService
    {


        public static FunFact? GetCatFact()
        {
            HttpClient client = new HttpClient();
            //this url gets random fun facts about cats. try copying it to a browser
            client.BaseAddress = new Uri(@"https://catfact.ninja/fact");
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var funFact = response.Content.ReadAsAsync<FunFact>().Result;
                return funFact;
            }
            else
            {
                return null;
            }
        }

        public static bool TestCreditCard(string cvv, string cardNumber, DateTime date)
        {
            HttpClient client = new HttpClient();
            //this url was copied from swagger of my project
            string url = $@"https://localhost:7227/CreditCard?cardNumberStr={cardNumber}&cvvStr={cvv}&ExpDate={date.Month}%2F{date.Year}";
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                return response.Content.ReadAsAsync<bool>().Result;
                
            }
            else
            {
                return false;
            }
        }
        public static string TranslateFromHebrewToEnglish(string hebrewText)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translate1.p.rapidapi.com/language/translate/v2"),
                Headers =
                {
                   { "X-RapidAPI-Key", "c450d6c06dmsh0d51cd0168cb727p13caf4jsn09397f296d82" },
                   { "X-RapidAPI-Host", "google-translate1.p.rapidapi.com" },
                 },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                 {
                      { "q", "Hello, world!" },
                      { "target", "en" },
                      { "source", "heb" },
                 }),
            };
            using (var response =  client.Send(request)){
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync();
                return body.Result;
            }
        }
    }
}
