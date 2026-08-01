using MediatR;

namespace AppointmentManagementSystem.Application.Features.Branches.Commands.CreateBranch;

public sealed record CreateBranchCommand(string Name) : IRequest<Guid>;