using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuitoText_1._0.Models
{
    public class ProductosAlCarro : IEquatable<ProductosAlCarro>
    {
       public int Cantidad { get; set; }
        private int _IdProducto;
        private Producto prod = null;

        public int IdProducto
        {
            get { return _IdProducto; }
            set
            {
                prod = null;
                _IdProducto = value;
            }
        }
        public Producto Producto
        {
            get
            {
                if (prod == null)
                {
                    prod = new Producto();
                }
                return prod;
            }
        }

        public bool Equals(ProductosAlCarro other)
        {
            throw new NotImplementedException();
        }

        /*public decimal PrecioUnitario
        {
            get { return Producto.PRO_PRECIO; }
        }
        public decimal Total
        {
            get { return PrecioUnitario * Cantidad; }
        }


        public ProductosAlCarro(int pId)
        {
            IdProducto = pId;
        }
        public bool Equals(ProductosAlCarro pItem)
        {
            return pItem.IdProducto == IdProducto;
        }*/
    }
}