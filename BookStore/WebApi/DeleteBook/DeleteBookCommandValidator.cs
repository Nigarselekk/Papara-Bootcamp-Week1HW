using FluentValidation;

namespace WebApi.BookOperations.GetBookDetail;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
   public DeleteBookCommandValidator(){
      RuleFor(command => command.BookId).GreaterThan(0);
   }
}