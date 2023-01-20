using PruebaClasesEquipo4.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PruebaClases.MetodosAlgoritmos
{
    public class AlgoritmoInicio
    {
        public List<Demanda> listaDemandas = new List<Demanda>();
        public AlgoritmoInicio()
        {
        }
        // Objetivo: Método realizará el promedio de una lista de demandas


        public double CalcularMedia(List<Demanda> listaDem)
        {
            // Paso 1: Declarar variables y setearlas
            double media = 0;
            double suma = 0;

            // Paso 2: Calcular la variable suma (ACUMULADO)
            foreach (Demanda demanda2 in listaDem)
            {
                suma = suma + demanda2.CantidadRequerida + demanda2.CantidadProgramada;
            }
            // Paso 3: Dividir entre total de datos (PROMEDIO)
            // Paso 3.1: Condicionar a tener datos en la listaDem
            if (listaDem.Count() > 0)
            {
                media = suma / listaDem.Count();
            }

            return media;

        }

        //Calcular desviación estándar.


        public double CalcularStdDev(List<Demanda> listaDem, double media)
        {

            double varianceSum = 0;

            for (int x = 0; x < listaDem.Count; x++)
            {
                varianceSum += Math.Pow(Convert.ToDouble(listaDem[x].CantidadProgramada) - media, 2);
            }

            double variance = varianceSum / (listaDem.Count() - 1);
            double stdDev = Math.Pow(variance, 0.5);

            return stdDev;

        }



        // Llena datos de manera aleatorio Uniforme
        public void LlenarDatosAleatorios(int numeroDatos,int limiteInferior, int limiteSuperior)
        {
            // Paso 1: Declarar la variable aleatorio (Entrada un tiempo)
            Random aleatorio = new Random(Environment.TickCount);
            // Paso 2: Realizar un ciclo, para generar una cantidad "numeroDatos" de valores aleatorios
            for (int i = 0; i < numeroDatos; i++)
            {
                // (Generar valores aleatorios entre cero y uno)
                double value = aleatorio.NextDouble();
                // Paso 2.1:  Generar valor aleatorio (VARIABLE) entre limite inferior y limite superior (Entero)
                double value2 = aleatorio.Next(limiteInferior, limiteSuperior);
                double value3 = aleatorio.Next(limiteInferior, limiteSuperior);
                // Paso 2.2:  Declarar e inicializar variable "demanda"
                Demanda demanda = new Demanda();
                // Paso 2.3: Settear el atributo "idDemanda" con la variable "i" (castear)
                demanda.IdDemanda = i.ToString();
                // Paso 2.4: Asignar el "value2" y "value3" a cantidad requerida y cantidad programada.
                demanda.CantidadRequerida = value2;
                demanda.CantidadProgramada = value3;
                // Paso 2.5: Agregar el objeto demanda a la listaDemanda 
                listaDemandas.Add(demanda);
            }
        }



        // Main
        public double AlgoritmoGenerarAleatoriosMedia(int numeroDatos,
            int limiteInferior, int limiteSuperior, List<double> lista1)
        {
            // Paso 0: Declarar y "settear" la variable media
            double media = 0;

            
            // Paso 2: Generar números aleatorios y llenar lista de demandas

            LlenarDatosAleatorios(numeroDatos, limiteInferior, limiteSuperior);

            // Paso 3: Calcular la media
            media = CalcularMedia(listaDemandas);
            double desest = CalcularStdDev(listaDemandas, media);
            lista1.Add(media);
            lista1.Add(desest);
            
            return media;
        }

        public double AlgoritmoGenerarAleatoriosStdDev(int numeroDatos, int limiteInferior, int limiteSuperior)
        {
            double media = 0;
            double stdDev;
            //Paso 5: Calcular la stdDev            
            stdDev = CalcularStdDev(listaDemandas, media);

            //Paso 6: Retorna la stdDev.

            return stdDev;

        }
        ///////Fin del main //////////////

        public double AlgoritmoCiclarMedia (int ciclos, int numeroDatos, List<int>lista1, int limiteInferior, int limiteSuperior) 
        {


            lista1 = new List<int>();
            double MediadeLasMedias = 0;
            for (int y = 0; y < ciclos; y++) 
            {

                AlgoritmoGenerarAleatoriosMedia(numeroDatos, limiteInferior, limiteSuperior, lista1);
                MediadeLasMedias = MediadeLasMedias + CalcularMedia(listaDemandas);

            }

            MediadeLasMedias = MediadeLasMedias / ciclos;
            lista1.Add(MediadeLasMedias);

            return MediadeLasMedias;
        
        }

    }

}


