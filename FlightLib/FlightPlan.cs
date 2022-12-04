using System;
using System.Collections.Generic;
using System.Text;

namespace FlightLib
{
    public class FlightPlan
    {
        // Atributos

        string id; // identificador
        Position initialPosition; // posicion inicial
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        double velocidad; // velocidad
        string company_name; //nombre de la compañia
        string aircraft_type; //modelo del aircraft
        double angulo; //angulo
        double Distancia_recorrida = 0; //Distancia recorrida por el avion





        // Constructures

        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
            this.angulo = Math.Atan2(finalPosition.GetY() - initialPosition.GetY(), finalPosition.GetX() - initialPosition.GetX());

        }

        public FlightPlan(string id, double ipx, double ipy, double cpx, double cpy, double fpx, double fpy, double velocidad)
        {
            this.id = id;
            this.initialPosition = new Position(ipx, ipy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
            this.angulo = Math.Atan2(finalPosition.GetY() - initialPosition.GetY(), finalPosition.GetX() - initialPosition.GetX());

        }

        public FlightPlan(string id, double ipx, double ipy, double cpx, double cpy, double fpx, double fpy, double velocidad, string company, string aircraftType)
        {
            this.id = id;
            this.initialPosition = new Position(ipx, ipy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
            this.angulo = Math.Atan2(finalPosition.GetY() - initialPosition.GetY(), finalPosition.GetX() - initialPosition.GetX());
            this.company_name = company;
            this.aircraft_type = aircraftType;

        }
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad, string company)
        {
            this.id = id;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
            this.angulo = Math.Atan2(finalPosition.GetY() - initialPosition.GetY(), finalPosition.GetX() - initialPosition.GetX());
            this.company_name = company;

        }

        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad, string company, string aircraft_type)
        {
            this.id = id;
            this.initialPosition = new Position(cpx, cpy);
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
            this.angulo = Math.Atan2(finalPosition.GetY() - initialPosition.GetY(), finalPosition.GetX() - initialPosition.GetX());
            this.company_name = company;
            this.aircraft_type = aircraft_type;

        }

        public FlightPlan()
        {

        }

        // Metodos

        public void SetVelocidad(double velocidad)
        // setter del atributo velocidad
        { this.velocidad = velocidad; }

        public void Mover(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            if (!Destino())
            {
                //Calculamos la distancia recorrida en el tiempo dado
                double distancia = tiempo * this.velocidad / 60;

                //Calculamos las razones trigonométricas
                double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
                double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
                double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

                //Caculamos la nueva posición del vuelo
                double x = currentPosition.GetX() + distancia * coseno;
                double y = currentPosition.GetY() + distancia * seno;

                Position nextPosition = new Position(x, y);

                if (currentPosition.Distancia(nextPosition) < hipotenusa)
                    currentPosition = nextPosition;
                else
                    currentPosition = finalPosition;
            }

        }

        public bool Inicio()
        {
            bool resultado = false;
            if (this.currentPosition == this.initialPosition)
                resultado = true;
            return resultado;
        }
        /// <summary>
        /// Comprueba si el flightplan esta en el destino
        /// </summary>
        /// <returns></returns>
        public bool Destino()
        {
            bool resultado = false;
            // Si la posicion actual es igual a la final, devuelve true
            if (this.currentPosition == this.finalPosition) resultado = true;

            return resultado;
        }

        /// <summary>
        /// Comprueba si el flightplan esta en conflicto con el que se le da a la funcion
        /// </summary>
        /// <param name="b"></param>
        /// <param name="distanciaSeguridad"></param>
        /// <returns></returns>
        public bool Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;
            if (this.currentPosition.Distancia(b.currentPosition) < distanciaSeguridad)
                conflicto = true;

