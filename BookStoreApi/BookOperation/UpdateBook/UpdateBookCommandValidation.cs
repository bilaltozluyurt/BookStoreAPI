using FluentValidation;

namespace BookStoreApi.BookOperation.UpdateBook
{
    public class UpdateBookCommandValidation: AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidation() 
        {
            RuleFor(command=> command.BookId).GreaterThan(0);
            RuleFor(command=> command.BookId).NotEmpty().WithMessage("Id Boş Geçilemez!");
        }
    }
}
