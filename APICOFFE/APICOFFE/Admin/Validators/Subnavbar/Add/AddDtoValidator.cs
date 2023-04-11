using APICOFFE.Admin.Dtos.Subnavbar;
using FluentValidation;

namespace APICOFFE.Admin.Validators.Subnavbar.Add;

public class AddDtoValidator : AbstractValidator<SubnavbarCreateDto>
{
    public AddDtoValidator()
    {
         RuleFor(avm => avm.Name)
          .Cascade(CascadeMode.Stop)
          .NotNull()
          .WithMessage("Name can't be empty")
          .NotEmpty()
          .WithMessage("Name can't be empty")
          .MaximumLength(35)
          .WithMessage("Maximum length should be 10");


         RuleFor(avm => avm.ToURL)
          .Cascade(CascadeMode.Stop)
          .NotNull()
          .WithMessage("ToURL can't be empty")
          .NotEmpty()
          .WithMessage("ToURL can't be empty")
          .MaximumLength(35)
          .WithMessage("Maximum length should be 10");
      
    }
}
