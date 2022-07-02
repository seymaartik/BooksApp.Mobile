using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Text;
using BooksApp.Model;

namespace BooksApp.Services
{
    public interface IFoursquare
    {
        Task<ObservableCollection<User>> getUser(double lat, double lon);
    }
}
