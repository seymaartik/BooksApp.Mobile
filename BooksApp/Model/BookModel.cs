using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BooksApp.Model
{
    public class BookModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        
      

       



        //public static IList<BookModel> MVAData { get; set; }
        //
        ////gruplu şekilde listviewda kullandım
        //public static IList<BookModel> MVADataWithGrouping { get; set; }
        //
        ////refresh için
        //public static int RefreshCount { get; set; } = 0;
        //
        //public static ObservableCollection<Grouping<string, BookModel>>
        //    BindingWithGrouping(string searchText = "")
        //{
        //    var result = MVAData;
        //
        //    if (!String.IsNullOrEmpty(searchText) && searchText.Length >= 2)
        //    {
        //        result = result.
        //            Where(x => x.title.ToLower().StartsWith(searchText.ToLower())).ToList();
        //    }
        //
        //
        //    var list = new ObservableCollection<Grouping<string, BookModel>>
        //        (result.
        //        OrderBy(c => RefreshCount % 2 == 0 ? c.title : c.publisher).
        //        GroupBy(c => c.title[0].ToString()).
        //        Select(k => new Grouping<string, BookModel>(k.Key, k)));
        //
        //    return list;
        //}
    }

    public class Datum
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string year_of_publication { get; set; }
        public string isbn { get; set; }
        public string publisher { get; set; }
        public string image_url_s { get; set; }
        public string image_url_m { get; set; }
        public string image_url_l { get; set; }
        public object created_at { get; set; }
        public object updated_at { get; set; }
    }


    public class Link
    {
        public string url { get; set; }
        public string label { get; set; }
        public bool active { get; set; }
    }

    public class Book
    {
        public int current_page { get; set; }
        public List<Datum> data { get; set; }
        public string first_page_url { get; set; }
        public int from { get; set; }
        public int last_page { get; set; }
        public string last_page_url { get; set; }
        public List<Link> links { get; set; }
        public string next_page_url { get; set; }
        public string path { get; set; }
        public int per_page { get; set; }
        public object prev_page_url { get; set; }
        public int to { get; set; }
        public int total { get; set; }
    }
}
