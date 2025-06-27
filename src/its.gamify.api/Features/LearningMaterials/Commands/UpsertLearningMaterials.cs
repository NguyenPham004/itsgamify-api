using its.gamify.core;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.LearningMaterials.Commands
{
    public class UpsertLearningMaterials : IRequest<List<LearningMaterial>>
    {
        public Guid CourseId { get; set; }
        public List<Guid> FileIds { get; set; } = [];
        class CommandHandler : IRequestHandler<UpsertLearningMaterials, List<LearningMaterial>>
        {
            private readonly IUnitOfWork unitOfWork;
            public CommandHandler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }
            public async Task<List<LearningMaterial>> Handle(UpsertLearningMaterials request, CancellationToken cancellationToken)
            {
                var res = new List<LearningMaterial>();
                foreach (var entity in request.FileIds)
                {
                    var file = await unitOfWork.FileRepository.FirstOrDefaultAsync(x => x.Id == entity)
                        ?? throw new InvalidOperationException("Không tìm thấy file với Id " + entity);
                    var learningMate = await unitOfWork.LearningMaterialRepository.FirstOrDefaultAsync(x => x.Url == file.Url);

                    if (learningMate == null)
                    {
                        learningMate = new LearningMaterial()
                        {
                            Url = file.Url,
                            CourseId = request.CourseId,
                            Title = "",
                            Type = "",
                            Description = ""
                        };
                        await unitOfWork.LearningMaterialRepository.AddAsync(learningMate);
                        await unitOfWork.SaveChangesAsync();


                    }
                    res.Add(learningMate);
                }
                return res;
            }
        }


    }
}
