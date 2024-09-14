using CRUD_Proveedores.Views;

namespace CRUD_Proveedores
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProveedorMain());
        }
    }
}
