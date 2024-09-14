using CRUD_Proveedores.Models;
using CRUD_Proveedores.ViewModels;


namespace CRUD_Proveedores.Views;

public partial class AddProveedorForm : ContentPage
{
    private AddProveedorFormViewModel ViewModel;

    public AddProveedorForm()
	{
        InitializeComponent();
        ViewModel = new AddProveedorFormViewModel();
        BindingContext = ViewModel;

     }

    public AddProveedorForm(Proveedor proveedor)
    {
        InitializeComponent();
        ViewModel = new AddProveedorFormViewModel(proveedor);
        BindingContext = ViewModel;

    }


}