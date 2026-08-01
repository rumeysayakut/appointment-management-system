using FluentValidation;

namespace AppointmentManagementSystem.Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}