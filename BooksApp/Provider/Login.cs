using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Model;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace BooksApp.Provider
{
    public class Login
    {
        
        public Login()
        {

        }

        /// <summary>
        /// TODO: SSL bağlanacak. iOS Response/Request kabul etmiyor.
        /// Parametre olan "USER", API'dan bizi hangi modeli istediğine göre değişecek!
        /// "RETURNEDUSER" ise API'ın döndürdüğü model ile değişecek!
        ///
        /// Yukarıda bahsi geçen modeller mobil projede birebir olacak!(Tipleri ile beraber[string, int vs...])
        /// Login içerisinde Token istemediğini düşündüğümüz için kapalı! Token; kullanıcı giriş yaptıktan sonra açılan oturumdur :)
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<Root> LoginOperation(LoginModel model)
        {
            string uri = "http://34.65.222.211/api/v1/login";

            Root root = new Root();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Token Örneği
                    //string userToken = await SecureStorage.GetAsync("Token");

                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Barear", userToken);

                    // Request tipinin JSON olacağını belirtir.
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

                    //Json'a çevirir.
                    var serilizedObject = JsonConvert.SerializeObject(model);

                    // Request Body'sinin contentini oluşturur.
                    StringContent serlizedModel = new StringContent(serilizedObject, Encoding.UTF8, "application/json");

                    // Request'i gönderir. (Async çalışır. İş bitene kadar bekletir.)
                    HttpResponseMessage request = await client.PostAsync(uri, serlizedModel);

                    // Dönen API Response'unu okur.(200 veya 404 gibi API kodları)
                    request.EnsureSuccessStatusCode();

                    // Eğer request başarılı ise (Yani 200 döndü ise)
                    if (request.IsSuccessStatusCode)
                    {
                        // API'den dönen Content'i okur.
                        string response = await request.Content.ReadAsStringAsync();

                        // Dönen Response'u kullandığımız modele çevirir.
                        root = JsonConvert.DeserializeObject<Root>(response);

                        //await SecureStorage.SetAsync("Token", root.Message.token.plainTextToken);
                    }
                    // Eğer Request başarısız döndü ise
                    else
                    {
                        // Kullanıcıya Uyarı Verir
                        await Application.Current.MainPage.DisplayAlert("HATA", "Kullanıcı Adı veya Şifre Hatalı!", "Tamam");
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("HATA", "Kullanıcı Adı veya Şifre Hatalı!", "Tamam");
            }
            return root;
        }
        
    }
}
