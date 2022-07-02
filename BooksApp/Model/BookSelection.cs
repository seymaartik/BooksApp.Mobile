using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BooksApp.Model
{
    public class BookSelection
    {
        public class MVA
        {
            public string title { get; set; }
            public string author { get; set; }
            public DateTime year_of_publication { get; set; }
            public string publisher { get; set; }
            public string imageUrl { get; set; }
        }

        //bunu normal ListView için kullandık
        public static IList<MVA> MVAData { get; set; }

        //gruplu şekilde listviewda kullandım
        public static IList<MVA> MVADataWithGrouping { get; set; }

        //refresh için
        public static int RefreshCount { get; set; } = 0;

        static BookSelection()
        {
            MVAData = new ObservableCollection<MVA>
            {
                new MVA
                {
                    title = "Harry Potter ve Felsefe Taşı",
                    author = "J.K.Rowling",
                    year_of_publication = new DateTime(2013, 11, 6),
                    publisher = "Yapı Kredi Yayınları",
                    imageUrl="flower.jpeg"

                },

                new MVA
                {
                    title = "Korudaki Gümüş",
                    author = "Emily Tesh",
                    year_of_publication = new DateTime(2018, 1, 6),
                    publisher = "İthaki Yayınları",
                    imageUrl="flower.jpeg"
                },

                new MVA
                {
                    title = "Sonsuz Ayrıntı",
                    author = "J.K.Rowling",
                    year_of_publication = new DateTime(2022, 8, 6),
                    publisher = "Yapı Kredi Yayınları",
                    imageUrl="flower.jpeg"
                },

                new MVA
                {
                    title = "Yüzüklerin Efendisi",
                    author = "J.J.R Tolkein",
                    year_of_publication = new DateTime(2013, 11, 6),
                    publisher = "Metis Yayınları",
                    imageUrl="flower.jpeg"
                },
                new MVA
                {
                    title = "Saklambaç",
                    author = "N.GRowling",
                    year_of_publication = new DateTime(2013, 11, 6),
                    publisher = "Yapı Kredi Yayınları",
                    imageUrl="flower.jpeg"

                },

                new MVA
                {
                    title = "Gerçek olmayacak Kadar Güzel",
                    author = "Emily Tesh",
                    year_of_publication = new DateTime(2018, 1, 6),
                    publisher = "İthaki Yayınları",
                    imageUrl="flower.jpeg"
                },

                new MVA
                {
                    title = "Sonsuz Ayrıntı",
                    author = "J.K.Rowling",
                    year_of_publication = new DateTime(2022, 8, 6),
                    publisher = "Yapı Kredi Yayınları",
                    imageUrl="flower.jpeg"
                },

                new MVA
                {
                    title = "Enstitü",
                    author = "J.J.R Tolkein",
                    year_of_publication = new DateTime(2013, 11, 6),
                    publisher = "Metis Yayınları",
                    imageUrl="flower.jpeg"
                },
                new MVA
                {
                    title = "Küçük Sırlar",
                    author = "J.K.Rowling",
                    year_of_publication = new DateTime(2013, 11, 6),
                    publisher = "Yapı Kredi Yayınları",
                    imageUrl="flower.jpeg"

                },

                new MVA
                {
                    title = "Korudaki Gümüş",
                    author = "Emily Tesh",
                    year_of_publication = new DateTime(2018, 1, 6),
                    publisher = "İthaki Yayınları",
                    imageUrl="flower.jpeg"
                },

                new MVA
                {
                    title = "Paranormal Hikayeler",
                    author = "J.K.Rowling",
                    year_of_publication = new DateTime(2022, 8, 6),
                    publisher = "Yapı Kredi Yayınları",
                    imageUrl="flower.jpeg"
                },

                new MVA
                {
                    title = "Medyum",
                    author = "J.J.R Tolkein",
                    year_of_publication = new DateTime(2013, 11, 6),
                    publisher = "Metis Yayınları",
                    imageUrl="flower.jpeg"
                }
            };
        }

        public static ObservableCollection<Grouping<string, MVA>>
            BindingWithGrouping(string searchText="")
        {
            var result = MVAData;

            if (!String.IsNullOrEmpty(searchText) && searchText.Length>=2)
            {
                result = result.
                    Where(x => x.title.ToLower().StartsWith(searchText.ToLower())).ToList();
            }


            var list = new ObservableCollection<Grouping<string, MVA>>
                (result.
                OrderBy(c => RefreshCount%2==0 ? c.title : c.publisher).
                GroupBy(c => c.title[0].ToString()).
                Select(k => new Grouping<string, MVA>(k.Key, k)));

            return list;
        }
    }
}
