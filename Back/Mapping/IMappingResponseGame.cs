using Back.Models.Response;
using System.Collections.Generic;

namespace Back.Mapping
{
    interface IMappingResponseGame
    {
        ResponseJuego Juego { get; }
        IEnumerable<ResponseJuego> Juegos { get; }
    }
}
