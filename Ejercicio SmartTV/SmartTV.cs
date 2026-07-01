using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSmartTV
{
 public class SmartTV
{
    private string marca;
    private int pulgadas;
    private bool encendido;
    private int canalActual;
    private int volumen;
    private bool esPremium;

    public SmartTV(string marca, int pulgadas, bool esPremium)
    {this.Marca = marca;
        this.Pulgadas = pulgadas;
        this.EsPremium = esPremium;

        this.Encendido = false;
        this.CanalActual = 1;
        this.Volumen = 20;
    }

    public string Marca
    {
        get { return marca; }
        set { marca = value; }
    }

    public int Pulgadas
    {
        get { return pulgadas; }
        set { pulgadas = value; }
    }

    public bool Encendido
    {
        get { return encendido; }
        set { encendido = value; }
    }

    public int CanalActual
    {
get { return canalActual; }
        set { canalActual = value; }
    }

    public int Volumen
    {
        get { return volumen; }
        set { volumen = value; }
    }

    public bool EsPremium
    {
        get { return esPremium; }
        set { esPremium = value; }
    }

    public string CODIGO_CONFIG
    {
        get
        {
            if (EsPremium)
            {
                return Marca + "-" + Pulgadas + "-PREM";
            }
            else
            {
                return Marca + "-" + Pulgadas + "-STD";
            }
        }
    }

    public void Power()
    {
        Encendido = !Encendido;
    }

    public void CambiarCanal()
    {
        if (Encendido)
        {
            CanalActual++;
        }
    }

    public void CambiarCanal(int canal)
    {
        if (Encendido)
        {
            CanalActual = canal;
        }
    }

    public void RegularVolumen(bool subir)
    {
        if (Encendido)
        {
            if (subir)
            {
                Volumen += 2;
            }
            else
            {
                Volumen -= 2;
            }
        }
    }

    public void MostrarEstado()
    {
        Console.WriteLine("Canal: " + CanalActual);
        Console.WriteLine("Volumen: " + Volumen);
    }
    }
}
}
