using QuitoText_1._0.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuitoText_1._0.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PRO_ID { get; set; }
        [Display(Name = "Categoria: ")]
        public int CATE_ID { get; set; }
        [Display(Name = "Nombre: ")]
        public string PRO_NOMBRE { get; set; }
        [Display(Name = "Descripción: ")]
        public string PRO_DESCRIPCION { get; set; }
        [Display(Name = "Precio: ")]
        public decimal PRO_PRECIO { get; set; }
        [Display(Name = "Stock: ")]
        public int PRO_STOCK { get; set; }
        [Display(Name = "Imagen: ")]
        public byte[] PRO_IMAGEN { get; set; }
        public virtual CATEGORIA CATEGORIA { get; set; }
    }
}