# Rhetos REST API Swagger extension

This extension provides simple method to integrate controllers generated with *Rhetos.RestGenerator* package with *Swashbuckle (Swagger)*.

## Usage

This instructions assume that you have already added *Swashbuckle* to your project.

Add a reference to this package.

Modify `ConfigureServices` method in `Startup.cs`:

Lines where Rhetos with RestGenerator is added usually read

```
services
    .AddRhetos()
    .UseAspNetCoreIdentityUser()
    .AddRestApi();
```

Modify them to:

```
services
    .AddRhetos()
    .UseAspNetCoreIdentityUser()
    .AddRestApi()
    .AddRhetosSwaggerGen();
```

This addition will create swagger documents for each Rhetos module.

We still need to add endpoints for these documents. Modify `Configure` method in `Startup.cs`:

Lines where Swagger endpoints are configured usually read:

```
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
```

Modify them to:

```
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    c.SwaggerRhetosEndpoints(app);
});
```

Swagger pages for each Rhetos module should now be available.

