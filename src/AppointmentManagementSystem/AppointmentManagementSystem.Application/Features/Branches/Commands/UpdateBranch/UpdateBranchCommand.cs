using MediatR;

namespace AppointmentManagementSystem.Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBranchCommand : IRequest<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}