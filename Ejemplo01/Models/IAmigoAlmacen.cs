using System.Collections.Generic;

namespace Ejemplo01.Models
{
    public interface IAmigoAlmacen
    {
        Amigo DameDatosAmigo(int id);

        List<Amigo> DameTodosLosAmigos();

        Amigo Nuevo(Amigo amigo);

        Amigo Modificar(Amigo amigo);

        Amigo Borrar(int id);
    }
}