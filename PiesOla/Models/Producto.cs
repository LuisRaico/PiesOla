using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiesOla.Models
{
    [Table("t_productos")]
    public class Producto
    {

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Display(Name="Identificador")] 
    [Column("id")]
    public int ID { get; set; }

    [Required(ErrorMessage="Debe ingresar el Codigo del producto a registrar")]
    [Display(Name="Codigo")] 
    [Column("Codigo")]
    public string Codigo { get; set; }

    [Required(ErrorMessage="Debe ingresar la Marca a registrar")]
    [Display(Name="Marca")] 
    [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Solo se permiten letras")]
    [Column("Marca")]
    public string Marca { get; set; }

    [Required(ErrorMessage="Debe ingresar la Talla registrar")]
    [Display(Name="Talla")] 
    [Column("Talla")]
    public int Talla { get; set; }

    [Required(ErrorMessage="Debe ingresar el Material a registrar")]
    [Display(Name="Material")] 
    [Column("Material")]
    public string Material { get; set; }

    [Required(ErrorMessage="Debe ingresar la Descripcion de la media a registrar")]
    [Display(Name="Descripcion de la prenda")] 
    [Column("Descripcion")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage="Debe ingresar el Color de la montura a registrar")]
    [Display(Name="Color del producto")] 
    [Column("Color")]
    public string Color { get; set; }

    [Required(ErrorMessage="Debe ingresar el numero de Stock a registrar")]
    [Display(Name="Stock de la prenda")] 
    [Column("Stock")]
    public int? Stock { get; set; }

    [Required(ErrorMessage="Debe ingresar el Precio a registrar")]
    [Display(Name="Precio del Prenda")] 
    [Column("Precio")]
    public Decimal Precio { get; set; }

    [Required(ErrorMessage="Debe ingresar la imagen de la Media registrar")]
    [Display(Name="URL de imagen de la Media")] 
    [Column("imagen")]
    public string imagen { get; set; }


    [NotMapped]
    public String Respuesta { get; set; }

    }
}