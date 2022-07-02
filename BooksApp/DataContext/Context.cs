using System;
using BooksApp.Model;

namespace BooksApp.DataContext
{
    public class Context
    {
        public static Context Instance;
        public User user;
        public Context()
        {
            if(Instance == null)
            {
                Instance = this;
            }
        }
    }
}
