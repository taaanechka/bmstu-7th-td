using Carter;

public class HomeModule : ICarterModule
{
    //GET http://localhost:80/
    public void AddRoutes(IEndpointRouteBuilder app) => 
            app.MapGet("/", () => "Hello from Carter!");
}
