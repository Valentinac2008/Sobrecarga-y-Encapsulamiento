using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorMicroondas
{
    public class Microondas
    {
        private int _potencia;
        private int _tiempoSegundos;
        private bool _puertaAbierta;
        private bool _enFuncionamiento;

        public string PantallaTiempo
        {
            get
            {
                int minutos = _tiempoSegundos / 60;
                int segundos = _tiempoSegundos % 60;

                return $"{minutos:D2}:{segundos:D2}";
            }
        }

        public int Potencia => _potencia;
        public bool PuertaAbierta => _puertaAbierta;
        public bool EnFuncionamiento => _enFuncionamiento;

        public Microondas(int potencia)
        {
            _potencia = potencia;
            _tiempoSegundos = 0;
            _puertaAbierta = false;
            _enFuncionamiento = false;
        }
        public void AgregarTiempo()
        {
            AgregarTiempo(30);
        }
        public void AgregarTiempo(int segundos)
        {
            _tiempoSegundos += segundos;

           
            if (_tiempoSegundos > 3600)
            {
                _tiempoSegundos = 3600;
            }
        }

        public void Iniciar()
        {
            if (_puertaAbierta)
            {
                Console.WriteLine(
                    "No se puede iniciar con la puerta abierta."
                );
                return;
            }

            if (_tiempoSegundos == 0)
            {
                Console.WriteLine(
                    "Debe agregar tiempo."
                );
                return;
            }

            _enFuncionamiento = true;
        }
        public void Detener()
        {
            
            if (_enFuncionamiento)
            {
                _enFuncionamiento = false;
            }
           
            else
            {
                _tiempoSegundos = 0;
            }
        }

        public void AbrirCerrarPuerta()
        {
            _puertaAbierta = !_puertaAbierta;

            if (_puertaAbierta &&
                _enFuncionamiento)
            {
                _enFuncionamiento = false;
            }
        }
    }
}