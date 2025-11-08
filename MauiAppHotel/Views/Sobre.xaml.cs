namespace MauiAppHotel.Views;

public partial class Sobre : ContentPage
{
    public Sobre()
    {
        InitializeComponent();
    }
       private async void button_clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ContratacaoHospedagem());
    }
}
