using System.Text.Json;

namespace FQ.Server
{
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowCors", builder =>
                {
                    builder
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowAnyHeader();
                });
            });

            builder.Services.AddSingleton<RealmStatus>();
            builder.Services.AddSingleton<UserHandler>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddProvider(new LoggerProvider());
            });

            var app = builder.Build();

            app.UseCors("AllowCors");
            app.UseHttpsRedirection();

            // app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

