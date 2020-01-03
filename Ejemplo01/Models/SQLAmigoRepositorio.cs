using System.Collections.Generic;
using System.Linq;

namespace Ejemplo01.Models
{
    public class SQLAmigoRepositorio : IAmigoAlmacen
    {
        private readonly AppDbContext contexto;
        private List<Amigo> amigosLista;

        public SQLAmigoRepositorio(AppDbContext contexto)
        {
            this.contexto = contexto;
        }

        public Amigo Nuevo(Amigo amigo)
        {
            contexto.Amigos.Add(amigo);
            contexto.SaveChanges();
            return amigo;
        }

        public Amigo Borrar(int id)
        {
            Amigo _amigo = DameDatosAmigo(id);
            if (_amigo != null)
            {
                contexto.Amigos.Remove(_amigo);
                contexto.SaveChanges();
            }
            return _amigo;
        }

        public Amigo DameDatosAmigo(int id)
        {
            return contexto.Amigos.Find(id);
        }

        public List<Amigo> DameTodosLosAmigos()
        {
            amigosLista = contexto.Amigos.ToList<Amigo>();
            return amigosLista;
        }

        public Amigo Modificar(Amigo amigo)
        {
            var _amigo = contexto.Amigos.Attach(amigo);
            _amigo.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges();
            return amigo;
        }
    }
}