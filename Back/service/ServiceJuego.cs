using Back.Exceptions;
using Back.Mapping;
using Back.Models;
using Back.Models.Request;
using Back.Models.Response;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;

namespace Back.service
{
    public class ServiceJuego : IServiceJuego
    {

        private ICatalogoContext _db;
        public ServiceJuego()
        {
            _db = new CatalogoContext();
        }

        public ServiceJuego(ICatalogoContext context)
        {
            _db = context;
        }

        public void GuardaJuego(RequestJuego juego)
        {
            try
            {
                _db.Juegos.Add(
                    new Juego()
                    {
                        Nombre = juego.Nombre,
                        TipoGenero = _db.Generos.Where(g => g.Id == juego.Genero).First()
                    });

                _db.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw new HttpException(new List<string> { "No fue posible guardar el juego" }, HttpStatusCode.BadRequest);
            }
        }

        public IEnumerable<ResponseJuego> RetornaJuegos()
        {
            IMappingResponseGame mapping;

            var modelJuegos = _db.Juegos.Include(x => x.TipoGenero).ToList();

            mapping = new MappingResponseGame(modelJuegos);

            return mapping.Juegos;

        }

        public ResponseJuego RetornaJuego(int id)
        {
            IMappingResponseGame mapping;
            try
            {
                var modelJuegos = _db.Juegos.Include(x => x.TipoGenero).Where(x => x.Id == id).FirstOrDefault();
                mapping = new MappingResponseGame(modelJuegos);

                return mapping.Juego;
            }
            catch (NullReferenceException)
            {
                throw new HttpException(HttpStatusCode.NotFound);
            }
        }

    }
}