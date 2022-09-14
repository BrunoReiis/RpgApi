using Microsoft.AspNetCore.Mvc;
using RpgApi.Models;
using RpgApi.Models.Enums;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensExercicioController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>() {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro}, 
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };

        [HttpGet("GetByClasse/{id}")]
        public IActionResult GetByClasse(int id){

            List<Personagem> listaFinal = personagens.FindAll(personagem => ((int)personagem.Classe) == id);  
            return Ok(listaFinal);
        }

        [HttpGet("GetByNome/{nome}")]
        public IActionResult GetByNome(string nome){

            Personagem ListaGetNome = personagens.Find(personagem => personagem.Nome == nome);

            if(ListaGetNome == null){
                return NotFound("Nome incorreto");
            }

            return Ok(ListaGetNome);
        }


        [HttpPost("PostValidacao")]
    public IActionResult PostValidacao(Personagem novoPersonagem)
    {
        if (novoPersonagem.Defesa < 10)
            return BadRequest("Defesa abaixo de 10");

        if (novoPersonagem.Inteligencia > 30)
            return BadRequest("Inteligencia maior que 30");
        
        personagens.Add(novoPersonagem);
        return Ok(personagens);
    }

        [HttpPost("PostValidacaoMago")]
        public IActionResult PostValidacaoMago(Personagem novoPersonagem){

            if (novoPersonagem.Classe == ClasseEnum.Mago){
                if (novoPersonagem.Inteligencia <= 35)
                    return BadRequest("Mago deve possuir inteligencia maior ou igual a 35.");
            }

            personagens.Add(novoPersonagem);
            return Ok(personagens);
        }

         [HttpGet("GetClerigoMago")]
        public IActionResult GetClerigoMago(){

            personagens.RemoveAll(personagem => personagem.Classe == ClasseEnum.Cavaleiro);  
            return Ok(personagens.OrderByDescending(personagem => personagem.PontosVida));
        }

        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas(){
            
            string estatisticas = "Atualmente temos: " + personagens.Count + " personagens e a Soma da Inteligência dos personagens atuais é: " 
            + personagens.Sum(personagem => personagem.Inteligencia) + "";
            return Ok(estatisticas);
        }
    }
}