using Practica2Ejercicio2Api.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Practica2Ejercicio2Api.Infraestructure
{
    public class BebidasRepository
    {

        List<Ibebidas> _bebida;

        public BebidasRepository()
        {
            var fileName = "Bebidas.json";

            if (File.Exists(fileName))

            {

                var json = File.ReadAllText(fileName);

                _bebida = JsonSerializer.Deserialize<IEnumerable<Ibebidas>>(json).ToList();
            }

            // Todos los datos
          

        }

        public IEnumerable<Ibebidas> GetAll()
        {
            var query = _bebida.Select( b => b);
            return query;
        }

        public double CalMililitros(string nombre, int cantidad, int peso)
        {
            
            var dato = _bebida.FirstOrDefault(b => b.Nombre == nombre.ToUpper());
            double dato2;

            if (dato == null)
            {
                dato2 = -1;
            }
            else
            {

                double totalA = dato.Mililitro * cantidad;
                double tipo = dato.Grado * totalA;
                double sangre = 0.15 * tipo;
                double ethoTotal = 0.789 * sangre;
                double alcoholTotal = 0.08 * peso;
                dato2 = ethoTotal / alcoholTotal;
            }

            return dato2;

        }




    }
}
