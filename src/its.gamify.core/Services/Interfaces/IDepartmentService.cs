using its.gamify.core.Models;
using its.gamify.core.Models.Departments;
using its.gamify.domains.Entities;
using its.gamify.domains.Models;

namespace its.gamify.core.Services.Interfaces
{
    public class DepartmentQueryDto : BaseQueryDto
    {

    }
    public interface IDepartmentService
    {
        Task<(Pagination, List<Department>)> GetAll(DepartmentQueryDto queryDto);
        Task<Department> GetDepartment(Guid id);
        Task<Department> Create(DepartmentCreateModel item);
        Task<bool> Update(DepartmentUpdateModel item);
        Task<bool> Delete(Guid Id);
    }
}
