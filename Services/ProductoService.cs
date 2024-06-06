using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PC4.Models;

namespace PC4.Services
{
    public class ProductoService
    {
        public List<Producto> getTrendingProductos() {
            List<Producto> result = new List<Producto>
            {
                new Producto { ProductoId = 1, ProductoNombre = "Big Mac" },
                new Producto { ProductoId = 2, ProductoNombre = "Whopper" },
                new Producto { ProductoId = 3, ProductoNombre = "Pollo Frito" },
                new Producto { ProductoId = 4, ProductoNombre = "Pizza" },
                new Producto { ProductoId = 5, ProductoNombre = "Hamburguesa" },
                new Producto { ProductoId = 6, ProductoNombre = "Papas Fritas" }
            };

            return result;
        }

        public List<Producto> getAllProductos() {
            List<Producto> result = new List<Producto>
            {
                new Producto { ProductoId = 1, ProductoNombre = "Big Mac" },
                new Producto { ProductoId = 2, ProductoNombre = "Whopper" },
                new Producto { ProductoId = 3, ProductoNombre = "Pollo Frito" },
                new Producto { ProductoId = 4, ProductoNombre = "Taco" },
                new Producto { ProductoId = 5, ProductoNombre = "Rebanada de Pizza" },
                new Producto { ProductoId = 6, ProductoNombre = "Sándwich Submarino" },
                new Producto { ProductoId = 7, ProductoNombre = "Papas Fritas" },
                new Producto { ProductoId = 8, ProductoNombre = "Perro Caliente" },
                new Producto { ProductoId = 9, ProductoNombre = "Nuggets de Pollo" },
                new Producto { ProductoId = 10, ProductoNombre = "Sándwich de Pescado" },
                
            };

            return result;
        }
    }
}