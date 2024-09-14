using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUD_Proveedores.Models;
using CRUD_Proveedores.Services;
using CRUD_Proveedores.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Proveedores.ViewModels
{
    public partial class ProveedorMainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Proveedor> proveedorCollection = new ObservableCollection<Proveedor>();

        private readonly ProveedorService ProveedorService;

        public ProveedorMainViewModel()
        {
            //cuando instancie un nuevo objeto, tambien se inicializa proveedor service
            ProveedorService = new ProveedorService();

        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        //metodo que llama a la lista que esta es la proveedor service para agregarregistros
        public void GetAll()
        {
            var getAll = ProveedorService.GetAll();

            //si la lista tiene registros
            if (getAll.Count > 0)
            {
                ProveedorCollection.Clear();

                foreach (var proveedor in getAll)
                {
                    ProveedorCollection.Add(proveedor);

                }


            }

        }

        //configura los botones y los enlaza con las vistas

        [RelayCommand]

        private async Task goToAddProveedorForm()
        {
            //enlaza a la vista xaml.cs vista agregar y editar producto
            await App.Current!.MainPage!.Navigation.PushAsync(new AddProveedorForm());

        }

        //llamas a los metodos que estab en el service

        [RelayCommand]

        private async Task SelectProveedor(Proveedor proveedor)
        {
            try
            {
                string actualizar = "Actualizar";
                string eliminar = "Eliminar";
                //alerta de consulta y dicha alerta trae una respuesta
                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, actualizar, eliminar);

                if (res == actualizar)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new AddProveedorForm(proveedor));

                }
                else if (res == eliminar)
                {
                    //si elige eliminar despliega una alerta si realmente quiere eliminar
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR PROVEEDOR", "Desea eliminar el registro del proveedor", "Si", "No");

                    //si la respuesta es true, borra el empleado, si se efectua lo elimina de la lista.
                    if (respuesta)
                    {
                        int del = ProveedorService.Delete(proveedor);

                        if (del > 0)
                        {
                            ProveedorCollection.Remove(proveedor);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }


        }

    }

}
