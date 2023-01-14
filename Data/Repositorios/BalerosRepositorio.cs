using Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Repositorios
{
    public class BalerosRepositorio: IRepositorioGenerico<Balero>
    {
        private readonly MvcPruebasContext _mvcPruebasContext;

        public BalerosRepositorio(MvcPruebasContext context)
        {
            _mvcPruebasContext = context;
        }

        public async Task<bool> Actualizar(Balero modelo)
        {
            _mvcPruebasContext.Baleros.Update(modelo);
            await _mvcPruebasContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Balero modelo = _mvcPruebasContext.Baleros.First(x=> x.IdBaleros==id);
            _mvcPruebasContext.Baleros.Remove(modelo);
            await _mvcPruebasContext.SaveChangesAsync() ;
            return true;
        }

        public async Task<bool> Insertar(Balero modelo)
        {
            _mvcPruebasContext.Baleros.Add(modelo);
            await _mvcPruebasContext.SaveChangesAsync();
            return true;
        }

        public async Task<Balero> Obtener(int id)
        {
            return await _mvcPruebasContext.Baleros.FindAsync(id);
        }

        public async Task<IQueryable<Balero>> ObtenerTodos()
        {
            IQueryable<Balero> querySQL = _mvcPruebasContext.Baleros;
            return querySQL;
        }
    }
}
