using MauiAppHotel.Models;
using Microsoft.Maui.Controls;
using System.Data;
namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	App PropriedadesApp;

	public ContratacaoHospedagem()
	{
		InitializeComponent();

		PropriedadesApp = (App)Application.Current;

		pck_quarto.ItemsSource = PropriedadesApp.Lista_quartos;

		dtpck_checkin.MinimumDate = DateTime.Now;
		dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);
		dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
		dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);

	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		try
		{

			Hospedagem h = new Hospedagem
			{
				 QuartoSelecionado = (Quarto)pck_quarto.SelectedItem,
				 QtdAdultos = Convert.ToInt32(stp_adultos.Value),
                QtdCriancas = Convert.ToInt32(stp_criancas.Value),
                QtdPetz = Convert.ToInt32(stp_petz.Value),
				DataCheckIn = dtpck_checkin.Date,
				DataCheckOut = dtpck_checkout.Date,
            };



			await Navigation.PushAsync(new HospedagemContratada()
			{
				BindingContext = h 
			});


		} catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK");
		}

	}

	private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
	{
		DatePicker elemento = sender as DatePicker;

		DateTime data_selecionada_Checkin = elemento.Date;

		dtpck_checkout.MinimumDate = data_selecionada_Checkin.AddDays(1);
        dtpck_checkout.MaximumDate= data_selecionada_Checkin.AddMonths(6);


    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new Sob());
		}catch (Exception ex)
		{

		}
    }
}

