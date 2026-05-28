using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Bateria
    {

        private int _porcentajeCarga;
        private int _saludBateria;
        private bool _conectadoCargador;
        private bool _modoAhorroEnergia;


        private int _acumuladorCarga;


        public Bateria()
        {
            _porcentajeCarga = 50;
            _saludBateria = 100;
            _conectadoCargador = false;
            _modoAhorroEnergia = false;
            _acumuladorCarga = 0;
        }

        public int PorcentajeCarga
        {
            get { return _porcentajeCarga; }
        }

        public int SaludBateria
        {
            get { return _saludBateria; }
        }

        public bool ConectadoCargador
        {
            get { return _conectadoCargador; }
        }

        public bool ModoAhorroEnergia
        {
            get { return _modoAhorroEnergia; }
        }


        public string EstadoTexto
        {
            get
            {
                if (_conectadoCargador)
                {
                    return $"CARGANDO - BATERIA: {_porcentajeCarga}%";
                }
                else
                {
                    return $"BATERIA: {_porcentajeCarga}%";
                }
            }
        }
            public void AlternarCargador()
        {
            _conectadoCargador = !_conectadoCargador;
        }

        public void ConsumirEnergia()
        {
            int consumo = 1;

            if (_modoAhorroEnergia)
            {
                consumo = consumo / 2;

                if (consumo == 0)
                {
                    consumo = 1;
                }
            }

            _porcentajeCarga -= consumo;

            if (_porcentajeCarga < 0)
            {
                _porcentajeCarga = 0;
            }

            VerificarModoAhorro();
        }


        public void ConsumirEnergia(int consumo)
        {
            if (_modoAhorroEnergia)
            {
                consumo = consumo / 2;
            }

            _porcentajeCarga -= consumo;

            if (_porcentajeCarga < 0)
            {
                _porcentajeCarga = 0;
            }

            VerificarModoAhorro();
        }


        public void CicloDeCarga()
        {
            if (_conectadoCargador)
            {

                if (_porcentajeCarga < _saludBateria)
                {
                    _porcentajeCarga += 10;
                    _acumuladorCarga += 10;

                    if (_porcentajeCarga > _saludBateria)
                    {
                        _porcentajeCarga = _saludBateria;
                    }


                    if (_acumuladorCarga >= 100)
                    {
                        _saludBateria--;

                        if (_saludBateria < 0)
                        {
                            _saludBateria = 0;
                        }

                        _acumuladorCarga = 0;
                    }
                }
            }

            VerificarModoAhorro();
        }


        private void VerificarModoAhorro()
        {
            if (_porcentajeCarga < 20)
            {
                _modoAhorroEnergia = true;
            }


            if (_porcentajeCarga > 50)
            {
                _modoAhorroEnergia = false;
            }
        }
    }
}
