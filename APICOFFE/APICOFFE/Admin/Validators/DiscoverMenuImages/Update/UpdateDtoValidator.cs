using APICOFFE.Admin.Dtos.DiscoverMenu;
using APICOFFE.Contracts.Image;
using APICOFFE.Contracts.ImageCount;
using APICOFFE.Validators;
using FluentValidation;

namespace APICOFFE.Admin.Validators.DiscoverMenuImages.Update;

public class UpdateDtoValidator : AbstractValidator<DiscoverMenuUpdateRequsetDto>
{
    public UpdateDtoValidator()
    {

        RuleFor(avm => avm.Images)
          .Cascade(CascadeMode.Stop)
          .NotNull()
          .Must(i => i!.Count <= Count.MAX && i.Count >= Count.MIN);
        When(model => model.Images != null, () =>
        {
            RuleForEach(model => model.Images).SetValidator(new FileValidator(2, FileSizes.Giga,
                    FileExtensions.JPG.GetExtension(), FileExtensions.PNG.GetExtension()));
        });
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
            .MinimumLength(5)
            .WithMessage("Minimum length should be 5")
            .MaximumLength(35)
            .WithMessage("Maximum length should be 35");
        RuleFor(avm => avm.FirstHrefName)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("FirstHrefName can't be empty")
            .NotEmpty()
            .WithMessage("FirstHrefName can't be empty")
            .MinimumLength(5)
            .WithMessage("Minimum length should be 5")
            .MaximumLength(35)
            .WithMessage("Maximum length should be 35");
        RuleFor(avm => avm.FirstHrefURL)
           .Cascade(CascadeMode.Stop)
           .NotNull()
           .WithMessage("FirstHrefURL can't be empty")
           .NotEmpty()
           .WithMessage("FirstHrefURL can't be empty")
           .MinimumLength(5)
           .WithMessage("Minimum length should be 5")
           .MaximumLength(35)
           .WithMessage("Maximum length should be 35");
    }
}
