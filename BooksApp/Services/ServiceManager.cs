using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Model;
using Newtonsoft.Json;

namespace BooksApp.Services
{
    public class ServiceManager
    {
        private string url = "http://34.65.222.211/api/v1/";

        //async çalışan bi httpclient servis yazmalıyız çünkü biz api ile haberleştiğimizde arka tarafta başka birşeyler daha yapılabilir
        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        /*
        public async Task<IEnumerable<StudentModel>> GetAll()
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(url + "books");
            //burda json ile çalışacağımız için nuGetten newtonsoft.Json indir
            var mobilResult = JsonConvert.DeserializeObject<MobilResult>(result);
            return JsonConvert.DeserializeObject<IEnumerable<StudentModel>>(mobilResult.Data.ToString());
        }
        */

        public async Task<IEnumerable<BookModel>> GetAll()
        {
            HttpClient client = await GetClient();
            var result = await client.GetStringAsync(url + "books");
            //burda json ile çalışacağımız için nuGetten newtonsoft.Json indir
            var mobilResult = JsonConvert.DeserializeObject<MobilResult>(result);
            return JsonConvert.DeserializeObject<IEnumerable<BookModel>>(mobilResult.Data.ToString());

        }

        /*
        public async Task<MobilResult> Insert(StudentModel model)
        {
            //insert işlemini gerçekleştirdik
            HttpClient client = await GetClient();
            //                                          yazılan servisten insert ediyor             StudentModel    türkçe karakterler  hangi formatta gidecek
            var response = await client.PostAsync(url + "insert",new StringContent(JsonConvert.SerializeObject(model),Encoding.UTF8, "application/json"));

            var mobileResult =await response.Content.ReadAsStringAsync();
            //insert işleminin cevabını alıyoruz
            var result = JsonConvert.DeserializeObject<MobilResult>(mobileResult);
            return result;

        }
        */

        public async Task<MobilResult> Insert(BookModel model)
        {
            //insert işlemini gerçekleştirdik
            HttpClient client = await GetClient();
            //                                          yazılan servisten insert ediyor             StudentModel    türkçe karakterler  hangi formatta gidecek
            var response = await client.PostAsync(url + "insert", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            var mobileResult = await response.Content.ReadAsStringAsync();
            //insert işleminin cevabını alıyoruz
            var result = JsonConvert.DeserializeObject<MobilResult>(mobileResult);
            return result;
        }
    }
}
