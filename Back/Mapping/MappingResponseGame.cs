using Back.Models.Response;
using Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Back.Mapping
{
    public class MappingResponseGame : IMappingResponseGame
    {
        private IEnumerable<Juego> _juegos;

        public MappingResponseGame(Juego juego)
        {
            _juegos = new List<Juego>() { juego };
        }
        public MappingResponseGame(IEnumerable<Juego> juegos)
        {
            _juegos = juegos;
        }

        public ResponseJuego Juego
        {
            get
            {
                var game = _juegos.FirstOrDefault();

                return new ResponseJuego()
                {
                    Id = game.Id.ToString(),
                    Nombre = game.Nombre,
                    Genero = game.TipoGenero.Nombre
                };
            }
        }
        public IEnumerable<ResponseJuego> Juegos
        {
            get
            {
                return _juegos.Select(j => new ResponseJuego() { Id = j.Id.ToString(), Genero = j.TipoGenero.Nombre, Nombre = j.Nombre });
            }
        }
    }
}