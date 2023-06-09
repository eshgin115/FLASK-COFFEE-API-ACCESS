﻿using APICOFFE.Admin.Dtos.WelcomeSlider;
using APICOFFE.Contracts.Image;
using APICOFFE.Validators;
using FluentValidation;

namespace APICOFFE.Admin.Validators.WelcomeSlider.Update;

public class UpdateDtoValidator : AbstractValidator<WelcomeSliderUpdateDto>
{
    public UpdateDtoValidator()
    {
        RuleFor(avm => avm.Content)
             .Cascade(CascadeMode.Stop)
             .NotNull()
             .WithMessage("Name can't be empty")
             .NotEmpty()
             .WithMessage("Name can't be empty")
             .MinimumLength(5)
             .WithMessage("Minimum length should be 5")
             .MaximumLength(100)
             .WithMessage("Maximum length should be 100");

        RuleFor(avm => avm.Title)
             .Cascade(CascadeMode.Stop)
             .NotNull()
             .WithMessage("Title can't be empty")
             .NotEmpty()
             .WithMessage("Title can't be empty")
             .MinimumLength(5)
             .WithMessage("Minimum length should be 5")
             .MaximumLength(100)
             .WithMessage("Maximum length should be 100");

        RuleFor(avm => avm.Subheading)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("Subheading can't be empty")
            .NotEmpty()
            .WithMessage("Subheading can't be empty")
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


        RuleFor(avm => avm.SecondHrefName)
             .Cascade(CascadeMode.Stop)
             .NotNull()
             .WithMessage("SecondHrefName can't be empty")
             .NotEmpty()
             .WithMessage("SecondHrefName can't be empty")
             .MinimumLength(5)
             .WithMessage("Minimum length should be 5")
             .MaximumLength(35)
             .WithMessage("Maximum length should be 35");


        RuleFor(avm => avm.SecondHrefURL)
             .Cascade(CascadeMode.Stop)
             .NotNull()
             .WithMessage("SecondHrefURL can't be empty")
             .NotEmpty()
             .WithMessage("SecondHrefURL can't be empty")
             .MinimumLength(5)
             .WithMessage("Minimum length should be 5")
             .MaximumLength(35)
             .WithMessage("Maximum length should be 35");


        RuleFor(avm => avm.Page)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .WithMessage("Page can't be empty")
            .NotEmpty()
            .WithMessage("Page can't be empty");


        When(udv => udv.Image != null, () =>
        {
            RuleFor(udv => udv.Image)
                 .SetValidator(new FileValidator(2, FileSizes.Giga,
                             FileExtensions.JPG.GetExtension(), FileExtensions.PNG.GetExtension())!);
        });
    }
}
