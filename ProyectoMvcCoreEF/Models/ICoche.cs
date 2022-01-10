using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMvcCoreEF.Models
{
    //importante ponerlo en public
    public interface ICoche
    {
        //SOLO DECLARACION DE COMO SERA EL OBJETO 
        //PROPIEDADES Y METODOS 

        //propiedades
        String Marca { get; set; }
        String Modelo { get; set; }
        String Imagen { get; set; }
        int Velocidad { get; set; }
        int VelocidadMaxima { get; set; }
        //metodos
        int Acelerar();
        int Frenar();
    }
}
