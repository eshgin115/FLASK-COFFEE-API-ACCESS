using APICOFFE.Admin.Dtos.Navbar;
using FluentValidation;

namespace APICOFFE.Admin.Validators.Size.Update;

public class UpdateDtoValidator:AbstractValidator<NavbarUpdateDto>
{
    public UpdateDtoValidator()
    {
        RuleFor(avm => avm.Name)
          .Cascade(CascadeMode.Stop)
          .NotNull()
          .WithMessage("Name can't be empty")
          .NotEmpty()
          .WithMessage("Name can't be empty")
          .MaximumLength(35)
          .WithMessage("Maximum length should be 10");
    }
}
