using AppointmentManagementSystem.Application.Features.Branches.DTOs;
using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;
using System.Diagnostics.Metrics;

namespace AppointmentManagementSystem.Application.Features.Branches.Queries.GetAllBranches;

public class GetAllBranchesQueryHandler
    : IRequestHandler<GetAllBranchesQuery, List<BranchDto>>
{
    private readonly IBranchRepository _branchRepository;

    public GetAllBranchesQueryHandler(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<List<BranchDto>> Handle(
        GetAllBranchesQuery request,
        CancellationToken cancellationToken)
    {
        var branches = await _branchRepository.GetAllAsync();

        return branches.Select(branch => new BranchDto
        {
            Id = branch.Id,
            Name = branch.Name
        }).ToList();
    }
}

