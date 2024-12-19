using _1219;
#region
//List<Book> books = new List<Book>()
//{
//    // Magyar könyvek (80%)
//    new Book(9634036857, "Hajnali láz", 2015, "magyar", 12, 3400, new List<string> { "Gárdos Péter" }),
//    new Book(9634387917, "Időfutár", 2012, "magyar", 0, 2800, new List<string> { "Gimesi Dóra", "Jeli Viktória", "Tasnádi István" }),
//    new Book(9636430987, "Akik már nem leszünk sosem", 2020, "magyar", 15, 4000, new List<string> { "Krusovszky Dénes" }),
//    new Book(9636765898, "Levelek a paplan alatt", 2018, "magyar", 8, 3000, new List<string> { "Grecsó Krisztián" }),
//    new Book(9634334737, "Az örökség", 2021, "magyar", 9, 3700, new List<string> { "Tóth Krisztina" }),
//    new Book(9635044727, "Margó", 2019, "magyar", 10, 3300, new List<string> { "Tompa Andrea" }),
//    new Book(9634198476, "A harmincadik", 2020, "magyar", 6, 3500, new List<string> { "Bartis Attila" }),
//    new Book(9635302115, "Utazások kora", 2017, "magyar", 7, 2800, new List<string> { "Závada Péter" }),
//    new Book(9789633554956, "A legkisebb jégkorszak", 2016, "magyar", 10, 3100, new List<string> { "Dragomán György" }),
//new Book(9789634794153, "Pinty és Ponty", 2021, "Hungarian", 5, 2700, new List<string> { "Lackfi János" }),


//    // Angol könyvek (20%)
//    new Book(0439023481, "The Hunger Games", 2008, "angol", 20, 3200, new List<string> { "Suzanne Collins" }),
//    new Book(0679783268, "To Kill a Mockingbird", 1960, "English", 13, 4500, new List<string> { "Harper Lee" }),
//    new Book(0316492935, "The Silent Patient", 2019, "angol", 0, 3800, new List<string> { "Alex Michaelides" })
//};
#endregion

string[] authors = { "Gárdos Péter", "Gimesi Dóra", "Jeli Viktória", "Tasnádi István", "Krusovszky Dénes", "Grecsó Krisztián", "Tóth Krisztina", "Tompa Andrea", "Bartis Attila", "Závada Péter", "Dragomán György", "Lackfi János", "Suzanne Collins", "Harper Lee", "Alex Michaelides" };
string[] titles = { "Hajnali láz", "Időfutár", "Akik már nem leszünk sosem", "Levelek a paplan alatt", "Az örökség", "Margó", "A harmincadik", "Utazások kora", "A legkisebb jégkorszak", "Pinty és Ponty", "The Hunger Games", "To Kill a Mockingbird", "The Silent Patient" };

List<Book> books = new List<Book>();
Random rnd = new Random();
for (int i = 0; i < 15; i++)
{
    long isbn = Random.Shared.NextInt64(1000000000, 10000000000);
    while (books.Any(k => k.ISBN.Equals(isbn)))
    {
        isbn = Random.Shared.NextInt64(1000000000, 10000000000);
    };


    int stock = Random.Shared.Next(5, 11);
    if (Random.Shared.Next(0, 10) < 3)
    {
        stock = 0;
    }

    int year = Random.Shared.Next(2007, DateTime.Now.Year);

    string language = Random.Shared.Next(0, 10) < 8 ? "magyar" : "angol";

    int price = Random.Shared.Next(10, 100)*100;
    if (price % 100 != 0)
    {
        price = Random.Shared.Next(10, 100)*100;
    }

    List<string> author = new List<string>();
    string title = titles[Random.Shared.Next(0, titles.Length)];

    if (Random.Shared.Next(0, 10) < 7)
    {
        author.Add(authors[Random.Shared.Next(0, authors.Length)]);
    }

    else
    {
        author.Add(authors[Random.Shared.Next(0, authors.Length)]);
        author.Add(authors[Random.Shared.Next(0, authors.Length)]);
        if (Random.Shared.Next(0, 10) < 5)
        {
            author.Add(authors[Random.Shared.Next(0, authors.Length)]);
        }
    }

    books.Add(new(isbn, title, year, language, stock, price, author));
}

int income = 0;
int bookCount = books.Sum(b => b.Stock);
int newbooks = 0;
int none = 0;

for (int i = 0; i < 100; i++)
{
    if (books.Count == 0) 
    {
        break;
    }

    Book book = books[Random.Shared.Next(0, books.Count)];
    if (book.Stock > 0)
    {
        book.Stock--;
        income += book.Price;
    }
    else 
    {
        bool couldbuy = Random.Shared.Next(1, 2) == 1;
        if (couldbuy)
        {
            int booknumbers = Random.Shared.Next(1, 10);
            book.Stock += booknumbers;
            newbooks += booknumbers;
        }
        else
        {
            books.Remove(book);
            none++;
        }

    }


}
foreach (var book in books)
{
    Console.WriteLine(book);
}   

Console.WriteLine($"A bevétel: {income}");
Console.WriteLine($"{bookCount - books.Sum(b =>b.Stock)} könyv fogyott ki a nagykerben");
Console.WriteLine($"Beszerzett könyvek száma: {bookCount} db");