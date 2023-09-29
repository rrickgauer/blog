using System.ComponentModel;

namespace BlogPilot.Services.Domain.Enum;

public enum TopicReference : uint
{
    [Description("3D")]
    ThreeDimensional = 1,

    [Description("Ajax")]
    Ajax = 2,

    [Description("Algorithm")]
    Algorithm = 3,

    [Description("Amp")]
    Amp = 4,

    [Description("Android")]
    Android = 5,

    [Description("Angular")]
    Angular = 6,

    [Description("Ansible")]
    Ansible = 7,

    [Description("API")]
    Api = 8,

    [Description("Arduino")]
    Arduino = 9,

    [Description("ASP.NET")]
    AspNet = 10,

    [Description("Atom")]
    Atom = 11,

    [Description("Awesome Lists")]
    AwesomeLists = 12,

    [Description("Amazon Web Services")]
    AmazonWebServices = 13,

    [Description("Azure")]
    Azure = 14,

    [Description("Babel")]
    Babel = 15,

    [Description("Bash")]
    Bash = 16,

    [Description("Bitcoin")]
    Bitcoin = 17,

    [Description("Bootstrap")]
    Bootstrap = 18,

    [Description("Bot")]
    Bot = 19,

    [Description("C")]
    C = 20,

    [Description("Chrome")]
    Chrome = 21,

    [Description("Chrome extension")]
    ChromeExtension = 22,

    [Description("Command line interface")]
    CommandLineInterface = 23,

    [Description("Clojure")]
    Clojure = 24,

    [Description("Code quality")]
    CodeQuality = 25,

    [Description("Code review")]
    CodeReview = 26,

    [Description("Compiler")]
    Compiler = 27,

    [Description("Continuous integration")]
    ContinuousIntegration = 28,

    [Description("COVID-19")]
    Covid19 = 29,

    [Description("C++")]
    Cpp = 30,

    [Description("Cryptocurrency")]
    Cryptocurrency = 31,

    [Description("Crystal")]
    Crystal = 32,

    [Description("C#")]
    CSharp = 33,

    [Description("CSS")]
    Css = 34,

    [Description("Data structures")]
    DataStructures = 35,

    [Description("Data visualization")]
    DataVisualization = 36,

    [Description("Database")]
    Database = 37,

    [Description("Deep learning")]
    DeepLearning = 38,

    [Description("Dependency management")]
    DependencyManagement = 39,

    [Description("Deployment")]
    Deployment = 40,

    [Description("Django")]
    Django = 41,

    [Description("Docker")]
    Docker = 42,

    [Description("Documentation")]
    Documentation = 43,

    [Description(".NET")]
    Net = 44,

    [Description("Electron")]
    Electron = 45,

    [Description("Elixir")]
    Elixir = 46,

    [Description("Emacs")]
    Emacs = 47,

    [Description("Ember")]
    Ember = 48,

    [Description("Emoji")]
    Emoji = 49,

    [Description("Emulator")]
    Emulator = 50,

    [Description("ES6")]
    Es6 = 51,

    [Description("ESLint")]
    Eslint = 52,

    [Description("Ethereum")]
    Ethereum = 53,

    [Description("Express")]
    Express = 54,

    [Description("Firebase")]
    Firebase = 55,

    [Description("Firefox")]
    Firefox = 56,

    [Description("Flask")]
    Flask = 57,

    [Description("Font")]
    Font = 58,

    [Description("Framework")]
    Framework = 59,

    [Description("Front end")]
    FrontEnd = 60,

    [Description("Game engine")]
    GameEngine = 61,

    [Description("Git")]
    Git = 62,

    [Description("GitHub API")]
    GithubApi = 63,

    [Description("Go")]
    Go = 64,

    [Description("Google")]
    Google = 65,

    [Description("Gradle")]
    Gradle = 66,

    [Description("GraphQL")]
    Graphql = 67,

    [Description("Gulp")]
    Gulp = 68,

    [Description("Haskell")]
    Haskell = 69,

    [Description("Homebrew")]
    Homebrew = 70,

    [Description("Homebridge")]
    Homebridge = 71,

    [Description("HTML")]
    Html = 72,

    [Description("HTTP")]
    Http = 73,

    [Description("Icon font")]
    IconFont = 74,

    [Description("iOS")]
    Ios = 75,

    [Description("IPFS")]
    Ipfs = 76,

    [Description("Java")]
    Java = 77,

    [Description("JavaScript")]
    Javascript = 78,

    [Description("Jekyll")]
    Jekyll = 79,

    [Description("jQuery")]
    Jquery = 80,

    [Description("JSON")]
    Json = 81,

    [Description("The Julia Language")]
    TheJuliaLanguage = 82,

    [Description("Jupyter Notebook")]
    JupyterNotebook = 83,

    [Description("Koa")]
    Koa = 84,

    [Description("Kotlin")]
    Kotlin = 85,

    [Description("Kubernetes")]
    Kubernetes = 86,

    [Description("Laravel")]
    Laravel = 87,

    [Description("LaTeX")]
    Latex = 88,

    [Description("Library")]
    Library = 89,

    [Description("Linux")]
    Linux = 90,

    [Description("Localization")]
    Localization = 91,

    [Description("Lua")]
    Lua = 92,

