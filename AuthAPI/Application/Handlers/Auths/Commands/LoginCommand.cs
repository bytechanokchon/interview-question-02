using Application.DTOs.Shareds;
using Application.Handlers.Auths.DTOs.Requests;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Handlers.Auths.Commands
{
    public class LoginCommand : IRequest<BaseResponseDto<string>>
    {
        public LoginCommand(RequestLoginDto dto)
        {
            LoginDto = dto;
        }

        public RequestLoginDto LoginDto { get; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, BaseResponseDto<string>>
        {
            private readonly IUserService _userService;
            private readonly IPasswordService _passwordService;
            private readonly IJwtTokenService _jwtTokenService;

            public LoginCommandHandler(IUserService userService, IPasswordService passwordService, IJwtTokenService jwtTokenService)
            {
                this._userService = userService;
                this._passwordService = passwordService;
                this._jwtTokenService = jwtTokenService;
            }

            public async Task<BaseResponseDto<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var userIsExists = await this._userService.IsExistsAsync(request.LoginDto.Username);

                if (!userIsExists) return new BaseResponseDto<string>()
                {
                    IsSuccess = false,
                    Message = "Username or password is invalid",
                    Value = string.Empty
                };

                var userInfo = await this._userService.GetUserInfoByUsernameAsync(request.LoginDto.Username);
                var isPassowrdMatched = this._passwordService.Verify(request.LoginDto.Password, userInfo!.Password);

                if (!isPassowrdMatched) return new BaseResponseDto<string>()
                {
                    IsSuccess = false,
                    Message = "Username or password is invalid",
                    Value = string.Empty
                };

                var token = this._jwtTokenService.GenerateToken(userInfo.Id, userInfo.Username);

                return new BaseResponseDto<string>()
                {
                    IsSuccess = true,
                    Message = "Successful",
                    Value = token
                };
            }
        }
    }
}
