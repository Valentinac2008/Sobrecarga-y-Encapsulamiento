using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Bateria
    {

        public class Bateria
    {
        private int _porcentajeCarga;
        private int _saludBateria;
        private bool _conectadoCargador;
        private bool _modoAhorroEnergia;
        private int _cargaAcumuladaEnCiclo;

        public int PorcentajeCarga
        {
            get { return _porcentajeCarga; }
            private set
            {
                if (value < 0)
                {
                    _porcentajeCarga = 0;
                }
                else if (value > 100)
                {
                    _porcentajeCarga = 100;
                }
                else
                {
                    _porcentajeCarga = value;
                }
            }
        }

        public int SaludBateria
        {
            get { return _saludBateria; }
            private set
            {
                if (value < 0)
                {
                    _saludBateria = 0;
                }
                else if (value > 100)
                {
                    _saludBateria = 100;
                }
                else
                {
                    _saludBateria = value;
                }
            }
        }

        public bool ConectadoCargador
        {
            get { return _conectadoCargador; }
            private set { _conectadoCargador = value; }
        }

        public bool ModoAhorroEnergia
        {
            get { return _modoAhorroEnergia; }
            private set { _modoAhorroEnergia = value; }
        }

        public string EstadoTexto
        {
            get
            {
                if (ConectadoCargador)
                {
                    return $"CARGANDO - BATERIA: {PorcentajeCarga}%";
                }

                return $"BATERIA: {PorcentajeCarga}%";
            }
        }

        public Bateria()
        {
            PorcentajeCarga = 50;
            SaludBateria = 100;
            ConectadoCargador = false;
            ModoAhorroEnergia = false;
            _cargaAcumuladaEnCiclo = 0;
        }

        public void AlternarCargador()
        {
            ConectadoCargador = !ConectadoCargador;
        }

        public void ConsumirEnergia()
        {
            int consumo = 1;

            if (ModoAhorroEnergia)
            {
                consumo = 1 / 2;
                if (consumo == 0)
                {
                    consumo = 1;
                }
            }

            PorcentajeCarga -= consumo;

            VerificarModoAhorro();
        }

        public void ConsumirEnergia(int consumo)
        {
            if (consumo < 0)
            {
                return;
            }

            if (ModoAhorroEnergia)
            {
                consumo = consumo / 2;
            }

            PorcentajeCarga -= consumo;

            VerificarModoAhorro();
        }

        public void CicloDeCarga()
        {
            if (!ConectadoCargador)
            {
                return;
            }

            if (PorcentajeCarga < SaludBateria)
            {
                int cargaAntes = PorcentajeCarga;

                PorcentajeCarga += 10;

                if (PorcentajeCarga > SaludBateria)
                {
                    PorcentajeCarga = SaludBateria;
                }

                _cargaAcumuladaEnCiclo += PorcentajeCarga - cargaAntes;

                if (_cargaAcumuladaEnCiclo >= 100)
                {
                    SaludBateria--;
                    _cargaAcumuladaEnCiclo = 0;
                }
            }

            VerificarModoAhorro();
        }

        private void VerificarModoAhorro()
        {
            if (PorcentajeCarga < 20)
            {
                ModoAhorroEnergia = true;
            }

            if (PorcentajeCarga > 50)
            {
                ModoAhorroEnergia = false;
            }
        }
    }
}
