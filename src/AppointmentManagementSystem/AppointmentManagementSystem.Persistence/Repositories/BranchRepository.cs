using AppointmentManagementSystem.Application.Interfaces.Persistence;
using AppointmentManagementSystem.Domain.Entities;
using AppointmentManagementSystem.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagementSystem.Persistence.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly ApplicationDbContext _context;

    public BranchRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Branch branch)
    {
        await _context.Branches.AddAsync(branch);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Branch branch)
    {
        _context.Branches.Remove(branch);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Branch>> GetAllAsync()
    {
        return await _context.Branches
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Branch?> GetByIdAsync(Guid id)
    {
        return await _context.Branches
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Branch?> GetByNameAsync(string name)
    {
        return await _context.Branches
            .FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task UpdateAsync(Branch branch)
    {
        _context.Branches.Update(branch);
        await _context.SaveChangesAsync();
    }
}