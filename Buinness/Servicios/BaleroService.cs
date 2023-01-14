using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataContext;
using Data.Repositorios;

namespace Buinness.Servicios
{
    public class BaleroService : IBalerosService
    {
        public readonly IRepositorioGenerico<Balero> _repoGenerico;

        public BaleroService(IRepositorioGenerico<Balero> BaleroRepo)
        {
            _repoGenerico = BaleroRepo;
        }

        public async Task<bool> Actualizar(Balero modelo)
        {
            return await _repoGenerico.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _repoGenerico.Eliminar(id);
        }

        public async Task<bool> Insertar(Balero modelo)
        {
            return await _repoGenerico.Insertar(modelo);
        }

        public async Task<IQueryable<Balero>> ObtenerTodos()
        {
            return await _repoGenerico.ObtenerTodos();
        }

        public async Task<Balero> Obtener(int id)
        {
            return await _repoGenerico.Obtener(id);
        }
    }
}
