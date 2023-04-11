using APICOFFE.Admin.Dtos.Navbar;
using FluentValidation;

namespace APICOFFE.Admin.Validators.Navbar.Update;

public class UpdateDtoValidator : AbstractValidator<NavbarUpdateDto>
{
    public UpdateDtoValidator()
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

        RuleFor(avm => avm.ToURL)
        .Cascade(CascadeMode.Stop)
        .NotNull()
        .WithMessage("ToURL can't be empty")
        .NotEmpty()
        .WithMessage("ToURL can't be empty")
        .MinimumLength(3)
        .WithMessage("Minimum length should be 3")
        .MaximumLength(35)
        .WithMessage("Maximum length should be 35");


    }
}
