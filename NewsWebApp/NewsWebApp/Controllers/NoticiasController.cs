using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.DataAccess;
using NewsWebApp.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        private readonly NoticiasDbContext context;

        public NoticiasController(NoticiasDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<NoticiaDto>> Conslultar()
        {
            var result = from n in context.Noticias
                         select new NoticiaDto
                         {
                             CategoriaId = n.CategoriaId,
                             Cuerpo = n.Cuerpo,
                             FechaPublicacion = n.FechaPublicacion,
                             NoticiaId = n.NoticiaId,
                             Titulo = n.Titulo
                         };
            return Ok(result);
        }
        [HttpGet("{noticiaId}")]
        public ActionResult<NoticiaDto> ConsultarNoticia(Guid noticiaId)
        {
            var entity = context.Noticias.FirstOrDefault(c => c.NoticiaId == noticiaId);
            if (entity == null) return NotFound();
            var result = new NoticiaDto
            {
                CategoriaId = entity.CategoriaId,
                Cuerpo = entity.Cuerpo,
                FechaPublicacion = entity.FechaPublicacion,
                NoticiaId = entity.NoticiaId,
                Titulo = entity.Titulo
            };
            return Ok(result);
        }
        [HttpPost]
        public ActionResult<NoticiaDto> AgregarNoticia(NoticiaDto noticia)
        {
            //Agregar validaciones
            if (ModelState.IsValid)
            {
                var entity = new Noticia
                {
                    CategoriaId = noticia.CategoriaId,
                    Cuerpo = noticia.Cuerpo,
                    Titulo = noticia.Titulo,
                    FechaPublicacion = noticia.FechaPublicacion,
                    FechaCreacion = DateTime.Now,
                    UsuarioCreacion = "admin",
                    FechaModificacion = DateTime.Now,
                    UsuarioModificacion = "admin"
                };
                context.Noticias.Add(entity);
                context.SaveChanges();
                return Ok();
            }
            return UnprocessableEntity(ModelState);
        }
        [HttpPut("{noticiaId}")]
        public ActionResult ModificarNoticia(Guid noticiaId, NoticiaDto noticia)
        {
            if (noticiaId != noticia.NoticiaId) return BadRequest();
            var entity = context.Noticias.FirstOrDefault(c => c.NoticiaId == noticiaId);
            if (entity == null) return NotFound();
            if (ModelState.IsValid)
            {
                entity.Titulo = noticia.Titulo;
                entity.Cuerpo = noticia.Cuerpo;
                entity.FechaPublicacion = noticia.FechaPublicacion;
                entity.FechaModificacion = DateTime.Now;
                entity.UsuarioModificacion = "admin";
                context.SaveChanges();
                return NoContent();
            }
            return UnprocessableEntity(ModelState);
        }
    }
}
