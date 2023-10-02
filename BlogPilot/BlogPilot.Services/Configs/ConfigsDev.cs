namespace BlogPilot.Services.Configs;

public class ConfigsDev : ConfigsProduction, IConfigs
{
    public override bool IsProduction => false;
}
