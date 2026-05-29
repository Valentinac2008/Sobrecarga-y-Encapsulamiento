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

        public string Marca
        {
            get { return _marca; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _marca = value;
                }
            }
        }

        public bool CajaAutomatica
        {
            get { return _cajaAutomatica; }
            private set { _cajaAutomatica = value; }
        }

        public bool MotorEncendido
        {
            get { return _motorEncendido; }
            private set { _motorEncendido = value; }
        }

        public int VelocidadActual
        {
            get { return _velocidadActual; }
            private set
            {
                if (value < 0)
                {
                    _velocidadActual = 0;
                }
                else
                {
                    _velocidadActual = value;
                }
            }
        }

        public bool ModoCrucero
        {
            get { return _modoCrucero; }
            private set { _modoCrucero = value; }
        }

        public string Identificador
        {
            get
            {
                string prefijo = Marca.Substring(0, Math.Min(3, Marca.Length)).ToUpper();
                string tipoCaja = CajaAutomatica ? "AUTO" : "MAN";
                return $"{prefijo}-{tipoCaja}-{DateTime.Now.Year}";
            }
        }

        public Automovil(string marca, bool cajaAutomatica)
        {
            Marca = marca;
            CajaAutomatica = cajaAutomatica;
            MotorEncendido = false;
            VelocidadActual = 0;
            ModoCrucero = false;
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
