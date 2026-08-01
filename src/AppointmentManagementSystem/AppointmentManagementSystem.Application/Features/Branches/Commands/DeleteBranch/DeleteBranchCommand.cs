using MediatR;

namespace AppointmentManagementSystem.Application.Features.Branches.Commands.DeleteBranch;

public class DeleteBranchCommand : IRequest
{
    public Guid Id { get; set; }
}