    [Description("Machine learning")]
    MachineLearning = 93,

    [Description("macOS")]
    Macos = 94,

    [Description("Markdown")]
    Markdown = 95,

    [Description("Mastodon")]
    Mastodon = 96,

    [Description("Material design")]
    MaterialDesign = 97,

    [Description("MATLAB")]
    Matlab = 98,

    [Description("Maven")]
    Maven = 99,

    [Description("Minecraft")]
    Minecraft = 100,

    [Description("Mobile")]
    Mobile = 101,

    [Description("Monero")]
    Monero = 102,

    [Description("MongoDB")]
    Mongodb = 103,

    [Description("Mongoose")]
    Mongoose = 104,

    [Description("Monitoring")]
    Monitoring = 105,

    [Description("MvvmCross")]
    Mvvmcross = 106,

    [Description("MySQL")]
    Mysql = 107,

    [Description("NativeScript")]
    Nativescript = 108,

    [Description("Nim")]
    Nim = 109,

    [Description("Natural language processing")]
    NaturalLanguageProcessing = 110,

    [Description("Node.js")]
    NodeJs = 111,

    [Description("NoSQL")]
    Nosql = 112,

    [Description("npm")]
    Npm = 113,

    [Description("Objective-C")]
    ObjectiveC = 114,

    [Description("OpenGL")]
    Opengl = 115,

    [Description("Operating system")]
    OperatingSystem = 116,

    [Description("P2P")]
    P2p = 117,

    [Description("Package manager")]
    PackageManager = 118,

    [Description("Language parsing")]
    LanguageParsing = 119,

    [Description("Perl")]
    Perl = 120,

    [Description("Phaser")]
    Phaser = 121,

    [Description("PHP")]
    Php = 122,

    [Description("PICO-8")]
    Pico8 = 123,

    [Description("Pixel Art")]
    PixelArt = 124,

    [Description("PostgreSQL")]
    Postgresql = 125,

    [Description("Project management")]
    ProjectManagement = 126,

    [Description("Publishing")]
    Publishing = 127,

    [Description("PWA")]
    Pwa = 128,

    [Description("Python")]
    Python = 129,

    [Description("Qt")]
    Qt = 130,

    [Description("R")]
    R = 131,

    [Description("Rails")]
    Rails = 132,

    [Description("Raspberry Pi")]
    RaspberryPi = 133,

    [Description("Ratchet")]
    Ratchet = 134,

    [Description("React")]
    React = 135,

    [Description("React Native")]
    ReactNative = 136,

    [Description("ReactiveUI")]
    Reactiveui = 137,

    [Description("Redux")]
    Redux = 138,

    [Description("REST API")]
    RestApi = 139,

    [Description("Ruby")]
    Ruby = 140,

    [Description("Rust")]
    Rust = 141,

    [Description("Sass")]
    Sass = 142,

    [Description("Scala")]
    Scala = 143,

    [Description("scikit-learn")]
    ScikitLearn = 144,

    [Description("Software-defined networking")]
    SoftwareDefinedNetworking = 145,

    [Description("Security")]
    Security = 146,

    [Description("Server")]
    Server = 147,

    [Description("Serverless")]
    Serverless = 148,

    [Description("Shell")]
    Shell = 149,

    [Description("Sketch")]
    Sketch = 150,

    [Description("SpaceVim")]
    Spacevim = 151,

    [Description("Spring Boot")]
    SpringBoot = 152,

    [Description("SQL")]
    Sql = 153,

    [Description("Storybook")]
    Storybook = 154,

    [Description("Support")]
    Support = 155,

    [Description("Swift")]
    Swift = 156,

    [Description("Symfony")]
    Symfony = 157,

    [Description("Telegram")]
    Telegram = 158,

    [Description("Tensorflow")]
    Tensorflow = 159,

    [Description("Terminal")]
    Terminal = 160,

    [Description("Terraform")]
    Terraform = 161,

    [Description("Testing")]
    Testing = 162,

    [Description("TypeScript")]
    Typescript = 163,

    [Description("Ubuntu")]
    Ubuntu = 164,

    [Description("Unity")]
    Unity = 165,

    [Description("Unreal Engine")]
    UnrealEngine = 166,

    [Description("Vagrant")]
    Vagrant = 167,

    [Description("Vim")]
    Vim = 168,

    [Description("Virtual reality")]
    VirtualReality = 169,

    [Description("Vue.js")]
    VueJs = 170,

    [Description("Wagtail")]
    Wagtail = 171,

    [Description("Web Components")]
    WebComponents = 172,

    [Description("Web app")]
    WebApp = 173,

    [Description("Webpack")]
    Webpack = 174,

    [Description("Windows")]
    Windows = 175,

    [Description("WordPlate")]
    Wordplate = 176,

    [Description("WordPress")]
    Wordpress = 177,

    [Description("Xamarin")]
    Xamarin = 178,

    [Description("XML")]
    Xml = 179,

    [Description("None")]
    None = 180,

    [Description(".t2")]
    T2 = 183,

    [Description("List")]
    List = 185,

    [Description("delete")]
    Delete = 186,

    [Description("Personal")]
    Personal = 187,

    [Description("Regex")]
    Regex = 188,
};
