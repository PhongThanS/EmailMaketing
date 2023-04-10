
namespace MyEmailMaketing.Common.Models
{
    public class MethodResult<T>
    {
        public bool Success { get; set; } = true;
        public T? Data { get; set; } = default(T);
        public string Error { get; set; } = "";
        public string Message { get; set; } = "";
        public int? Status { get; set; }
        public int TotalRecord { get; set; }

        public static MethodResult<T> ResultWithData(T data, string message = "", int totalRecord = 0)
        {
            return new MethodResult<T>
            {
                Data = data,
                Message = message,
                TotalRecord = totalRecord,
                Status = 200
            };
        }

        public static MethodResult<T> ResultWithError(string error, int? status = null, string message = "", T? data = default)
        {
            return new MethodResult<T>
            {
                Success = false,
                Error = error,
                Message = message,
                Status = status,
                Data = data
            };
        }

        public static MethodResult<T> ResultWithAccessDenined()
        {
            return ResultWithError("ERR_FORBIDDEN", 403, "Bạn không đủ quyền để lấy dữ liệu đã yêu cầu");
        }

        public static MethodResult<T> ResultWithNotFound()
        {
            return ResultWithError("ERR_NOT_FOUND", 404, "Không tìm thấy dữ liệu đã yêu cầu");
        }
    }
}
