using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BooksApp.Model
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AccessToken
    {
        public string name { get; set; }
        public List<string> abilities { get; set; }
        public int tokenable_id { get; set; }
        public string tokenable_type { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public int id { get; set; }
    }

    public class Message
    {
        public Token token { get; set; }
        public string token_type { get; set; }
        public string success { get; set; }
        public User user { get; set; }
    }

    public class Root
    {
        public Message message { get; set; }
    }

    public class Token
    {
        public AccessToken accessToken { get; set; }
        public string plainTextToken { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public object email_verified_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
