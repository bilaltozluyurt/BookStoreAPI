using FluentValidation;

namespace BookStoreApi.BookOperation.GetBookDetail
{
    public class GetBookDetailValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailValidator()
        {
            RuleFor(command=> command.BookId).GreaterThan(0);
            RuleFor(command=> command.BookId).NotEmpty().WithMessage("Id Boş Geçilemez!");

        }

    }
}
