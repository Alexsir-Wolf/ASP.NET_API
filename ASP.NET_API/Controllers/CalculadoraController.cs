using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("soma/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Soma(string primeiroNumero, string segundoNumero)
        {
            if (ValidaNumero(primeiroNumero) && ValidaNumero(segundoNumero)) 
            {
                var resultado = ConverteDecimal(primeiroNumero) + ConverteDecimal(segundoNumero);
                return Ok(resultado.ToString());
            }
            return BadRequest("Números invalidos!");
        }        
        
        [HttpGet("subtrai/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Subtrai(string primeiroNumero, string segundoNumero)
        {
            if (ValidaNumero(primeiroNumero) && ValidaNumero(segundoNumero)) 
            {
                var resultado = ConverteDecimal(primeiroNumero) - ConverteDecimal(segundoNumero);
                return Ok(resultado.ToString());
            }
            return BadRequest("Números invalidos!");
        }      
        
        [HttpGet("multiplica/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Multiplica(string primeiroNumero, string segundoNumero)
        {
            if (ValidaNumero(primeiroNumero) && ValidaNumero(segundoNumero)) 
            {
                var resultado = ConverteDecimal(primeiroNumero) * ConverteDecimal(segundoNumero);
                return Ok(resultado.ToString());
            }
            return BadRequest("Números invalidos!");
        }       
        
        [HttpGet("divisao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Divisao(string primeiroNumero, string segundoNumero)
        {
            if (ValidaNumero(primeiroNumero) && ValidaNumero(segundoNumero)) 
            {
                var resultado = ConverteDecimal(primeiroNumero) / ConverteDecimal(segundoNumero);
                return Ok(resultado.ToString());
            }
            return BadRequest("Números invalidos!");
        }          
        
        [HttpGet("media/{primeiroNumero}/{segundoNumero}/{terceiroNumero}")]
        public IActionResult Media(string primeiroNumero, string segundoNumero, string terceiroNumero)
        {
            if (ValidaNumero(primeiroNumero) && ValidaNumero(segundoNumero) && ValidaNumero(terceiroNumero)) 
            {
                var resultado = ConverteDecimal(primeiroNumero) + ConverteDecimal(segundoNumero) + ConverteDecimal(terceiroNumero) / 3;
                return Ok(resultado.ToString());
            }
            return BadRequest("Números invalidos!");
        }
               
        
        [HttpGet("raiz/{primeiroNumero}")]
        public IActionResult RaizQuadrada(string primeiroNumero)
        {
            if (ValidaNumero(primeiroNumero)) 
            {
                var resultado = Convert.ToSingle(Math.Sqrt((double)ConverteDecimal(primeiroNumero))); ;
                return Ok(resultado.ToString());
            }
            return BadRequest("Números invalidos!");
        }

        private decimal ConverteDecimal(string stringNumero)
        {
            decimal valorDecimal;
            if (decimal.TryParse(stringNumero, out valorDecimal)) 
            {
                return valorDecimal;
            }
            return 0;
        }

        private bool ValidaNumero(string stringNumero)
        {
            double numero;
            bool valida = double.TryParse(stringNumero, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out numero);
            
            return valida;
        }
    }
}
