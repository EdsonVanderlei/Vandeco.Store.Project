namespace VandecoStore.API.Middleware
{
    public class ProblemDetails
    {
        public required string Title { get; init; }
        public required string Instance { get; init; }
        public required string Detail { get; init; }
        public required int Status { get; init; }
        public required string Type { get; init; }
    }
}
