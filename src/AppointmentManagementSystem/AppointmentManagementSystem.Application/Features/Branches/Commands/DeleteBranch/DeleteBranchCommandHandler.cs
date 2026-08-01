using AppointmentManagementSystem.Application.Interfaces.Persistence;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Branches.Commands.DeleteBranch;

public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand>
{
    private readonly IBranchRepository _branchRepository;

    public DeleteBranchCommandHandler(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<Unit> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = await _branchRepository.GetByIdAsync(request.Id);

        if (branch is null)
            throw new Exception("Branch not found.");

        await _branchRepository.DeleteAsync(branch);

        return Unit.Value;
    }
}