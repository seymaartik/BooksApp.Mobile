using System;
namespace BooksApp.Model
{
    public class TokenModel
    {
        public TokenModel()
        {
        }

        public string token { get; set; }
        public string token_type { get; set; }
        public string expires_at { get; set; }
        public object success { get; set; }
    }
}
