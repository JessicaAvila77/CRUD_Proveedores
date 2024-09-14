using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Proveedores.Models
{
    public class Proveedor
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        [NotNull]
        public string Nombre { get; set; }

        [NotNull]
        public string Email { get; set; }

        [NotNull]
        public string Telefono { get; set; }

        public string Direccion { get; set; }
    }
}
