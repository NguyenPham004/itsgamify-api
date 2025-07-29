using FluentValidation;
using its.gamify.api.Features.Categories.Commands;
using its.gamify.core.Features.Challenges.Commands;
using its.gamify.core.Models.Categories;
using its.gamify.core.Models.UserChallengeHistories;
using its.gamify.domains.Entities;
using its.gamify.domains.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace its.gamify.core.Features.UserChallengeHistories.Commands
{
    public class CreateUserChallengeHistoryCommand : UserChallengeHistoryViewModel, IRequest<UserChallengeHistory>
    {
        class CommandValidation : AbstractValidator<CreateUserChallengeHistoryCommand>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Score).NotNull().NotEmpty().WithMessage("Vui lòng nhập điểm");
                RuleFor(x => x.OpponentScore).NotNull().NotEmpty().WithMessage("Vui lòng nhập điểm của đối thủ");
                RuleFor(x => x.Duration).NotNull().NotEmpty().WithMessage("Vui lòng thời gian làm");
            }
        }
        class CommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateUserChallengeHistoryCommand, UserChallengeHistory>
        {
            public async Task<UserChallengeHistory> Handle(CreateUserChallengeHistoryCommand request, CancellationToken cancellationToken)
            {
                if (request.Status != UserChallengeHistoryEnum.WIN.ToString() && request.Status != UserChallengeHistoryEnum.LOSE.ToString()) throw new Exception("Trạng thái lịch sử thi đấu không hợp lệ");
                await unitOfWork.ChallengeRepository.EnsureExistsIfIdNotEmpty(request.ChallengeId);
                await unitOfWork.UserRepository.EnsureExistsIfIdNotEmpty(request.UserId);
                var item = unitOfWork.Mapper.Map<UserChallengeHistory>(request);
                await unitOfWork.UserChallengeHistoryRepository.AddAsync(item, cancellationToken);
                await unitOfWork.SaveChangesAsync();
                return item;
            }
        }
    }
}
