using AppointmentManagementSystem.Application.Features.Branches.DTOs;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Branches.Queries.GetAllBranches;

public record GetAllBranchesQuery : IRequest<List<BranchDto>>;