using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using MediatR;

namespace AppointmentManagementSystem.Application.Features.Branches.Commands.CreateBranch;

public class CreateBranchCommandHandler
    : IRequestHandler<CreateBranchCommand, Guid>
{
    private readonly IBranchRepository _branchRepository;

    public CreateBranchCommandHandler(IBranchRepository branchRepository)
    {
        _branchRepository = branchRepository;
    }

    public async Task<Guid> Handle(
        CreateBranchCommand request,
        CancellationToken cancellationToken)
    {
        var existingBranch =
            await _branchRepository.GetByNameAsync(request.Name);

        if (existingBranch is not null)
            throw new Exception("A branch with the same name already exists.");

        var branch = new Branch
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CreatedDate = DateTime.UtcNow
        };

        await _branchRepository.AddAsync(branch);

        return branch.Id;
    }
}