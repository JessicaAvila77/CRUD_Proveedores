using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD_Proveedores.Models;
using CRUD_Proveedores.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Proveedores.ViewModels
{
    public partial class AddProveedorFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string telefono;

        [ObservableProperty]
        private string direccion;

        private readonly ProveedorService ProveedorService;

        public AddProveedorFormViewModel()
        {
            ProveedorService = new ProveedorService();
        }

        public AddProveedorFormViewModel(Proveedor Proveedor)
        {
            ProveedorService = new ProveedorService();
            Id = Proveedor.Id;
            Nombre = Proveedor.Nombre;
            Email = Proveedor.Email;
            Telefono = Proveedor.Telefono;
            Direccion = Proveedor.Direccion;

        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]

        private async Task AddUpdate()
        {
            try
            {
                Proveedor Proveedor = new Proveedor()
                {
                    Id = Id,
                    Nombre = Nombre,
                    Email = Email,
                    Telefono = Telefono,
                    Direccion = Direccion                  
                };

                if (Validar(Proveedor))
                {
                    if (Id == 0)
                    {
                        ProveedorService.Insert(Proveedor);
                    }
                    else
                    {
                       ProveedorService.Update(Proveedor);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }





            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }

        }

        //validando campos not null

        private bool Validar(Proveedor Proveedor)
        {
            if (Proveedor.Nombre == null || Proveedor.Nombre == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el nombre completo");
                return false;
            }
            else if (Proveedor.Email == null || Proveedor.Email == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el correo electrónico");
                return false;

            }
            else if (Proveedor.Telefono == null || Proveedor.Telefono == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el teléfono del proveedor");
                return false;

            }
            else
            {
                return true;
            }


        }

    }
}
