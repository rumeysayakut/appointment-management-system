using FluentValidation;

namespace AppointmentManagementSystem.Application.Features.Branches.Commands.DeleteBranch;

public class DeleteBranchCommandValidator : AbstractValidator<DeleteBranchCommand>
{
    public DeleteBranchCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}