namespace MauiAppHotel.Views;

public partial class aa : ContentPage
{
	public aa()
	{
		InitializeComponent();
	}
    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "Ok");
        }

    }
    private void Button_Clicked_1(object sender, EventArgs e)
    {

    }
}