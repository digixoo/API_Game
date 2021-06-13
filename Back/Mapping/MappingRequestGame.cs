using Back.Models;
using Back.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Back.Mapping
{
    public class MappingRequestGame : IMappingRequestGame
    {
        private IEnumerable<RequestJuego> _juegos;

        public MappingRequestGame(RequestJuego juego)
        {
            _juegos = new List<RequestJuego>() { juego };
        }
        public MappingRequestGame(IEnumerable<RequestJuego> juegos)
        {
            _juegos = juegos;
        }

        public Juego Juego
        {
            get
            {
                var game = _juegos.FirstOrDefault();

                return new Juego()
                {                    
                    Nombre = game.Nombre                   
                };
            }
        }
    }
}