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

    public Microondas(int _potencia)
    {
        this.Potencia = _potencia;
        this.TiempoSegundos = 0;
        this.PuertaAbierta = false;
        this.EnFuncionamiento = false;
    }

    public int Potencia
    {
        get { return _potencia; }
        set { _potencia = value; }
    }

    public int TiempoSegundos
    {
        get { return _tiempoSegundos; }
        set { _tiempoSegundos = value; }
    }

    public bool PuertaAbierta
    {
        get { return _puertaAbierta; }
        set { _puertaAbierta = value; }
    }

    public bool EnFuncionamiento
    {
        get { return _enFuncionamiento; }
        set { _enFuncionamiento = value; }
    }

    public string PANTALLA_TIEMPO
    {
        get
        {
            int minutos = TiempoSegundos / 60;
            int segundos = TiempoSegundos % 60;

            return minutos.ToString("00") + ":" + segundos.ToString("00");
        }
    }

    public void AgregarTiempo()
    {
        TiempoSegundos += 30;
    }

    public void AgregarTiempo(int segundos)
    {
        TiempoSegundos += segundos;
    }

    public void Iniciar()
    {
        if (!PuertaAbierta && TiempoSegundos > 0)
        {
            EnFuncionamiento = true;
        }
    }

    public void Detener()
    {
        EnFuncionamiento = false;
    }

    public void AbrirCerrarPuerta()
    {
        PuertaAbierta = !PuertaAbierta;
    }

    public void Mostrar()
    {
        Console.WriteLine("Tiempo: " + PANTALLA_TIEMPO);
        Console.WriteLine("Potencia: " + Potencia);
        Console.WriteLine("Puerta abierta: " + PuertaAbierta);
    }
}
    }
}
