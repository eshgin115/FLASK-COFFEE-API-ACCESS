using APICOFFE.Admin.Dtos.FoodCategory;
using FluentValidation;

namespace APICOFFE.Admin.Validators.FoodCategory.Add;

public class AddDtoValidator : AbstractValidator<FoodCategoryCreateDto>
{
    public AddDtoValidator()
    {
        RuleFor(avm => avm.Name)
           .Cascade(CascadeMode.Stop)
           .NotNull()
           .WithMessage("Name can't be empty")
           .NotEmpty()
           .WithMessage("Name can't be empty")
           .MinimumLength(3)
           .WithMessage("Minimum length should be 3")
           .MaximumLength(35)
           .WithMessage("Maximum length should be 35");

      
    }
}
