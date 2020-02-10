using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppCRUD.Models.ViewModel
{
    public class ListTablaViewModel
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public string Fecha_Nacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Celular { get; set; }
        public int Cedula { get; set; }
    }
}