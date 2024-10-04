namespace CTaxCalculator.Framework.Endpoints.Web.Middlewares
{
    public class ApiError
    {
        public string Id { get; set; } = string.Empty;
        public short Status { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Links { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
    }
}
