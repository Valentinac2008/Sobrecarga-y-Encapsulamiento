using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
  public  class Bateria
{
    private int _porcentajeCarga;
    private int _saludBateria;
    private bool _conectadoCargador;
    private bool _modoAhorroEnergia;

    public Bateria(int carga, int salud)
    {c6
        this.PorcentajeCarga = carga;
        this.SaludBateria = salud;

        this.ConectadoCargador = false;
        this.ModoAhorroEnergia = false;
    }

    public int PorcentajeCarga
    {
        get { return _porcentajeCarga; }
        set { _porcentajeCarga = value; }
    }

    public int SaludBateria
    {
  get { return _saludBateria; }
        set { _saludBateria = value; }
    }

    public bool ConectadoCargador
    {
        get { return _conectadoCargador; }
        set { _conectadoCargador = value; }
    }

    public bool ModoAhorroEnergia
    {
        get { return _modoAhorroEnergia; }
        set { _modoAhorroEnergia = value; }
    }

    public string ESTADO_TEXTO
    {
        get
        {
            return "BATERIA: " + PorcentajeCarga + "%";
        }
    }

    public void AlternarCargador()
    {
        ConectadoCargador = !ConectadoCargador;
    }

    public void ConsumirEnergia()
    {
        PorcentajeCarga -= 1;
    }

    public void ConsumirEnergia(int gasto)
    {
        PorcentajeCarga -= gasto;
    }

    public void CicloDeCarga()
    {
        if (ConectadoCargador)
        {
            PorcentajeCarga += 10;

            if (PorcentajeCarga > SaludBateria)
            {
                PorcentajeCarga = SaludBateria;
            }
        }
    }

    public void Mostrar()
    {
        Console.WriteLine(ESTADO_TEXTO);
        Console.WriteLine("Salud: " + SaludBateria);
    }
    }
}
}
