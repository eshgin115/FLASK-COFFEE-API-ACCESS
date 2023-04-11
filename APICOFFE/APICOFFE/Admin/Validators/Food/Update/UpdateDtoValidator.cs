using APICOFFE.Admin.Dtos.Food;
using FluentValidation;

namespace APICOFFE.Admin.Validators.Food.Update;

public class UpdateDtoValidator : AbstractValidator<FoodUpdateDto>
{
    public UpdateDtoValidator()
    {
        RuleFor(avm => avm.Content)
         .Cascade(CascadeMode.Stop)
         .NotNull()
         .WithMessage("Content can't be empty")
         .NotEmpty()
         .WithMessage("Content can't be empty")
         .MinimumLength(10)
         .WithMessage("Minimum length should be 10")
         .MaximumLength(35)
         .WithMessage("Maximum length should be 35");

        RuleFor(avm => avm.Title)
          .Cascade(CascadeMode.Stop)
          .NotNull()
          .WithMessage("Title can't be empty")
          .NotEmpty()
          .WithMessage("Title can't be empty")
          .MinimumLength(10)
          .WithMessage("Minimum length should be 10")
          .MaximumLength(35)
          .WithMessage("Maximum length should be 35");

        RuleFor(avm => avm.Ingredients)
        .Cascade(CascadeMode.Stop)
        .NotNull()
        .WithMessage("Ingredients can't be empty")
        .NotEmpty()
        .WithMessage("Ingredients can't be empty")
        .MinimumLength(10)
        .WithMessage("Minimum length should be 10")
        .MaximumLength(35)
        .WithMessage("Maximum length should be 35");
    }
}
