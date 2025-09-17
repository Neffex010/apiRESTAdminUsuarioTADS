using apiRESTAdminUsuarioTADS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace apiRESTAdminUsuarioTADS.Controllers
{
    public class CensoController : ApiController
    {
        // Arreglo estático que almacenará los registros de tipo clsCenso
        public static clsCenso[] objCenso = null;

        // GET: api/Censo
        // Devuelve todos los registros almacenados en el arreglo
        public IEnumerable<clsCenso> Get()
        {
            return objCenso;
        }

        // GET: api/Censo/5
        // Devuelve un registro en base al id recibido como parámetro
        public clsCenso Get(int id)
        {
            // Variable temporal para almacenar el resultado de búsqueda
            clsCenso elemento = new clsCenso();

            // Recorre el arreglo buscando un registro con el id especificado
            for (int i = 0; i < objCenso.Length; i++)
            {
                if (objCenso[i].id == id)
                {
                    elemento = objCenso[i];
                    break;
                }
            }
            return elemento;
        }

        // POST: api/Censo
        // Inserta un nuevo registro en una posición específica del arreglo
        public string Post(int posicion, [FromBody] clsCenso modelo)
        {
            string ban = "";

            // Si el arreglo aún no existe, se crea y se inicializan 5 elementos vacíos
            if (objCenso == null)
            {
                objCenso = new clsCenso[5];
                objCenso[0] = new clsCenso();
                objCenso[1] = new clsCenso();
                objCenso[2] = new clsCenso();
                objCenso[3] = new clsCenso();
                objCenso[4] = new clsCenso();
            }

            // Valida que la posición sea válida (0 a 4) e inserta los datos del modelo
            if (posicion >= 0 && posicion <= 4)
            {
                objCenso[posicion].id = modelo.id;
                objCenso[posicion].curp = modelo.curp;
                objCenso[posicion].nombre = modelo.nombre;
                objCenso[posicion].apellidoPaterno = modelo.apellidoPaterno;
                objCenso[posicion].apellidoMaterno = modelo.apellidoMaterno;
                objCenso[posicion].direccion = modelo.direccion;
                objCenso[posicion].actividadEconomica = modelo.actividadEconomica;
                ban = "1"; // Inserción exitosa
            }
            else
            {
                ban = "0"; // Posición inválida
            }
            return ban;
        }

        // PUT: api/Censo/5
        // Actualiza los datos de un registro en una posición específica
        public string Put(int posicion, [FromBody] clsCenso modelo)
        {
            string ban;

            // Verifica que el arreglo exista
            if (objCenso != null)
            {
                // Valida la posición e inserta los nuevos valores
                if (posicion >= 0 && posicion <= 4)
                {
                    objCenso[posicion].id = modelo.id;
                    objCenso[posicion].curp = modelo.curp;
                    objCenso[posicion].nombre = modelo.nombre;
                    objCenso[posicion].apellidoPaterno = modelo.apellidoPaterno;
                    objCenso[posicion].apellidoMaterno = modelo.apellidoMaterno;
                    objCenso[posicion].direccion = modelo.direccion;
                    objCenso[posicion].actividadEconomica = modelo.actividadEconomica;
                    ban = "1"; // Actualización exitosa
                }
                else
                {
                    ban = "0"; // Posición inválida
                }
            }
            else
            {
                ban = "-1"; // Arreglo no inicializado
            }
            return ban;
        }

        // DELETE: api/Censo/5
        // Elimina (resetea) los datos de un registro en una posición específica
        public string Delete(int posicion)
        {
            string ban;

            // Verifica que el arreglo exista
            if (objCenso != null)
            {
                // Valida la posición y limpia los valores del registro
                if (posicion >= 0 && posicion <= 4)
                {
                    objCenso[posicion].id = 0;
                    objCenso[posicion].curp = null;
                    objCenso[posicion].nombre = null;
                    objCenso[posicion].apellidoPaterno = null;
                    objCenso[posicion].apellidoMaterno = null;
                    objCenso[posicion].direccion = null;
                    objCenso[posicion].actividadEconomica = null;
                    ban = "1"; // Eliminación exitosa
                }
                else
                {
                    ban = "0"; // Posición inválida
                }
            }
            else
            {
                ban = "-1"; // Arreglo no inicializado
            }
            return ban;
        }
    }
}
