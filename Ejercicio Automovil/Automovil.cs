using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorAutomovil
{
   public class Automovil
{
    private string _marca;
    private bool _motorEncendido;
    private int _velocidadActual;
    private bool _cajaAutomatica;
    private bool _modoCrucero;

    public Automovil(string _marca, bool _cajaAutomatica)
    {
        this.Marca = _marca;
        this.CajaAutomatica = _cajaAutomatica;
        this.MotorEncendido = false;
        this.VelocidadActual = 0;
        this.ModoCrucero = false;
    }

    public string Marca
    {
        get { return _marca; }
        set { _marca = value; }
    }

    public bool MotorEncendido
    {
        get { return _motorEncendido; }
        set { _motorEncendido = value; }
    }

    public int VelocidadActual
    {
        get { return _velocidadActual; }
        set { _velocidadActual = value; }
    }

    public bool CajaAutomatica
    {
        get { return _cajaAutomatica; }
        set { _cajaAutomatica = value; }
    }

    public bool ModoCrucero
    {
        get { return _modoCrucero; }
        set { _modoCrucero = value; }
    }

    public string IDENTIFICADOR
    {
        get
        {
            string tipoCaja;

            if (CajaAutomatica)
            {
                tipoCaja = "AUTO";
            }
            else
            {
                tipoCaja = "MAN";
            }

            return Marca.Substring(0, 3).ToUpper() + "-" + tipoCaja + "-2026";
        }
    }

    public void EncenderApagar()
    {
        MotorEncendido = !MotorEncendido;

        if (!MotorEncendido)
        {
            VelocidadActual = 0;
            ModoCrucero = false;
        }
    }

    public void Acelerar()
    {
        if (MotorEncendido)
        {
            VelocidadActual += 10;
        }
    }

    public void Acelerar(int km)
    {
        if (MotorEncendido)
        {
            VelocidadActual += km;
        }
    }

    public void Frenar()
    {
        VelocidadActual = 0;
        ModoCrucero = false;
    }

    public void Frenar(int km)
    {
        VelocidadActual -= km;

        if (VelocidadActual < 0)
        {
            VelocidadActual = 0;
        }

        ModoCrucero = false;
    }

    public void MostrarDatos()
    {
        Console.WriteLine("Motor: " + MotorEncendido);
        Console.WriteLine("Velocidad: " + VelocidadActual);
        Console.WriteLine("Modo crucero: " + ModoCrucero);
    }
    }
}
