using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaFacturacion.Models;

public class FacturasDetalle
{
	[Key]
	public int FacturaDetalleId { get; set; }

    public int FacturaId { get; set; }

	[ForeignKey("Productos")]
	public int ProductoId { get; set; }

	[Range(1, 1000, ErrorMessage = "Debe elegir una cantidad entre 1 y 10,000")]
	public int Cantidad { get; set; }

	public decimal PrecioVenta { get; set; }

    public decimal Impuesto { get; set; }
    public decimal SubTotal { get; set; }
    public Productos Productos { get; set; }
}
