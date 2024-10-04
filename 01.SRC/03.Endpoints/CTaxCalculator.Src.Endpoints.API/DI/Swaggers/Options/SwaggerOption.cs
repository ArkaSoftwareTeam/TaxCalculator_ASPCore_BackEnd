namespace CTaxCalculator.Src.Endpoints.API.DI.Swaggers.Options
{
    public class SwaggerOption
    {
        public bool Enable { get; set; } = true;
        public SwaggerDocOption SwaggerDoc { get; set; } = new();
        public SwaggerOAuthOption OAuth { get; set; } = new();
    }
}
