LinqQueries linqQueries = new LinqQueries();

printValuesBookViewModel(linqQueries.first3books());
printvalues(linqQueries.booksWithMore450PagesOrderByDescending());


void printvalues(IEnumerable<Book> books)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "titulo", "N. paginas", "fecha publicacion");
    foreach (var book in books)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}

void printValuesBookViewModel(IEnumerable<BookViewModel> books)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var book in books)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
    }
}


