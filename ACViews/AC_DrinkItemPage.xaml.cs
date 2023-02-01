using AmelyCordova_ExamenFinal.ACModels;

namespace AmelyCordova_ExamenFinal.ACViews;

public partial class DrinkItemPage : ContentPage
{
    public Drink Item
    {
        get => BindingContext as Drink;
        set => BindingContext = value;
    }
    public DrinkItemPage()
	{
		InitializeComponent();
	}

    private void AC_OnSaveClicked(object sender, EventArgs e)
    {
        Item.ACcreationDate = DateTime.Parse(fuente.Text);
        App.DrinkRepo.AC_AddNewItem(Item);
        Shell.Current.GoToAsync("..");
    }

    private void AC_OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void AC_OnDeleteClicked(object sender, EventArgs e)
    {
        App.DrinkRepo.AC_DeleteItem(Item);
        Shell.Current.GoToAsync("..");
    }
}