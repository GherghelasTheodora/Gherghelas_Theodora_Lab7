using Gherghelas_Theodora_Lab7.Models;

namespace Gherghelas_Theodora_Lab7;

public partial class ProductPage : ContentPage
{
	ShopList sl;
	public ProductPage(ShopList slist)
	{
		InitializeComponent();
		sl = slist;
	}

	async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		var product = (Product)BindingContext;
		await App.Database.SaveProductAsync(product);
		listView.ItemsSource = await App.Database.GetProductsAsync();
	}

	async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		var product = (Product)BindingContext;
		await App.Database.DeleteProductAsync(product);
		listView.ItemsSource = await App.Database.GetProductsAsync();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		listView.ItemsSource = await App.Database.GetProductsAsync();
	}

	async void OnAddButtonClicked(object sender, EventArgs e)
	{
		Product p;
		if (listView.SelectedItem !=null)
		{
			p = listView.SelectedItem as Product;
			var lp = new ListProduct()
			{
				ShopListID = sl.ID,
				ProductID = p.ID
			};

			await App.Database.SaveListProductAsync(lp);
			p.ListProduct = new List<ListProduct> { lp };
			await Navigation.PopAsync();
		}
	}

async void OnDeleteItemClicked(object sender, EventArgs e)
	{
		var productToDelete= await App.Database.GetProductsAsync();
		if (productToDelete != null)
		{
			await App.Database.DeleteProductAsync(productToDelete);
			listView.ItemsSource = await App.Database.GetProductsAsync();
		}
	
	}
    
}