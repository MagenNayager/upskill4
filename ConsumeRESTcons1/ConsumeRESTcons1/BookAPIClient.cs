using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;


namespace ConsumeRESTcons1
{
    public static class BookAPIClient
    {
        public static void GetBooks()
        {

            string url = "http://localhost:59308/BookService.svc/Book/1";

            var syncClient = new WebClient();
            //var content = syncClient.DownloadString(url);
            var content = syncClient.DownloadData(url);

            DataContractJsonSerializer serialiser = new DataContractJsonSerializer(typeof(BookData));
            //using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
            using (var ms = new MemoryStream(content))
            {
                ms.Position = 0;
                BookData bookData1 = (BookData)serialiser.ReadObject(ms);

            }
        }

        public static void SaveBook()
        {

            string url = "http://localhost:59308/BookService.svc/AddBook/";

            var syncClient = new WebClient();
            syncClient.Headers.Add("Content-Type", "application/json");

            BookData newBook = new BookData();
            newBook.BookId = 5;
            newBook.ISBN = "55555";
            newBook.Title = "lalalalala";

            DataContractJsonSerializer serialiser = new DataContractJsonSerializer(typeof(BookData));

            var upStream = new MemoryStream();
           serialiser.WriteObject(upStream, newBook);

            upStream.Position = 0;
            StreamReader sr = new StreamReader(upStream);

            var content = syncClient.UploadString(url,"PUT", sr.ReadToEnd());

        }


        public static void UpdateBook()
        {

            string url = "http://localhost:59308/BookService.svc/UpdateBook/";

            var syncClient = new WebClient();
            syncClient.Headers.Add("Content-Type", "application/json");

            BookData newBook = new BookData();
            newBook.BookId = 1;
            newBook.ISBN = "55555";
            newBook.Title = "lalalalala";

            DataContractJsonSerializer serialiser = new DataContractJsonSerializer(typeof(BookData));

            var upStream = new MemoryStream();
            serialiser.WriteObject(upStream, newBook);

            upStream.Position = 0;
            StreamReader sr = new StreamReader(upStream);

            var content = syncClient.UploadString(url, "PUT", sr.ReadToEnd());

        }

        public static void DeleteBook()
        {

            string url = "http://localhost:59308/BookService.svc/DeleteBook/3";

            var syncClient = new WebClient();
            syncClient.Headers.Add("Content-Type", "application/json");

            var content = syncClient.UploadString(url, "DELETE","");

        }
    }
}
