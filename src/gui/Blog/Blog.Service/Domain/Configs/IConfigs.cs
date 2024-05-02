namespace Blog.Service.Domain.Configs;

public interface IConfigs
{
    public bool IsProduction { get; }

    public string DbServer { get; }
    public string DbDataBase { get; }
    public string DbUser { get; }
    public string DbPassword { get; }

    public string VpsIdAddress { get; }

    public string EntryFilesPath { get; }

    public string StaticFilesPath { get; }  

    public Uri GuiHttpAddress { get; }
}
