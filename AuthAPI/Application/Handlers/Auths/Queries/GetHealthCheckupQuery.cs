using Application.DTOs.Shareds;
using MediatR;

namespace Application.Handlers.Auths.Queries
{
    public class GetHealthCheckupQuery : IRequest<BaseResponseDto<object>>
    {
        public class GetHealthCheckupQueryHandler : IRequestHandler<GetHealthCheckupQuery, BaseResponseDto<object>>
        {
            public async Task<BaseResponseDto<object>> Handle(GetHealthCheckupQuery request, CancellationToken cancellationToken)
            {
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
