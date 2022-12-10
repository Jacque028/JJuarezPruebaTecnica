using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    { 
        public int IdLibro { get; set; }
        public string Nombre { get; set; } 

        public int NumeroPaginas { get; set; }
        public string FechaPublicacion { get; set; }
        public string Edicion { get; set; }

        // Propiedades de navegacion 

        // AUTOR 
        public ML.Autor Autor { get; set; }

        //EDITORIAL 
        public ML.Editorial Editorial { get; set; }

        //GENERO  
        public ML.Genero Genero { get; set; }

    }
}
