using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Domain.Configs;

public interface IConfigs
{
    public bool IsProduction { get; }

    public string DbServer { get; }
    public string DbDataBase { get; }
    public string DbUser { get; }
    public string DbPassword { get; }

    //public string EmailAddress { get; }
    //public string EmailSmtpClient { get; }
    //public string EmailUsername { get; }
    //public string EmailPassword { get; }

    //public Uri UrlGui { get; }

    //public string RequestHeaderKey { get; }
    //public string RequestHeaderValue { get; }

    //public string IpAddressVps { get; }


    //public DirectoryInfo LocalApplicationDataFolder { get; }
    //public FileInfo WpfUserCredentials { get; }

    //public FileInfo WpfApplicationExe { get; }
}
