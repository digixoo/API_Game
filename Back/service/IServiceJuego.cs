using Back.Models.Response;
using Back.Models.Request;
using System.Collections.Generic;

namespace Back.service
{
    public interface IServiceJuego
    {
        IEnumerable<ResponseJuego> RetornaJuegos();

        ResponseJuego RetornaJuego(int id);

        void GuardaJuego(RequestJuego juego);

        void ActualizaJuego(int id, RequestJuego juego);

        void EliminaJuego(int id);

    }
}