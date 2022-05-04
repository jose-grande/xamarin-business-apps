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
    public class CategoriasController : ControllerBase
    {
        private readonly NoticiasDbContext context;

        public CategoriasController(NoticiasDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CategoriaView>> Get()
        {
            //Linq
            var result = from c in context.Categorias
                         select new CategoriaView
                         {
                             CategoriaId=c.CategoriaId,
                             Nombre=c.Nombre
                         };
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult<CategoriaView> Get(Guid id)
        {
            Categoria categoria = context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
            if (categoria == null)
            {
                return NotFound();
            }
            var result = new CategoriaView
            {
                CategoriaId=categoria.CategoriaId,
                Nombre=categoria.Nombre
            };
            return Ok(result);
        }
        [HttpGet("search")]
        public ActionResult<IEnumerable<CategoriaView>> Search(string searchTerm)
        {
            var result = from c in context.Categorias
                         where c.Nombre.Contains(searchTerm)
                         select new CategoriaView
                         {
                             CategoriaId=c.CategoriaId,
                             Nombre=c.Nombre
                         };
            return Ok(result);
        }
        [HttpPost]
        public ActionResult<CategoriaView> Post(CategoriaView categoria)
        {
            if(Guid.Empty == categoria.CategoriaId)
            {
                ModelState.AddModelError("CategoriaId", "El guid especificado no es válido");
            }
            var existing = context.Categorias.FirstOrDefault(c => c.Nombre.Equals(categoria.Nombre));
            if (existing != null)
            {
                ModelState.AddModelError("", "Ya existe una categoria con el nombre especificado");
            }
            if (ModelState.IsValid)
            {
                Categoria entity = new Categoria
                {
                    CategoriaId = categoria.CategoriaId,
                    Nombre = categoria.Nombre,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    UsuarioCreacion = "admin",
                    UsuarioModificacion = "admin"
                };
                context.Categorias.Add(entity);
                context.SaveChanges();
                return Created($"api/categorias/{categoria.CategoriaId}", categoria);
            }
            return UnprocessableEntity(ModelState);
        }
        [HttpPut]
        public ActionResult Put(CategoriaView categoria)
        {
            var entity = context.Categorias.FirstOrDefault(c => c.CategoriaId == categoria.CategoriaId);
            if (entity == null) return NotFound();

            if (ModelState.IsValid)
            {
                entity.Nombre = categoria.Nombre;
                entity.UsuarioModificacion = "admin";
                entity.FechaModificacion = DateTime.Now;
                context.SaveChanges();
                return NoContent();
            }
            return UnprocessableEntity(ModelState);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var entity = context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
            if (entity == null) return NotFound();
            context.Categorias.Remove(entity);
            context.SaveChanges();
            return NoContent();
        }
    }
}
