using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorAutomovil
{
    public class Automovil
    {
        private string _marca;
        private bool _motorEncendido;
        private int _velocidadActual;
        private bool _cajaAutomatica;
        private bool _modoCrucero;

        public string Identificador
        {
            get
            {
                string tipoCaja;
                if (_cajaAutomatica)
                {
                    tipoCaja= "AUTO";
                }
                else
                {
                    tipoCaja = "MAN";
                }

                return _marca.Substring(0, 3).ToUpper(); +"-" + tipoCaja + "-2026";
            }
        }

        public int VelocidadActual => _velocidadActual;
        public bool MotorEncendido => _motorEncendido;
        public bool ModoCrucero => _modoCrucero;

        public Automovil(string marca, bool cajaAutomatica)
        {
            Marca = marca;
            CajaAutomatica = cajaAutomatica;
            _motorEncendido = false;
            _velocidadActual = 0;
            _modoCrucero = false;
        }

        public void EncenderApagar()
        {
            _motorEncendido = !_motorEncendido;

            
            if (!_motorEncendido)
            {
                _velocidadActual = 0;
                _modoCrucero = false;
            }
        }
        
        public void Acelerar()
        {
            Acelerar(10);
        }

        public void Acelerar(int kilometros)
        {
            if (!_motorEncendido)
            {
                Console.WriteLine("No se puede acelerar con el motor apagado.");
                return;
            }

            _velocidadActual += kilometros;

            int velocidadMaxima =
                _cajaAutomatica ? 220 : 180;

            if (_velocidadActual > velocidadMaxima)
            {
                _velocidadActual = velocidadMaxima;
            }
        }

        public void Frenar()
        {
            if (!_motorEncendido)
            {
                Console.WriteLine("No se puede frenar con el motor apagado.");
                return;
            }

            _velocidadActual = 0;

           
            _modoCrucero = false;
        }

        public void Frenar(int kilometros)
        {
            if (!_motorEncendido)
            {
                Console.WriteLine("No se puede frenar con el motor apagado.");
                return;
            }

            _velocidadActual -= kilometros;

            if (_velocidadActual < 0)
            {
                _velocidadActual = 0;
            }

            
            _modoCrucero = false;
        }

        public void ActivarModoCrucero()
        {
            if (_velocidadActual > 60)
            {
                _modoCrucero = true;
            }
            else
            {
                Console.WriteLine(
                    "Debe superar los 60 km/h para activar el modo crucero."
                );
            }
        }
    }
}
