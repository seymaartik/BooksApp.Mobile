using System;
namespace BooksApp.Model
{
    // mobilResult diye ara bi model yazıyoruz
    public class MobilResult
    {
        // Result işlemin başarılı olup olmadığını söyleyecek
        public bool Result { get; set; }

        //Data eğer işlem başarılıysa ve bu işlemin sonunda bi object veya object listesi döneteceksem burda dönüyorum
        public object Data { get; set; }

        //Message ise artık biz ne yazmak istiyorsak
        public string Message { get; set; }
    }
}
