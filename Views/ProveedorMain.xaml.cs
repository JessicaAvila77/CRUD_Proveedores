
using CRUD_Proveedores.ViewModels;

namespace CRUD_Proveedores.Views;

public partial class ProveedorMain : ContentPage
{
	private ProveedorMainViewModel ViewModel;

	public ProveedorMain()
	{
		InitializeComponent();
		ViewModel = new ProveedorMainViewModel();
		this.BindingContext = ViewModel;

	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.GetAll();
    }


}