            return conflicto;
        }
        /// <summary>
        /// Getter de la posicion actual
        /// </summary>
        /// <returns></returns>
        public Position GetCurrentPosition()
        {
            return this.currentPosition;
        }
        /// <summary>
        /// Getter del identificador
        /// </summary>
        /// <returns></returns>
        public string GetID()
        {
            return this.id;
        }
        /// <summary>
        /// Getter de la velocidad
        /// </summary>
        /// <returns></returns>
        public double GetVelocity()
        {
            return this.velocidad;
        }

        /// <summary>
        /// El flightplan vuelve a la posicion inicial
        /// </summary>
        public void GoInitialPosition()
        {
            currentPosition = initialPosition;
        }

        /// <summary>
        /// Getter de la posicion inicial
        /// </summary>
        /// <returns></returns>
        public Position GetInitialPosition()
        {
            return this.initialPosition;
        }

        /// <summary>
        /// Getter de la posicion final
        /// </summary>
        /// <returns></returns>
        public Position GetFinalPosition()
        {
            return this.finalPosition;
        }

        /// <summary>
        /// Calcula la distancia minima entre los recorridos de dos flightplans
        /// </summary>
        /// <param name="airplane"></param>
        /// <returns></returns>
        public double minDistance(FlightPlan airplane)
        {
            Double x1 = this.GetInitialPosition().GetX();
            Double x2 = airplane.GetInitialPosition().GetX();
            Double y1 = this.GetInitialPosition().GetY();
            Double y2 = airplane.GetInitialPosition().GetY();

            Double x1f = this.GetFinalPosition().GetX();
            Double x2f = airplane.GetFinalPosition().GetX();
            Double y1f = this.GetFinalPosition().GetY();
            Double y2f = airplane.GetFinalPosition().GetY();

            Double v1 = this.GetVelocity();
            Double v2 = airplane.GetVelocity();

            Double h1 = Math.Sqrt(((x1f - x1) * (x1f - x1)) + ((y1f - y1) * (y1f - y1)));
            Double h2 = Math.Sqrt(((x2f - x2) * (x2f - x2)) + ((y2f - y2) * (y2f - y2)));

            Double cos1 = (x1f - x1) / h1;
            Double cos2 = (x2f - x2) / h2;
            Double sin1 = (y1f - y1) / h1;
            Double sin2 = (y2f - y2) / h2;

            Double vx1 = v1 * cos1;
            Double vx2 = v2 * cos2;
            Double vy1 = v1 * sin1;
            Double vy2 = v2 * sin2;

            Double t = -((((vy2 - vy1) * y2) + ((vy1 - vy2) * y1) + ((vx2 - vx1) * x2) + ((vx1 - vx2) * x1)) / ((vy2 * vy2) - (2 * vy1 * vy2) + (vy1 * vy1) + (vx2 * vx2) - (2 * vx1 * vx2) + (vx1 * vx1)));

            Double x1min = x1 + (t * v1 * cos1);
            Double y1min = y1 + (t * v1 * sin1);

            Double x2min = x2 + (t * v2 * cos2);
            Double y2min = y2 + (t * v2 * sin2);

            Position aircraft1 = new Position(x1min, y1min);
            Position aircraft2 = new Position(x2min, y2min);

            Double distancia = aircraft1.Distancia(aircraft2);

            Console.WriteLine(distancia);
            return distancia;

        }

        /// <summary>
        /// Hace una copia del flightplan
        /// </summary>
        /// <returns></returns>
        public FlightPlan DeepCopy()
        {
            string identificador = this.id;
            Position Posicion_inicial = this.initialPosition;
            Position Posicion_Actual = this.currentPosition;
            Position Posicion_Final = this.finalPosition;
            double speed = this.velocidad;
            FlightPlan fp = new FlightPlan(identificador, Posicion_inicial.GetX(), Posicion_inicial.GetY(), Posicion_Actual.GetX(),
                Posicion_Actual.GetY(), Posicion_Final.GetX(), Posicion_Final.GetY(), velocidad);
            return fp;
        }

        /// <summary>
        /// Comprueba si los aviones estan en operacion de aterizaje
        /// </summary>
        /// <returns></returns>
        public int Landing()
        {
            if (this.currentPosition.Distancia(this.finalPosition) <= 100)
            {
                return 0;
            }
            else
                return -1;
        }
        /// <summary>
        /// Funcion para obtener la compañia del flightplan actual
        /// </summary>
        /// <returns></returns>
        public string GetCompany()
        {
            return this.company_name;
        }

        public string GetAircraftType()
        {
            return this.aircraft_type;
        }
        public void SetCurrentPosition(double X, double Y)
        {
            this.currentPosition.Set(X, Y);
        }

        /// <summary>
        /// setea la distancia recorrida por el avion
        /// </summary>
        /// <param name="distancia"></param>
        public void AñadirPosicion(double distancia)
        {
            this.Distancia_recorrida = distancia;
        }
        /// <summary>
        /// Getter de la distancia recorrida
        /// </summary>
        /// <returns></returns>
        public double GetDistanciaRecorrida()
        {
            return Distancia_recorrida;
        }
    }
}
