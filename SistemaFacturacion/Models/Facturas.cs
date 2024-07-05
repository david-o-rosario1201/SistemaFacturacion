using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion.Models;

public class Facturas
{
    [Key]
    public int FacturaId { get; set; }

	[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
	public DateTime FechaCreacion { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Debe ingresar un nombre para el cliente")]
    public string NombreCliente { get; set; }

    [Required(ErrorMessage = "Debe ingresar una dirección para el cliente")]
    public string Direccion { get; set; }

    [Required(ErrorMessage = "Debe ingresar un teléfono para el cliente")]
    public string Telefono { get; set; }

    [Required(ErrorMessage = "Debe ingresar un email para el cliente")]
    public string Email { get; set; }


    [ForeignKey("FacturaId")]
	public ICollection<FacturasDetalle> FacturaDetalle { get; set; } = new List<FacturasDetalle>();
}
