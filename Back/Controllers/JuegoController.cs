using Back.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Back.service;
using Back.Models.Request;

namespace Back.Controllers
{
    public class JuegoController : ApiController
    {
        private readonly IServiceJuego _service;
        public JuegoController(IServiceJuego service)
        {
            _service = service;
        }

        // GET: api/Juego
        public IEnumerable<ResponseJuego> Get()
        {
            return _service.RetornaJuegos();
        }

        // GET: api/Juego/5
        public ResponseJuego Get(int id)
        {
            return _service.RetornaJuego(id);
        }

        // POST: api/Juego
        public HttpResponseMessage Post([FromBody]RequestJuego juego)
        {
            _service.GuardaJuego(juego);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT: api/Juego/5
        public HttpResponseMessage Put(int id, [FromBody]RequestJuego value)
        {
            _service.ActualizaJuego(id, value);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // DELETE: api/Juego/5
        public HttpResponseMessage Delete(int id)
        {
            _service.EliminaJuego(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
