using APICOFFE.Admin.Dtos.Food;
using APICOFFE.Contracts.Image;
using APICOFFE.Contracts.ImageCount;
using APICOFFE.Validators;
using FluentValidation;

namespace APICOFFE.Admin.Validators.Food.Add;

public class AddDtoValidator : AbstractValidator<FoodCreateDto>
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
          .MaximumLength(100)
          .WithMessage("Maximum length should be 100");

        RuleFor(avm => avm.Title)
          .Cascade(CascadeMode.Stop)
          .NotNull()
          .WithMessage("Title can't be empty")
          .NotEmpty()
          .WithMessage("Title can't be empty")
          .MinimumLength(10)
          .WithMessage("Minimum length should be 10")
          .MaximumLength(100)
          .WithMessage("Maximum length should be 100");

        RuleFor(avm => avm.Ingredients)
        .Cascade(CascadeMode.Stop)
        .NotNull()
        .WithMessage("Ingredients can't be empty")
        .NotEmpty()
        .WithMessage("Ingredients can't be empty")
        .MinimumLength(10)
        .WithMessage("Minimum length should be 10")
        .MaximumLength(100)
        .WithMessage("Maximum length should be 100");



        RuleFor(avm => avm.MainImage)
                 .Cascade(CascadeMode.Stop)

                 .NotNull()
                 .WithMessage("Image can't be empty")

                 .SetValidator(
                      new FileValidator(2, FileSizes.Giga,
                          FileExtensions.JPG.GetExtension(), FileExtensions.PNG.GetExtension())!);
        RuleFor(avm => avm.Images)
              .Cascade(CascadeMode.Stop)
              .NotNull()
              .Must(i => i!.Count <= Count.MAX && i.Count >= Count.MIN)
              .WithMessage("should be 4 photos");
        When(model => model.Images != null, () =>
        {
            RuleForEach(model => model.Images).SetValidator(new FileValidator(2, FileSizes.Giga,
                    FileExtensions.JPG.GetExtension(), FileExtensions.PNG.GetExtension()));
        });
    }
}
