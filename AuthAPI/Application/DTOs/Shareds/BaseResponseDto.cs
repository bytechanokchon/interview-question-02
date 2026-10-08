namespace Application.DTOs.Shareds
{
    public class BaseResponseDto<T>
    {
        public bool IsSuccess { get; set; }
        public required string Message { get; set; }
        public T? Value { get; set; }
    }
}
