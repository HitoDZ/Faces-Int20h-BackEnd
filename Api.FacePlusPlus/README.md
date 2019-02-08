## How to use
Register FacePlusPlusClient in ASP.NET Core's DI as singleton.  
  
**Startup.cs:**
```
public void ConfigureServices(IServiceCollection services)
{
    ...
    
    services.AddSingleton<IFacePlusPlusClient, FacePlusPlusClient>(_ =>
    {
        return new FacePlusPlusClient(
            new FacePlusPlusClientOptions
            {
                ApiKey = "api_key",
                ApiSecret = "api_secret"
            });
    });
}
```

Then inject this client in your services or controllers. Done!