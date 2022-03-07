namespace RatingService.Auth;

public static class ConfigAuth {
    public static IServiceCollection AddCustomAuth(this IServiceCollection services) {
        services.AddAuthentication(option => option.DefaultScheme = SchemeConst.UserManagerServiceScheme)
                .AddScheme<CustomSchemeOption, CustomAuthHandler>(
                    SchemeConst.UserManagerServiceScheme,
                    option => { }
                );
        services.AddAuthorization(option => {
            option.AddPolicy("user", option => option.RequireClaim("username"));
            option.AddPolicy("admin", option => option.RequireClaim("admin"));
        });
        return services;
    }
}