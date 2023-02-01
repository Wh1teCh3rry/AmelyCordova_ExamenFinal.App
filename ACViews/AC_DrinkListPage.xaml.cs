using AmelyCordova_ExamenFinal.ACModels;

namespace AmelyCordova_ExamenFinal.ACViews;

public partial class AC_DrinkListPage : ContentPage
{
	public AC_DrinkListPage()
	{
		InitializeComponent();
        BindingContext = this;
    }

    private void AC_LoadData()
    {
        List<Drink> drink = App.DrinkRepo.AC_GetAll();
        ACdrinkList.ItemsSource = drink;
        drink = App.DrinkRepo.AC_GetAll();
        ACdrinkList.ItemsSource = drink;
    }

    protected override void OnAppearing()
    {
        AC_LoadData();
    }

    public void AC_OnItemAdded(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(DrinkItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new Drink()
        });
        base.OnAppearing();
    }

    async void AC_CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Drink drink = new Drink();
        drink = ACdrinkList.SelectedItem as Drink;

        await Shell.Current.GoToAsync(nameof(DrinkItemPage), true, new Dictionary<string, object>()
        {
            ["Item"] = drink
        });
    }
}