using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1219
{
    internal class Book
    {
        private string[] languagelist = { "angol", "német", "magyar" };
        private int year;
        private List<Author> authors;
        private long iSBN;
        private string language;
        private int stock;
        private int price;

        public long ISBN { 
            get => iSBN;
            set {
                if (value.ToString().Trim().Length > 10)
                    throw new ArgumentException("ISBN max 10 characters long");
                iSBN = value;
            } 
        }
        public List<Author> Authors {
            get => authors;
            set {
                if (value.Count <1 || value.Count >3)
                    throw new ArgumentException("invalid authors");
                authors = value;
            } 
        }
        public string Title { get; set; }
        public int Year { 
            get => year; 
            set {
                if (value < 2007 || value > DateTime.Today.Year)
                    throw new ArgumentException("invalid date");
                year = value;
            } 
        }
        public string Language
        {
            get => language;
            set
            {
                if (!languagelist.Contains(value.ToLower()))
                    throw new ArgumentException("Invalid language");
                language = value;
            }
        }
        public int Stock { 
            get => stock;
            set {
                if (value < 0)
                    throw new ArgumentException("Invalid stock");
                stock = value; 
            }
        }
        public int Price { 
            get => price;
            set {
                if (value < 1000 || value > 10000 || value%100 !=0)
                    throw new ArgumentException("Invalid price");
                price = value; 
            }
        }

        public Book(long iSBN, string title, int year, string language, int stock, int price, List<string> authors)
        {
            ISBN = iSBN;
            Authors = authors.Select(x => new Author(x)).ToList();
            Title = title;
            Year = year;
            Language = language;
            Stock = stock;
            Price = price;
        }

        public Book(string title, string author)
        {
            ISBN = Random.Shared.Next(1000000000, 2000000000);
            Authors = new List<Author> { new Author(author) };
            Title = title;
            Year = 2024;
            Language = "magyar";
            Stock = 0;
            Price = 4500;
        }

        public override string ToString()
        {
            return $"{(Authors.Count >  1 ? "Szerzők:" : "Szerző:")} {string.Join(", ", Authors.Select(x=> $"{x.FirstName} {x.LastName}"))}\n" +
                $"Cím: {Title}\n" +
                $"Kiadási év: {Year}\n" +
                $"Nyelv: {Language}\n" +
                $"Készlet: {(Stock > 0 ? $"{Stock} db" : "Beszerzés alatt")}\n" +
                $"Ár: {Price}\n\n";
                
        }
    }
}
