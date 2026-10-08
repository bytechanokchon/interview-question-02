using Application.DTOs.Shareds;
using Application.Handlers.Auths.DTOs.Requests;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Handlers.Auths.Commands
{
    public class RegisterUserCommand : IRequest<BaseResponseDto<object>>
    {
        public RegisterUserCommand(RequestRegisterUserDto dto)
        {
            RegisterUserDto = dto;
        }

        public RequestRegisterUserDto RegisterUserDto { get; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseResponseDto<object>>
        {
            private readonly IUserService _userService;
            private readonly IPasswordService _passwordService;

            public RegisterUserCommandHandler(IUserService userService, IPasswordService passwordService)
            {
                this._userService = userService;
                this._passwordService = passwordService;
            }

            public async Task<BaseResponseDto<object>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var userIsExists = await this._userService.IsExistsAsync(request.RegisterUserDto.Username);
                if (userIsExists) return new BaseResponseDto<object>()
                {
                    IsSuccess = false,
                    Message = "User is exists",
                    Value = null
                };

                var passwordHashed = this._passwordService.Hash(request.RegisterUserDto.Password);

                await this._userService.CreateAsync(request.RegisterUserDto.Username, passwordHashed);

                return new BaseResponseDto<object>()
                {
                    IsSuccess = true,
                    Message = "Successful",
                    Value = null
                };
            }
        }
    }
}
