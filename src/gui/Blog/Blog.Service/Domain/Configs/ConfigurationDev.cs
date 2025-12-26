namespace Blog.Service.Domain.Configs;

public class ConfigurationDev : ConfigurationProduction, IConfigs
{
    public override bool IsProduction => false;

    //public override string DbDataBase => "blog_dev";
    public override string DbDataBase => "blog";

    public override string EntryFilesPath => @"C:\xampp\htdocs\files\blog\entries";

    public override string StaticFilesPath => @"C:\xampp\htdocs\files\blog\src\gui\Blog\Blog.Gui\wwwroot";

    public override string DatabaseFile => @"C:\xampp\htdocs\files\blog\src\gui\Blog\Blog.Resources\sql\data.db";
}
