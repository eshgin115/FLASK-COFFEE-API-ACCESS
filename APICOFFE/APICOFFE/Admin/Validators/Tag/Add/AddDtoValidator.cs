﻿using APICOFFE.Admin.Dtos.Tag;
using FluentValidation;

namespace APICOFFE.Admin.Validators.Tag.Add;

public class AddDtoValidator : AbstractValidator<TagCreateDto>
{
    public AddDtoValidator()
    {
        RuleFor(avm => avm.Name)
         .Cascade(CascadeMode.Stop)
         .NotNull()
         .WithMessage("Name can't be empty")
         .NotEmpty()
         .WithMessage("Name can't be empty")
         .MinimumLength(5)
         .WithMessage("Minimum length should be 5")
         .MaximumLength(35)
         .WithMessage("Maximum length should be 10");
    }
}
