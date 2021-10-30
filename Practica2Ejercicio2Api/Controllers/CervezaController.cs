using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practica2Ejercicio2Api.Domain;
using Practica2Ejercicio2Api.Infraestructure;

namespace Practica2Ejercicio2Api.Controllers
{

    /*
      
        Nombre de la escuela: Universidad Tecnologica Metropolitana

        Materia: Aplicaciones Web Orientadas a Servicios

        Profesor: Joel Chuc

        Actividad: (Alcoholemia)

        Alumno: Hernandez Carrillo Cristian Santiago
    
        Cuatrimestre: 4

        Grupo: B

        Parcial: 2
     
     
     */

    [Route("api/[controller]")]
    [ApiController]
    public class CervezaController : ControllerBase
    {
        [HttpGet]
        [Route("BebidaTodos")]


        public IActionResult CalMililitros(string nombre, int cantidad, int peso)
        {
            var texto = "";
            var repository = new BebidasRepository();
            var b = repository.CalMililitros(nombre, cantidad, peso);

            if (b == -1)
            {
                texto = "La bebida ingresada: " + nombre + ", no existe";
            }
            else if (b > 0.8)
            {
                texto = ("Alcohol en la sangres es : " + b.ToString(("##,##0.00")) + "Ayuda inmediata");
            }
            else
            {
                texto = ("Siga su camino,");
            }
            return Ok(texto);
        }



    }
        


        
}



