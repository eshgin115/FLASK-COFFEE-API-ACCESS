using APICOFFE.Admin.Dtos.ShortInfo;
using FluentValidation;

namespace APICOFFE.Admin.Validators.ShortInfo.Update;

public class UpdateDtoValidator : AbstractValidator<ShortInfoUpdateDto>
{
    public UpdateDtoValidator()
    {
        RuleFor(avm => avm.PlaceInfo)
        .Cascade(CascadeMode.Stop)
        .NotNull()
        .WithMessage("PlaceInfo can't be empty")
        .NotEmpty()
        .WithMessage("PlaceInfo can't be empty")
        .MinimumLength(5)
        .WithMessage("Minimum length should be 5")
        .MaximumLength(100)
        .WithMessage("Maximum length should be 100");

        RuleFor(avm => avm.ShortеTitleStreet)
        .Cascade(CascadeMode.Stop)
        .NotNull()
        .WithMessage("ShortеTitleStreet can't be empty")
        .NotEmpty()
        .WithMessage("ShortеTitleStreet can't be empty")
        .MinimumLength(7)
        .WithMessage("Minimum length should be 7")
        .MaximumLength(100)
        .WithMessage("Maximum length should be 10");

        RuleFor(avm => avm.TitleStreet)
        .Cascade(CascadeMode.Stop)
        .NotNull()
        .WithMessage("TitleStreet can't be empty")
        .NotEmpty()
        .WithMessage("TitleStreet can't be empty")
        .MinimumLength(10)
        .WithMessage("Minimum length should be 10")
        .MaximumLength(100)
        .WithMessage("Maximum length should be 100");

       RuleFor(avm => avm.HoursOfWork)
        .Cascade(CascadeMode.Stop)
        .NotNull()
        .WithMessage("HoursOfWork can't be empty")
        .NotEmpty()
        .WithMessage("HoursOfWork can't be empty")
        .MinimumLength(5)
        .WithMessage("Minimum length should be 5")
        .MaximumLength(100)
        .WithMessage("Maximum length should be 100");

      RuleFor(avm => avm.WorkingHoursByDay)
       .Cascade(CascadeMode.Stop)
       .NotNull()
       .WithMessage("WorkingHoursByDay can't be empty")
       .NotEmpty()
       .WithMessage("WorkingHoursByDay can't be empty")
       .MinimumLength(5)
       .WithMessage("Minimum length should be 5")
       .MaximumLength(100)
       .WithMessage("Maximum length should be 100");
    }
}
