namespace TP2_.net.Views;

public partial class APropos : ContentPage
{
	public APropos()
	{
		InitializeComponent();
	}

    private async void APropos_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.CAPropos apropos)
        {
            await Launcher.Default.OpenAsync(apropos.MoreInfoUrl);
        }

    }
}