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

        public string CodigoConfig
        {
            get
            {
                string plan = _esPremium ? "PREM" : "STD";

                return $"{_marca.ToUpper()}-{_pulgadas}-{plan}";
            }
        }

        public bool Encendido => _encendido;
        public int CanalActual => _canalActual;

        public string VolumenPantalla
        {
            get
            {
                return _volumen == 0
                    ? "MUTE"
                    : _volumen.ToString();
            }
        }
     public string Marca{
            get{return _marca}
            private set{
                if(!string.IsNullOrWitheSpace(value)){
                    _marca = value;
                }
            }
        public int Pulgadas{
            get{return _pulgadas}
            private set{
                _pulgadas = value;
            }
        }
        public bool EsPremium{
            get{return _esPremium}
            private set{
                _esPremium = value;
            }
        }
        public SmartTV(
            string marca,
            int pulgadas,
            bool esPremium
        )
        {
            Marca = marca;
            Pulgadas = pulgadas;
            EsPremium = esPremium;

            _encendido = false;
            _canalActual = 1;
            _volumen = 10;
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
