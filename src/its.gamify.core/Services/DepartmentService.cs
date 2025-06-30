using AutoMapper;
using its.gamify.core.Models.Courses;
using its.gamify.core.Models.Departments;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using its.gamify.domains.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Services;

public class DepartmentService(IMapper mapper, IUnitOfWork unitOfWork, IClaimsService claimsService) : IDepartmentService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;



    public Dictionary<string, object> GetTransitions()
    {
        return new Dictionary<string, object>
        {
            {
                CourseStatusConstants.INITIAL_STEP, new CourseStateTransition<Course>{
                    From = [CourseStatusConstants.INITIAL_STEP],
                    To = CourseStatusConstants.CONTENT_STEP,
                    Guard=(course) =>{

                        return true;

                    },
                    Validate= async (model)=>{

                        await Task.Delay(100);
                        return true;

                    },
                    Action = async(param) => {

                        var (course ,model) = param;

                        await Task.Delay(100);

                        return course;
                    }
                }
            }
        };
    }



    public async Task<(Pagination, List<Department>)> GetAll(DepartmentQueryDto queryDto)
    {
        Expression<Func<Department, bool>> filter;

        if (string.IsNullOrEmpty(queryDto.Q))
        {
            // Nếu không có từ khóa tìm kiếm, không cần áp dụng điều kiện tìm kiếm
            filter = x => true;
        }
        else
        {
            // Sử dụng EF.Functions.Like hoặc EF.Functions.Contains tùy thuộc vào phiên bản EF Core
            var searchTerm = queryDto.Q.ToLower();
            filter = x => EF.Functions.Like(x.Name.ToLower(), $"%{searchTerm}%");

            // Hoặc nếu bạn đang sử dụng EF Core 5.0 trở lên, bạn có thể sử dụng:
            // filter = x => EF.Functions.Contains(x.Name.ToLower(), searchTerm);
        }

        var departments = await _unitOfWork.DepartmentRepository.ToPaginationV2(
            pageIndex: queryDto.Page,
            pageSize: queryDto.Limit,
            withDeleted: false,
            filter: filter,
            orderBy: queryDto.OrderBy
        );

        return departments;
    }
    public async Task<Department> GetDepartment(Guid id)
    {
        var result = await _unitOfWork.DepartmentRepository.GetByIdAsync(id);

        return result ?? throw new Exception("Not found");
    }
    public async Task<Department> Create(DepartmentCreateModel item)
    {
        if (item == null) throw new Exception("No data to create");
        var createItem = _mapper.Map<Department>(item);
        await _unitOfWork.DepartmentRepository.AddAsync(createItem);
        if (await _unitOfWork.SaveChangesAsync()) return createItem;
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
