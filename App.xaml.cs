using AmelyCordova_ExamenFinal.ACData;
namespace AmelyCordova_ExamenFinal;

public partial class App : Application
{
    public static AC_CockatailDatabase DrinkRepo { get; set; }

    public App(AC_CockatailDatabase repo)
    {
        InitializeComponent();

        MainPage = new AppShell();
        DrinkRepo = repo;
    }
}