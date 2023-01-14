using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataContext;

namespace Buinness.Servicios
{
    public interface IBalerosService
    {
        Task<bool> Insertar(Balero modelo);
        Task<bool> Actualizar(Balero modelo);
        Task<bool> Eliminar(int id);
        Task<Balero> Obtener(int id);
        Task<IQueryable<Balero>> ObtenerTodos();
    }
}
