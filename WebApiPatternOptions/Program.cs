
using Microsoft.Extensions.Options;

namespace WebApiPatternOptions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddHttpClient();

            // esta é a configuração caso não haja validação de data Annotations nas propriedades das classes q seguem o padrão IOption
            //var configOptions = builder.Configuration.GetSection(UserApiOptions.UserApi);
            //builder.Services.Configure<UserApiOptions>(configOptions); 

            builder.Services.AddOptions<UserApiOptions>()
                .Bind(builder.Configuration.GetSection(UserApiOptions.UserApi)).ValidateDataAnnotations();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //app.MapGet("/getAllInformationsFromUser", (IOptions<UserApiOptions> options) =>
            //{
            //    var config = options.Value;
            //    return config;
            //}).WithName("GetAllInformationsFromUser");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
