using System.Linq;
using System.Collections.Generic;

namespace Ejemplo01.Models
{
    public class MockAmigoRepositorio: IAmigoAlmacen
    {
        private List<Amigo> amigosLista;

        public MockAmigoRepositorio()
        {
            amigosLista = new List<Amigo>();

            amigosLista.Add(new Amigo() {
                Id = 1,
                Nombre = "chris",
                Ciudad = Provincia.Lima,
                Email = "outlook@correo.com"
            });

            amigosLista.Add(new Amigo() {
                Id = 2,
                Nombre = "damon",
                Ciudad = Provincia.Lima,
                Email = "gmail@correo.com"
            });
        }

        public Amigo DameDatosAmigo(int id) =>
            amigosLista.FirstOrDefault(e => e.Id == id);

        public  List<Amigo> DameTodosLosAmigos() => 
            amigosLista;

        public  Amigo Nuevo(Amigo amigo) 
        {
            amigo.Id = amigosLista.Max(a => a.Id) + 1;
            amigosLista.Add(amigo);
            return amigo;
        }

        public  Amigo Modificar(Amigo amigo) 
        {
            Amigo _amigo = DameDatosAmigo(amigo.Id);
            if (_amigo != null)
            {
                _amigo.Nombre = amigo.Nombre;
                _amigo.Email = amigo.Email;
                _amigo.Ciudad = amigo.Ciudad;
            }
            return _amigo;
        }

        public  Amigo Borrar(int id) 
        {
            Amigo _amigo = DameDatosAmigo(id);
            if (_amigo != null) amigosLista.Remove(_amigo);
            return _amigo;
        }
            
    }
}