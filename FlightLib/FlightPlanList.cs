using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FlightLib
{
    public class FlightPlanList
    {
        List<FlightPlan> vector = new List<FlightPlan>();//crea una lista de flightplans
        int number = 0;//numero de flightplans en la lista
        bool error = false; //muestra true si ha habido algun problema al cargar el fichero
        double distancia_total;

        /// <summary>
        /// Añade un flightplan a la lista
        /// </summary>
        /// <param name="p"></param>
        public void AddFlightPlan(FlightPlan p)
        {

            vector.Add(p);
            number++;
        }

        /// <summary>
        /// Getter del flightplan en la posicion i
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public FlightPlan GetFlightPlan(int i)
        {
            if (number == 0)
            {
                return null;
            }
            else if (i < 0 || i >= number)
            {
                return null;
            }
            else
            {
                return vector[i];
            }
        }

        /// <summary>
        /// Getter de la longitud de la lista
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return number;
        }

        /// <summary>
        /// Mueve todos los flightplans de la lista
        /// </summary>
        /// <param name="tiempo"></param>
        public void Mover(double tiempo)
        {
            int i = 0;
            while (i < number)
            {
                if (vector[i].Destino() == true)
                {
                    Console.WriteLine(vector[i].GetID() + " arrived to dstination!");
                }
                else
                {
                    vector[i].Mover(tiempo);
                }
                i++;
                
            }
        }

        /// <summary>
        /// Borra todos los flightplans de la lista
        /// </summary>
        public void RemoveAll()
        {
            while(number > 0)
            {
                vector[number-1] = null;
                number--;
            }
        }

        /// <summary>
        /// Hace un DeepCopy de todos los flightplans
        /// </summary>
        /// <returns></returns>
        public FlightPlanList DeepCopy()
        {
            FlightPlanList lista = new FlightPlanList();
            foreach(FlightPlan e in vector)
            {
                FlightPlan auxiliar = e.DeepCopy();
                lista.AddFlightPlan(auxiliar);
            }
            return lista;
        }
        /// <summary>
        /// Borra todos los flightplans
        /// </summary>
        public void Clear()
        {
            vector.Clear();
            number = 0;
            error = false;
        }
        
        /// <summary>
        /// Getter de la variable error
        /// </summary>
        /// <returns></returns>
        public bool GetError()
        {
            return this.error;
        }

        /// <summary>
        /// comprueba si todos los aviones estan en su posicion inicial
        /// </summary>
        /// <returns></returns>
        public bool Inicio()
        {
            bool resp = true;
            foreach(FlightPlan e in vector)
            {
                if(e.GetCurrentPosition() != e.GetInitialPosition())
                    resp = false;
            }
            return resp;
        }

        /// <summary>
        /// obtiene un flightplan des de el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FlightPlan GetFlightPlanID(string id)
        {
            for (int i = 0; i < vector.Count; i++)
            {
                if (vector[i].GetID() == id)
                {
                    return vector[i];
                }

            }
            return null;
        }
        /// <summary>
        /// Devuelve una lista con todos los ID de la simulacion
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllID()
        {
            List<string> lista = new List<string>();
            foreach(FlightPlan e in this.vector)
            {
                lista.Add(e.GetID());
            }
            return lista;
        }
        /// <summary>
        /// Setea la distancia recorrida por todos los aviones
        /// </summary>
        public void SetDistanciaTotal()
        {
            double temp = 0;
            foreach(FlightPlan e in vector)
            {
                temp = temp + e.GetDistanciaRecorrida();
            }
            if (temp >= distancia_total)
            {
                this.distancia_total = temp;
            }
        }
        /// <summary>
        /// retorna la distancia total de la lista
        /// </summary>
        /// <returns></returns>
        public double GetDistanciaTotal()
        {
            return this.distancia_total;
        }
    }   
}
