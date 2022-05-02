using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.DataAccess;
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
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            var result = context.Categorias.ToList();
            return Ok(result);
        }
    }
}
