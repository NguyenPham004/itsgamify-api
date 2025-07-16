using its.gamify.core.Models.ShareModels;
using its.gamify.domains.Entities;
using MediatR;


namespace its.gamify.core.Features.Roles;


public class GetAllRolesQuery : IRequest<BasePagingResponseModel<Role>>
{

    class QueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllRolesQuery, BasePagingResponseModel<Role>>
    {

        public async Task<BasePagingResponseModel<Role>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var (Pagination, Entities) = await _unitOfWork.RoleRepository.ToPagination(pageSize: 100);

            return new BasePagingResponseModel<Role>(datas: Entities, pagination: Pagination);
        }

    }

}
