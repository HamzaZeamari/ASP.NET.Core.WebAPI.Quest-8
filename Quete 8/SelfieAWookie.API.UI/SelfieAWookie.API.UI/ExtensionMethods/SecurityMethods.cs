namespace SelfieAWookie.API.UI.ExtensionMethods;

public static class SecurityMethods {

    public const string DEFAULT_POLICY = "DEFAULT_POLICY";

  public static void AddCustomSecurity(this IServiceCollection services)
  {
      services.AddCors(options =>
      {
          options.AddPolicy(DEFAULT_POLICY, builder =>
          {
              builder.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
          });
      });
  }
}