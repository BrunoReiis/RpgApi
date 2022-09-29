using RpgApi.Data;
using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using Microsoft.EntityFrameworkCore;

namespace RpgApi.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class ArmasController : ControllerBase
    {
        private readonly DataContext _context;
        public ArmasController(DataContext context)
        {
            _context = context;            
        }

        [HttpGet("GetAll")]
         public async Task<IActionResult> Get()
         {
            try
            {
                List<Arma> lista = await _context.Armas.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
         }

        [HttpGet("{id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Arma a = await _context.Armas
                    .FirstOrDefaultAsync(aBusca => aBusca.Id == id);

                return Ok(a);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
         public async Task<IActionResult> Add(Arma novaArma)
         {
            try
            {
                if(novaArma.Dano > 30)
                {
                    throw new System.Exception("Dano da arma não pode ser maior de");
                }
                await _context.Armas.AddAsync(novaArma);
                await _context.SaveChangesAsync();

                return Ok(novaArma.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
         }

         [HttpPost]
         public async Task<IActionResult> AlterarArma(Arma novaArma)
         {
            try
            {
                _context.Armas.Update(novaArma);
                int alteracaoArma = await _context.SaveChangesAsync();

                return Ok(alteracaoArma);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
         }

         [HttpDelete("{id}")]
         public async Task<IActionResult> Delete(int id)
        { try
         {
            Arma aRemover = await _context.Armas
                .FirstOrDefaultAsync(a => a.Id == id);

            _context.Armas.Remove(aRemover);
            int linhasAfetadas = await _context.SaveChangesAsync();
            return Ok(linhasAfetadas);
         }
         catch (System.Exception ex)
         { 
            return BadRequest(ex.Message);
         }
        }
    }
}