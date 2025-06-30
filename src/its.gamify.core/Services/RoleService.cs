using its.gamify.domains.Entities;
using its.gamify.domains.Models;

namespace its.gamify.core.Services;



public interface IRoleService
{
    public Task<Role> CreateAsync(CreateRoleModel model);
    public Task<(Pagination, List<Role>)> GetAllAsync();
}


public class RoleService(
    IUnitOfWork unitOfWork
    ) : IRoleService
{

    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Role> CreateAsync(CreateRoleModel model)
    {
        var role = new Role
        {
            Name = model.Name,
            Description = model.Description
        };
        await _unitOfWork.RoleRepository.AddAsync(role);
        await _unitOfWork.SaveChangesAsync();

        return role;
    }

    public async Task<(Pagination, List<Role>)> GetAllAsync()
    {
        return await _unitOfWork.RoleRepository.ToPagination(pageSize: 100);
    }
}


