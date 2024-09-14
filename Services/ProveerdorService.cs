using CRUD_Proveedores.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Proveedores.Services
{
    public class ProveerdorService
    {
        private readonly SQLiteConnection dbConecction;

        public ProveerdorService() 
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedor.db3");

            dbConecction = new SQLiteConnection(dbPath);

            dbConecction.CreateTable<Proveedor>();

        }

        public List<Proveedor> GetAll()
        {
            var res = dbConecction.Table<Proveedor>().ToList();
            return res;

        }

        public int Insert(Proveedor proveedor)
        {

            return dbConecction.Insert(proveedor);

        }

        public int Update(Proveedor proveedor)
        {

            return dbConecction.Update(proveedor);

        }

        
        public int Delete(Proveedor proveedor)
        {

            return dbConecction.Delete(proveedor);

        }



    }
}
