
namespace MyEmailMaketing.Common.Models
{
    public class MethodResult
    {
        public bool Success { get; set; } = true;
        public string Error { get; set; } = "";
        public string Message { get; set; } = "";
        public int? Status { get; set; } = 200;

        public static MethodResult ResultWithSuccess(string message = "")
        {
            return new MethodResult
            {
                Success = true,
                Message = message
            };
        }

        public static MethodResult ResultWithError(string error, int? status = null, string message = "")
        {
            return new MethodResult
            {
                Success = false,
                Message = message,
                Error = error,
                Status = status
            };
        }

        public static MethodResult ResultWithAccessDenined()
        {
            return ResultWithError("ERR_FORBIDDEN", 403, "Bạn không đủ quyền để lấy dữ liệu đã yêu cầu");
        }

        public static MethodResult ResultWithNotFound()
        {
            return ResultWithError("ERR_NOT_FOUND", 404, "Không tìm thấy dữ liệu đã yêu cầu");
        }
    }
}
