//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuitoText_1._0.Datos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            this.USUARIO = new HashSet<USUARIO>();
        }
    
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
        public byte[] PRO_IMAGEN2 { get; set; }
        public byte[] PRO_IMAGEN3 { get; set; }
        public byte[] PRO_IMAGEN4 { get; set; }
        public byte[] PRO_IMAGEN5 { get; set; }
    
        public virtual CATEGORIA CATEGORIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }
    }
}
