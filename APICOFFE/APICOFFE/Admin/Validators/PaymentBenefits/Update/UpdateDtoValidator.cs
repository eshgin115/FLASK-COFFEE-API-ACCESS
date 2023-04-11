using APICOFFE.Admin.Dtos.PaymentBenefits;
using APICOFFE.Contracts.Image;
using APICOFFE.Validators;
using FluentValidation;

namespace APICOFFE.Admin.Validators.PaymentBenefits.Update;

public class UpdateDtoValidator : AbstractValidator<PaymentBenefitsUpdateDto>
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
        When(udv => udv.Image != null, () =>
        {
            RuleFor(udv => udv.Image)
                 .SetValidator(new FileValidator(2, FileSizes.Giga,
                             FileExtensions.JPG.GetExtension(), FileExtensions.PNG.GetExtension())!);
        });
    }
}
