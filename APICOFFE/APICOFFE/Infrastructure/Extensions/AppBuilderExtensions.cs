
using APICOFFE.Admin.Hubs;
using APICOFFE.Exceptions;
using APICOFFE.Middlewares;
using System.Globalization;

namespace APICOFFE.Infrastructure.Extensions
{
    public static class AppBuilderExtensions
    {
        public static void ConfigureMiddlewarePipeline(this WebApplication app)
        {
            app.UseCustomExceptionHandler();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.MapHub<AlertHub>("hubs/alert-hub");

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();



            var localizationOptions = new RequestLocalizationOptions();
            var supportedCultures = new[]
            {
                 new CultureInfo ("en-Us"),
                 new CultureInfo ("ru-RU"),
            };
            localizationOptions.SupportedCultures = supportedCultures;
            localizationOptions.SupportedUICultures = supportedCultures;
            localizationOptions.SetDefaultCulture("en-Us");
            localizationOptions.ApplyCurrentCultureToResponseHeaders = true;
            app.UseRequestLocalization(localizationOptions);

            app.MapGet("/not-found-example", () =>
            {
                throw new NotFoundException("Information is not found in DB");
            });

            app.MapGet("/bad-request-example", () =>
            {
                throw new BadRequestException("Requester URL is invalid");
            });

            app.MapGet("/forbidden-request-example", () =>
            {
                throw new ForbiddenException("Requester URL is invalid");
            });

            app.MapGet("/unauthorized-request-example", () =>
            {
                throw new UnauthorizedException("You don't have access to this module");
            });

            app.MapGet("/validation-request-example", () =>
            {
                throw new ValidationException("Only only admin is allowed");
            });
            app.MapGet("/unregistered-exception", () =>
            {
                throw new MyException();
            });

            app.MapControllers();
        }
    }
}
