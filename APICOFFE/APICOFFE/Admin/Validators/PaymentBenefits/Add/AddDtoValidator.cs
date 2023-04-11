using APICOFFE.Admin.Dtos.PaymentBenefits;
using APICOFFE.Contracts.Image;
using APICOFFE.Validators;
using FluentValidation;

namespace APICOFFE.Admin.Validators.PaymentBenefits.Add;

public class AddDtoValidator : AbstractValidator<PaymentBenefitsCreateDto>
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

        RuleFor(avm => avm.Image)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .SetValidator(new FileValidator(2, FileSizes.Giga,
                       FileExtensions.JPG.GetExtension(), FileExtensions.PNG.GetExtension()));
    }
}
