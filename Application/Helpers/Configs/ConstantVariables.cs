namespace Application.Helpers.Configs;

public static class ConstantVariables
{
    public readonly static string jwtIssuer = Environment.GetEnvironmentVariable("JwtSettings_validIssuer")!;
    public readonly static string jwtAudience = Environment.GetEnvironmentVariable("JwtSettings_validAudience")!;
    public readonly static string jwtKey = Environment.GetEnvironmentVariable("JwtSettings_TokenKey")!;
    public readonly static string jwtExpiration = Environment.GetEnvironmentVariable("JwtSettings_expires")!;
    public readonly static string ConnectionString = Environment.GetEnvironmentVariable("ScoringAppDB")!;
}
