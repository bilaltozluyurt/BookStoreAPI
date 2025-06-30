using FluentValidation;

namespace BookStoreApi.BookOperation.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator() 
        {
            RuleFor(command => command.BookId).GreaterThan(0);

        
        
        
        }

    }
}
