using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBookDetail;
public class DeleteBookCommand
{
    public int BookId { get; set; }
    private readonly BookStoreDbContext _dbContext;

    public DeleteBookCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
        if (book is null)
            throw new InvalidOperationException("Book not found");
        _dbContext.Books.Remove(book);
        _dbContext.SaveChanges();
    }
}