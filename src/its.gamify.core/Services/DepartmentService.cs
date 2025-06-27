using AutoMapper;
using its.gamify.core.Models.Departments;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;

namespace its.gamify.core.Services;
public class DepartmentService(IMapper mapper, IUnitOfWork unitOfWork, IClaimsService claimsService) : IDepartmentService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IClaimsService _claimsService = claimsService;

    public async Task<List<DepartmentViewModel>> GetAll(int page, int limit, string q)
    {
        var departments = await _unitOfWork.DepartmentRepository.GetAllAsync();
        if (departments.Count > 0)
        {
            var leaderROle = await _unitOfWork.RoleRepository.FirstOrDefaultAsync(x => x.Name == RoleEnum.LEADER.ToString());

            // Phân trang
            var pagedDepartments = departments.Skip(page * limit).Take(limit).ToList();
            var departmentsList = _mapper.Map<List<DepartmentViewModel>>(pagedDepartments);
            foreach (var dept in departmentsList)
            {
                dept.Leader = await GetLeader(dept.Id);
            }
            return departmentsList;
        }
        else throw new Exception("Not have any department");
    }
    private async Task<User?> GetLeader(Guid id)
    {
        var leader = await _unitOfWork.UserRepository.FirstOrDefaultAsync(x => x.DepartmentId == id && x.Role.Name == RoleEnum.LEADER.ToString(), includes: [x => x.Role]);
        return leader;
    }
    public async Task<DepartmentViewModel> GetDepartment(Guid id)
    {
        var result = await _unitOfWork.DepartmentRepository.GetByIdAsync(id, includes: [x => x.Users]);
        var roles = await _unitOfWork.RoleRepository.FirstOrDefaultAsync(x => x.Name == RoleEnum.LEADER.ToString())
            ?? throw new Exception("Chưa tồn tại role leader");
        if (result is not null)
        {
            var res = _unitOfWork.Mapper.Map<DepartmentViewModel>(result);
            res.Leader = result.Users?.FirstOrDefault(x => x.RoleId == roles.Id);
            return res;
        }
        else throw new Exception("Không tồn tại phòng ban");



    }
    public async Task<DepartmentViewModel> Create(DepartmentCreateModel item)
    {
        if (item == null) throw new Exception("No data to create");
        var createItem = _mapper.Map<Department>(item);
        await _unitOfWork.DepartmentRepository.AddAsync(createItem);
        if (await _unitOfWork.SaveChangesAsync()) return _mapper.Map<DepartmentViewModel>(createItem);
        else throw new Exception("Create failed");
    }
    public async Task<bool> Update(DepartmentUpdateModel item)
    {
        var updatedItem = await _unitOfWork.DepartmentRepository.GetByIdAsync(item.Id);
        if (updatedItem != null)
        {
            updatedItem = (Department)_mapper.Map(item, typeof(DepartmentUpdateModel), typeof(Department));
            _unitOfWork.DepartmentRepository.Update(updatedItem);
            if (await _unitOfWork.SaveChangesAsync()) return true;
            else throw new Exception("Save change failed!");
        }
        else throw new Exception("Not found");
    }
    public async Task<bool> Delete(Guid Id)
    {
        var deletedItem = await _unitOfWork.DepartmentRepository.FirstOrDefaultAsync(x => x.Id == Id);
        if (deletedItem != null)
        {
            _unitOfWork.DepartmentRepository.SoftRemove(deletedItem);
            if (!await _unitOfWork.SaveChangesAsync())
            {
                throw new Exception("Delete failed!");
            }
            return true;
        }
        else throw new Exception("Not found");
    }

    public async Task<bool> DeleteRange(List<Guid> ids)
    {
        var deletedItems = await _unitOfWork.DepartmentRepository.WhereAsync(x => ids.Contains(x.Id));
        _unitOfWork.DepartmentRepository.SoftRemoveRange(deletedItems);
        return await _unitOfWork.SaveChangesAsync();
        //var deletedItems = _unitOfWork.DepartmentRepository.SoftRemoveRange() 
    }
}
