namespace SelfieAWookie.API.UI.ExtensionMethods;

public static class SecurityMethods {

    public const string DEFAULT_POLICY = "DEFAULT_POLICY";
    public const string DEFAULT_POLICY2 = "DEFAULT_POLICY_2";

  public static void AddCustomSecurity(this IServiceCollection services)
  {
      services.AddCors(options =>
      {
          options.AddPolicy(DEFAULT_POLICY, builder =>
          {
              builder.WithOrigins("http://127.0.0.1:5500")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
          });
          options.AddPolicy(DEFAULT_POLICY2, builder =>
          {
              builder.WithOrigins("http://127.0.0.1:5500")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
          });
      });
  }
}