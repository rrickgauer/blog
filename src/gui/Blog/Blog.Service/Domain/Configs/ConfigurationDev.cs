namespace Blog.Service.Domain.Configs;

public class ConfigurationDev : ConfigurationProduction, IConfigs
{
    public override bool IsProduction => false;

    public override string DbDataBase => "blog_dev";
}
