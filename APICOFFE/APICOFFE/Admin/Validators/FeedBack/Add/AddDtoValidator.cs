using APICOFFE.Admin.Dtos.FeedBack;
using APICOFFE.Contracts.Image;
using APICOFFE.Validators;
using FluentValidation;

namespace APICOFFE.Admin.Validators.FeedBack.Add;

public class AddDtoValidator : AbstractValidator<FeedBackCreateDto>
{
    public AddDtoValidator()
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

        RuleFor(avm => avm.Name)
          .Cascade(CascadeMode.Stop)
          .NotNull()
          .WithMessage("Name can't be empty")
          .NotEmpty()
          .WithMessage("Name can't be empty")
          .MinimumLength(10)
          .WithMessage("Minimum length should be 10")
          .MaximumLength(35)
          .WithMessage("Maximum length should be 35");

        RuleFor(avm => avm.ProfilePhoto)
         .Cascade(CascadeMode.Stop)
         .NotNull()
         .SetValidator(new FileValidator(2, FileSizes.Giga,
                    FileExtensions.JPG.GetExtension(), FileExtensions.PNG.GetExtension()));
    }
}
