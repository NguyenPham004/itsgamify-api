﻿using FluentValidation;
using its.gamify.core;
using its.gamify.core.Models.Users;
using its.gamify.core.Services.Interfaces;
using its.gamify.domains.Entities;
using MediatR;

namespace its.gamify.api.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<UserViewModel?>
    {
        public UserCreateModel Model { get; set; } = new();
        class CommandValidation : AbstractValidator<CreateUserCommand>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Model.Email).EmailAddress();
                RuleFor(x => x.Model.HashedPassword).NotNull().NotEmpty();
                RuleFor(x => x.Model.EmployeeCode).NotNull().NotEmpty();
                RuleFor(x => x.Model.DepartmentId).NotNull().NotEmpty();
            }
        }
        class CommandHandler : IRequestHandler<CreateUserCommand, UserViewModel?>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly IAuthService authService;
            public CommandHandler(IUnitOfWork unitOfWork,
                IAuthService authService)
            {
                this.authService = authService;
                this.unitOfWork = unitOfWork;

            }
            public async Task<UserViewModel?> Handle(CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var user = unitOfWork.Mapper.Map<User>(request.Model);
                await unitOfWork.UserRepository.AddAsync(user);
                if (!string.IsNullOrEmpty(request.Model.HashedPassword))
                    await authService.SignUpAsync(user.Email, request.Model.HashedPassword);
                if (await unitOfWork.SaveChangesAsync())
                {
                    return unitOfWork.Mapper.Map<UserViewModel>(user);
                }
                else return null;
            }
        }
    }
}
