public class LinqQueries
{
    private List<Book> booksCollection = new List<Book>();

    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            String json = reader.ReadToEnd();
            this.booksCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Book> GetBooks()
    {
        return booksCollection;
    }

    public IEnumerable<Book> booksPublishedAfter2000()
    {
        // Extension Method
        // return booksCollection.Where(book => book.PublishedDate.Year > 2000);
        return from book in booksCollection where book.PublishedDate.Year > 2000 select book;
    }

    // Libros que contengan mas de 250 paginas, titulo contiene "in Action"
    public IEnumerable <Book> booksWithMore250PagesAndTitleContainsInAction() {
        // Extension Method
        // return booksCollection.Where(book => book.PageCount > 250 && book.Title.Contains("in Action"));
        return from book in booksCollection where book.PageCount > 250 && book.Title.Contains("in Action") select book;
    }

    // Verificar si todos los libros tienen un status
    public bool allBooksHaveStatus()
    {
        return booksCollection.All(book => book.Status != String.Empty);
    }

    // Verificar si alguno de los libros fue publicado en el 2005
    public bool bookPublishedIn2005()
    {
        return booksCollection.Any(book => book.PublishedDate.Year == 2005);
    }

    // Libros con la categoria python
    public IEnumerable<Book> booksWithPythonCategory()
    {
        // return booksCollection.Where(book => book.Categories.Contains("Python"));
        return from book in booksCollection where book.Categories.Contains("Python") select book;
    }

    // Libros con la categoria java ordenados por nombre
    public IEnumerable<Book> booksWithJavaCategoryOrderByName()
    {
        //return booksCollection.Where(book => book.Categories.Contains("Java")).OrderBy(book => book.Title);
        return from book in booksCollection orderby book.Title where book.Categories.Contains("Java") select book;
    }

    // Libros con mas de 400 paginas ordenados por mayor numero de paginas
    public IEnumerable<Book> booksWithMore450PagesOrderByDescending()
    {
        //return booksCollection.Where(book => book.PageCount > 450).OrderByDescending(book => book.PageCount);
        return from book in booksCollection orderby book.PageCount descending where book.PageCount > 450 select book;
    }

    // Seleccionar los  libros con fecha de publicacion mas reciente de la categoria de java mientras que tengan mas de 325 paginas
    public IEnumerable<Book> booksWithEarlierPublishedDateOfJavaCategory()
    {
        //return (from book in booksCollection orderby book.PublishedDate descending where book.Categories.Contains("Java")  select book).Take(3);
        return booksCollection.Where(book => book.Categories.Contains("Java")).OrderByDescending(book => book.PublishedDate).TakeWhile(book => book.PageCount > 325);
    }

    // Tercer y cuarto libro con mas de 400 paginas
    public IEnumerable<Book> thirdAndFourthBooskWithMore400Pages() 
    {
        return booksCollection.Where(b => b.PageCount > 400).Take(4).Skip(2);
    }

    // Primeros tres libros de la coleccion, select titulo y num de paginas
    public IEnumerable<BookViewModel> first3books()
    {
        return booksCollection.Take(3).Select(b => new BookViewModel() {Title = b.Title, PageCount = b.PageCount, PublishedDate = b.PublishedDate});
    }

}