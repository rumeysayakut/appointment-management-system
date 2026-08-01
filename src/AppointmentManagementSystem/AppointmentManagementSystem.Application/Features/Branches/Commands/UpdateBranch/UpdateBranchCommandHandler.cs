using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Branches.Commands.UpdateBranch;

public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Guid>
{
    private readonly IBranchRepository _branchRepository;

    public UpdateBranchCommandHandler(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<Guid> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = await _branchRepository.GetByIdAsync(request.Id);

        if (branch is null)
            throw new Exception("Branch not found.");

        branch.Name = request.Name;

        await _branchRepository.UpdateAsync(branch);

        return branch.Id;
    }
}