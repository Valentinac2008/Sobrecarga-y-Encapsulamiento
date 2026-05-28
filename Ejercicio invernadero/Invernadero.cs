using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Invernadero
    {

        private string _nombreSector;
        private int _temperaturaActual;
        private int _humedadSuelo;
        private bool _sistemaRiegoActivo;
        private bool _calefaccionActiva;
        private string _tipoCultivo;


        public Invernadero(string nombreSector, string tipoCultivo)
        {
            _nombreSector = nombreSector;
            _tipoCultivo = tipoCultivo.ToUpper();

            _temperaturaActual = 25;
            _humedadSuelo = 50;

            _sistemaRiegoActivo = false;
            _calefaccionActiva = false;
        }


        public int TemperaturaActual
        {
            get { return _temperaturaActual; }
        }

        public int HumedadSuelo
        {
            get { return _humedadSuelo; }
        }

        public bool SistemaRiegoActivo
        {
            get { return _sistemaRiegoActivo; }
        }

        public bool CalefaccionActiva
        {
            get { return _calefaccionActiva; }
        }


        public string ReporteEstado
        {
            get
            {
                string alerta = "PARAMETROS OPTIMOS";

                if (_tipoCultivo == "TROPICAL")
                {
                    if (_humedadSuelo < 60)
                    {
                        alerta = "BAJA HUMEDAD";
                    }
                    else if (_temperaturaActual < 20 || _temperaturaActual > 28)
                    {
                        alerta = "TEMPERATURA INCORRECTA";
                    }
                }

                else if (_tipoCultivo == "DESERTICO")
                {
                    if (_humedadSuelo > 20)
                    {
                        alerta = "EXCESO DE HUMEDAD";
                    }
                    else if (_temperaturaActual < 25 || _temperaturaActual > 35)
                    {
                        alerta = "TEMPERATURA INCORRECTA";
                    }
                }

                return $"SECTOR: {_nombreSector.ToUpper()} - CULTIVO: {_tipoCultivo} - ALERTA: {alerta}";
            }
        }


        public void SimularClima()
        {
            _humedadSuelo -= 5;
            _temperaturaActual += 1;

            if (_humedadSuelo < 0)
            {
                _humedadSuelo = 0;
            }
        }

        public void SimularClima(int humedad, int temperatura)
        {
            _humedadSuelo = humedad;
            _temperaturaActual = temperatura;

            if (_humedadSuelo > 100)
            {
                _humedadSuelo = 100;
            }

            if (_humedadSuelo < 0)
            {
                _humedadSuelo = 0;
            }
        }

        public void ControlAutomatico()
        {
            if (_tipoCultivo == "TROPICAL")
            {

                if (_humedadSuelo < 60)
                {
                    if (_humedadSuelo < 100)
                    {
                        _sistemaRiegoActivo = true;
                    }
                }
                else
                {
                    _sistemaRiegoActivo = false;
                }


                if (_temperaturaActual < 20)
                {
                    if (_temperaturaActual <= 45)
                    {
                        _calefaccionActiva = true;
                    }
                }
                else
                {
                    _calefaccionActiva = false;
                }
            }

            else if (_tipoCultivo == "DESERTICO")
            {

                if (_humedadSuelo > 20)
                {
                    _sistemaRiegoActivo = false;
                }


                if (_temperaturaActual < 25)
                {
                    if (_temperaturaActual <= 45)
                    {
                        _calefaccionActiva = true;
                    }
                }
                else
                {
                    _calefaccionActiva = false;
                }
            }


            if (_humedadSuelo >= 100)
            {
                _sistemaRiegoActivo = false;
            }

            if (_temperaturaActual > 45)
            {
                _calefaccionActiva = false;
            }
        }
    }
}
