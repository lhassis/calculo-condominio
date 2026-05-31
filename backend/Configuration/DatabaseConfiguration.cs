namespace CondominioApi.Configuration;

public class DatabaseConfiguration
{
    public string ConnectionString { get; set; } = string.Empty;
    public bool ValidateConnection { get; set; } = true;
}
