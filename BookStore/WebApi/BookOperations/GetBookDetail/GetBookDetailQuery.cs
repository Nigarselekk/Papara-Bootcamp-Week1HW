using AutoMapper;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBookDetail;

public class GetBookDetailQuery
{
    public int BookId { get; set; }
    private readonly BookStoreDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    

    public BookDetailViewModel Handle()
    {
        var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
        if (book is null)
            throw new InvalidOperationException("Book not found");
        BookDetailViewModel vm = _mapper.Map<BookDetailViewModel>(book);
        // new BookDetailViewModel();
        return vm;
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string GenreId { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    
    }
}