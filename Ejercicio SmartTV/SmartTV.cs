using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSmartTV
{
    public class SmartTV
    {
        private string _marca;
        private int _pulgadas;
        private bool _encendido;
        private int _canalActual;
        private int _volumen;
        private bool _esPremium;

        public string Marca
        {
            get { return _marca; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _marca = value.ToUpper();
                }
            }
        }

        public int Pulgadas
        {
            get { return _pulgadas; }
            private set
            {
                if (value > 0)
                {
                    _pulgadas = value;
                }
            }
        }

        public bool Encendido
        {
            get { return _encendido; }
            private set { _encendido = value; }
        }

        public int CanalActual
        {
            get { return _canalActual; }
            private set
            {
                int canalMaximo = _esPremium ? 500 : 100;

                if (value < 1)
                {
                    _canalActual = 1;
                }
                else if (value > canalMaximo)
                {
                    _canalActual = 1;
                }
                else
                {
                    _canalActual = value;
                }
            }
        }

        public int Volumen
        {
            get { return _volumen; }
            private set
            {
                if (value < 0)
                {
                    _volumen = 0;
                }
                else if (value > 100)
                {
                    _volumen = 100;
                }
                else
                {
                    _volumen = value;
                }
            }
        }

        public bool EsPremium
        {
            get { return _esPremium; }
            private set { _esPremium = value; }
        }

        public string CodigoConfig
        {
            get
            {
                string plan = EsPremium ? "PREM" : "STD";
                return $"{Marca}-{Pulgadas}-{plan}";
            }
        }

        public string VolumenTexto
        {
            get
            {
                return Volumen == 0 ? "MUTE" : Volumen.ToString();
            }
        }

        public SmartTV(string marca, int pulgadas, bool esPremium)
        {
            Marca = marca;
            Pulgadas = pulgadas;
            EsPremium = esPremium;

            Encendido = false;
            CanalActual = 1;
            Volumen = 20;
        }

        public void Power()
        {
            _encendido = !_encendido;
        }

        public void CambiarCanal()
        {
            if (!_encendido)
            {
                Console.WriteLine(
                    "La TV está apagada."
                );
                return;
            }

            int canalMaximo =
                _esPremium ? 500 : 100;

            _canalActual++;

            if (_canalActual > canalMaximo)
            {
                _canalActual = 1;
            }
        }

        public void CambiarCanal(int canal)
        {
            if (!_encendido)
            {
                Console.WriteLine(
                    "La TV está apagada."
                );
                return;
            }

            int canalMaximo =
                _esPremium ? 500 : 100;

            if (canal >= 1 && canal <= canalMaximo)
            {
                _canalActual = canal;
            }
            else
            {
                Console.WriteLine(
                    "Canal fuera de rango."
                );
            }
        }

        public void RegularVolumen(bool subir)
        {
            if (!_encendido)
            {
                Console.WriteLine(
                    "La TV está apagada."
                );
                return;
            }

            if (subir)
            {
                _volumen += 2;

                if (_volumen > 100)
                {
                    _volumen = 100;
                }
            }
            else
            {
                _volumen -= 2;

                if (_volumen < 0)
                {
                    _volumen = 0;
                }
            }
        }
    }
}
