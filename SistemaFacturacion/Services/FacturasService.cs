using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.DAL;
using SistemaFacturacion.Models;
using System.Linq.Expressions;

namespace SistemaFacturacion.Services;

public class FacturasService
{
	private readonly Contexto _contexto;

	public FacturasService(Contexto contexto)
	{
		_contexto = contexto;
	}

	public async Task<bool> Crear(Facturas factura)
	{
		if (!await Existe(factura.FacturaId))
			return await Insertar(factura);
		else
			return await Modificar(factura);
	}

	public async Task<bool> Existe(int id)
	{
		return await _contexto.Facturas
			.AnyAsync(c => c.FacturaId == id);
	}

	public async Task<bool> Insertar(Facturas factura)
	{
		_contexto.Facturas.Add(factura);
		return await _contexto.SaveChangesAsync() > 0;
	}

	public async Task<bool> Modificar(Facturas factura)
	{
		_contexto.Update(factura);
		var modifico = await _contexto.SaveChangesAsync() > 0;
		_contexto.Entry(factura).State = EntityState.Detached;
		return modifico;
	}

	public async Task<bool> Eliminar(int id)
	{
		var cantidad = await _contexto.Facturas
			.Where(c => c.FacturaId == id)
			.ExecuteDeleteAsync();

		return cantidad > 0;
	}

	public async Task<Facturas?> Buscar(int id)
	{
		return await _contexto.Facturas
			.Include(f => f.FacturaDetalle)
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.FacturaId == id);
	}

	public async Task<List<Facturas>> Listar(Expression<Func<Facturas, bool>> criterio)
	{
		return await _contexto.Facturas
			.Include(f => f.FacturaDetalle)
			.AsNoTracking()
			.Where(criterio)
			.ToListAsync();
	}
}
