using FluentValidation;

namespace AppointmentManagementSystem.Application.Features.Branches.Commands.CreateBranch;

public class CreateBranchCommandValidator : AbstractValidator<CreateBranchCommand>
{
    public CreateBranchCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Branch name cannot be empty.");

        RuleFor(x => x.Name)
            .MinimumLength(2)
            .WithMessage("Branch name must be at least 2 characters.");

        RuleFor(x => x.Name)
            .MaximumLength(100)
            .WithMessage("Branch name cannot exceed 100 characters.");
    }
}