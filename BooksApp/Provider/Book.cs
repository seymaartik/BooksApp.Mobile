using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Model;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace BooksApp.Provider
{
    public class Book
    {
        public Book()
        {
        }
        public async Task<Model.Book> GetAllBooks()
        {
            string uri = "http://34.65.222.211/api/v1/books";
            Model.Book message = new Model.Book();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Token Örneği
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Barear", token);

                    // Request tipinin JSON olacağını belirtir.
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
                    client.DefaultRequestHeaders.Accept.Clear();

                    //Json'a çevirir.
                    //var serilizedObject = JsonConvert.SerializeObject(model);

                    // Request Body'sinin contentini oluşturur.
                    //StringContent serlizedModel = new StringContent(serilizedObject, Encoding.UTF8, "application/json");

                    // Request'i gönderir. (Async çalışır. İş bitene kadar bekletir.)
                    HttpResponseMessage request = await client.GetAsync(uri);

                    // Dönen API Response'unu okur.(200 veya 404 gibi API kodları)
                    request.EnsureSuccessStatusCode();

                    // Eğer request başarılı ise (Yani 200 döndü ise)
                    if (request.IsSuccessStatusCode)
                    {
                        // API'den dönen Content'i okur.
                        string response = await request.Content.ReadAsStringAsync();
                        // Dönen Response'u kullandığımız modele çevirir.
                        message = JsonConvert.DeserializeObject<Model.Book>(response);
                    }
                    // Eğer Request başarısız döndü ise
                    else
                    {
                        // Kullanıcıya Uyarı Verir
                        await Application.Current.MainPage.DisplayAlert("HATA", "Daha sonra tekrar deneyiniz!", "Tamam");
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("HATA", "Daha sonra tekrar deneyiniz!", "Tamam");
            }

            return message;
        }
    }
}
