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

        public int Potencia
        {
            get { return _potencia; }
            private set
            {
                if (value < 1)
                {
                    _potencia = 1;
                }
                else if (value > 10)
                {
                    _potencia = 10;
                }
                else
                {
                    _potencia = value;
                }
            }
        }

        public int TiempoSegundos
        {
            get { return _tiempoSegundos; }
            private set
            {
                if (value < 0)
                {
                    _tiempoSegundos = 0;
                }
                else if (value > 3600)
                {
                    _tiempoSegundos = 3600;
                }
                else
                {
                    _tiempoSegundos = value;
                }
            }
        }

        public bool PuertaAbierta
        {
            get { return _puertaAbierta; }
            private set { _puertaAbierta = value; }
        }

        public bool EnFuncionamiento
        {
            get { return _enFuncionamiento; }
            private set { _enFuncionamiento = value; }
        }

        public string PantallaTiempo
        {
            get
            {
                int minutos = TiempoSegundos / 60;
                int segundos = TiempoSegundos % 60;
                return $"{minutos:00}:{segundos:00}";
            }
        }

        public Microondas()
        {
            Potencia = 5;
            TiempoSegundos = 0;
            PuertaAbierta = false;
            EnFuncionamiento = false;
        }

        public void AgregarTiempo()
        {
            AgregarTiempo(30);
        }

        public void AgregarTiempo(int segundos)
        {
            if (segundos < 0)
            {
                return;
            }

            TiempoSegundos += segundos;

            if (TiempoSegundos > 3600)
            {
                TiempoSegundos = 3600;
            }
        }

        public void Iniciar()
        {
            if (PuertaAbierta)
            {
                Console.WriteLine("No se puede iniciar con la puerta abierta.");
                return;
            }

            if (TiempoSegundos == 0)
            {
                Console.WriteLine("No hay tiempo configurado.");
                return;
            }

            EnFuncionamiento = true;
        }

        public void Detener()
        {
            if (EnFuncionamiento)
            {
                EnFuncionamiento = false;
            }
            else
            {
                TiempoSegundos = 0;
            }
        }

        public void AbrirCerrarPuerta()
        {
            PuertaAbierta = !PuertaAbierta;

            if (PuertaAbierta && EnFuncionamiento)
            {
                EnFuncionamiento = false;
            }
        }
    }
}
