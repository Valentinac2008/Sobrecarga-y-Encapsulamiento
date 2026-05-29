using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Invernadero
    {

         public class Invernadero
    {
        private string _nombreSector;
        private int _temperaturaActual;
        private int _humedadSuelo;
        private bool _sistemaRiegoActivo;
        private bool _calefaccionActiva;
        private string _tipoCultivo;

        public string NombreSector
        {
            get { return _nombreSector; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _nombreSector = value.ToUpper();
                }
            }
        }

        public int TemperaturaActual
        {
            get { return _temperaturaActual; }
            private set { _temperaturaActual = value; }
        }

        public int HumedadSuelo
        {
            get { return _humedadSuelo; }
            private set
            {
                if (value < 0)
                {
                    _humedadSuelo = 0;
                }
                else if (value > 100)
                {
                    _humedadSuelo = 100;
                }
                else
                {
                    _humedadSuelo = value;
                }
            }
        }

        public bool SistemaRiegoActivo
        {
            get { return _sistemaRiegoActivo; }
            private set { _sistemaRiegoActivo = value; }
        }

        public bool CalefaccionActiva
        {
            get { return _calefaccionActiva; }
            private set { _calefaccionActiva = value; }
        }

        public string TipoCultivo
        {
            get { return _tipoCultivo; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    string cultivo = value.ToUpper();

                    if (cultivo == "TROPICAL" || cultivo == "DESERTICO")
                    {
                        _tipoCultivo = cultivo;
                    }
                }
            }
        }

        public string ReporteEstado
        {
            get
            {
                string alerta = "PARAMETROS OPTIMOS";

                if (TipoCultivo == "TROPICAL")
                {
                    if (HumedadSuelo < 60)
                    {
                        alerta = "BAJA HUMEDAD";
                    }
                    else if (TemperaturaActual < 20 || TemperaturaActual > 28)
                    {
                        alerta = "TEMPERATURA INCORRECTA";
                    }
                }
                else if (TipoCultivo == "DESERTICO")
                {
                    if (HumedadSuelo > 20)
                    {
                        alerta = "EXCESO DE HUMEDAD";
                    }
                    else if (TemperaturaActual < 25 || TemperaturaActual > 35)
                    {
                        alerta = "TEMPERATURA INCORRECTA";
                    }
                }

                return $"SECTOR: {NombreSector} - CULTIVO: {TipoCultivo} - ALERTA: {alerta}";
            }
        }

        public Invernadero(string nombreSector, string tipoCultivo)
        {
            NombreSector = nombreSector;
            TipoCultivo = tipoCultivo;

            TemperaturaActual = 25;
            HumedadSuelo = 50;
            SistemaRiegoActivo = false;
            CalefaccionActiva = false;
        }

        public void SimularClima()
        {
            HumedadSuelo -= 5;
            TemperaturaActual += 1;
        }

        public void SimularClima(int humedad, int temperatura)
        {
            HumedadSuelo = humedad;
            TemperaturaActual = temperatura;
        }

        public void ControlAutomatico()
        {
            if (TipoCultivo == "TROPICAL")
            {
                SistemaRiegoActivo = HumedadSuelo < 60 && HumedadSuelo < 100;
                CalefaccionActiva = TemperaturaActual < 20 && TemperaturaActual <= 45;
            }
            else if (TipoCultivo == "DESERTICO")
            {
                SistemaRiegoActivo = false;
                CalefaccionActiva = TemperaturaActual < 25 && TemperaturaActual <= 45;
            }

            if (HumedadSuelo >= 100)
            {
                SistemaRiegoActivo = false;
            }

            if (TemperaturaActual > 45)
            {
                CalefaccionActiva = false;
            }
        }
    }
}
