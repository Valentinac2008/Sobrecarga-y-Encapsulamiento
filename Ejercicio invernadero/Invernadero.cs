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

    public Invernadero(string _nombreSector, string _tipoCultivo)
    {
        this.NombreSector = _nombreSector;
        this.TipoCultivo = _tipoCultivo;

        this.TemperaturaActual = 25;
        this.HumedadSuelo = 50;
    }

    public string NombreSector
    {
        get { return _nombreSector; }
        set { _nombreSector = value; }
    }

    public int TemperaturaActual
    {
        get { return _temperaturaActual; }
        set { _temperaturaActual = value; }
    }

    public int HumedadSuelo
    {
        get { return _humedadSuelo; }
        set { _humedadSuelo = value; }
    }

    public bool SistemaRiegoActivo
    {
        get { return _sistemaRiegoActivo; }
        set { _sistemaRiegoActivo = value; }
    }

    public bool CalefaccionActiva
    {
        get { return _calefaccionActiva; }
        set { _calefaccionActiva = value; }
    }

    public string TipoCultivo
    {
        get { return _tipoCultivo; }
        set { _tipoCultivo = value; }
    }

    public string REPORTE_ESTADO
    {
        get
        {
            return "SECTOR: " + NombreSector +
                   " CULTIVO: " + TipoCultivo;
        }
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
            if (HumedadSuelo < 60)
            {
                SistemaRiegoActivo = true;
            }
        }
    }

    public void Mostrar()
    {
        Console.WriteLine(REPORTE_ESTADO);
        Console.WriteLine("Temperatura: " + TemperaturaActual);
        Console.WriteLine("Humedad: " + HumedadSuelo);
    }
}
    }
}
