using Gherghelas_Theodora_Lab7.Models;


namespace Gherghelas_Theodora_Lab7;

public partial class ShopPage : ContentPage
{
	public ShopPage()
	{
		InitializeComponent();
	}

	async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		var shop = (Shop)BindingContext;
		await App.Database.SaveShopListAsync(Shop);
		await Navigation.PopAsync();
	}

	async void OnShowMapButtonClicked(object sender, EventArgs e)
	{
		var shop = (Shop)BindingContext;
		var adress = shop.Adress;
		var locations = await Geocoding.GetLocationsAsync(adress);

		var options = new MapLaunchOptions { Name = "Magazinul meu preferat" };

		var location = locations?.FirstOrDefault();

		//var myLocation = await Geolocation.GetLocationAsync();
		var myLocation = new Location(46.731796289, 23.6213886738);

		await Map.OpenAsync(location, options);
	}
}