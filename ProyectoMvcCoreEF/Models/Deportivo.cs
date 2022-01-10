using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMvcCoreEF.Models
{
    //hereda de coche
    public class Deportivo: ICoche
    {
        public Deportivo(String marca, String modelo,String imagen,int velMax)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Imagen = imagen;
            this.Velocidad = 0;
            this.VelocidadMaxima = velMax;
        }
        public Deportivo() 
        {
            this.Marca = "Ferrari";
            this.Modelo = "F69";
            this.Imagen = "ferrari.jpg";
            this.Velocidad = 0;
            this.VelocidadMaxima = 250;
        }

        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Imagen { get; set; }
        public int Velocidad { get; set; }

        public int VelocidadMaxima { get; set; }


        public int Acelerar()
        {
            this.Velocidad += 40;
            if (this.Velocidad > this.VelocidadMaxima)
            {
                this.Velocidad = this.VelocidadMaxima;
            }
            return this.Velocidad;
        }

        public int Frenar()
        {
            this.Velocidad -= 40;
            if (this.Velocidad < 0)
            {
                this.Velocidad = 0;
            }
            return this.Velocidad;
        }
    }
}
