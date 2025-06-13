using its.gamify.core;
using its.gamify.core.Models.Users;
using MediatR;

namespace its.gamify.api.Features.Users.Queries
{
    public class GetAllUserQuery : IRequest<List<UserViewModel>>
    {

        class QueryHandler : IRequestHandler<GetAllUserQuery, List<UserViewModel>>
        {
            private readonly IUnitOfWork unitOfWork;
            public QueryHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<List<UserViewModel>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                var res = await unitOfWork.UserRepository.GetAllAsync(includes: x => x.Department!);

                return unitOfWork.Mapper.Map<List<UserViewModel>>(res);
            }
        }
    }
}
