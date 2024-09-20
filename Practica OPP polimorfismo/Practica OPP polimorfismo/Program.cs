// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

// Clase base abstracta para todos los empleados
public abstract class Empleado
{
    public string Nombre { get; set; }
    public abstract double CalcularSalario();
}

// Clase para docentes por hora
public class DocentePorHora : Empleado
{
    public int HorasTrabajadas { get; set; }
    private const double TarifaPorHora = 800;

    public override double CalcularSalario()
    {
        return HorasTrabajadas * TarifaPorHora;
    }
}

// Clase base para empleados con salario fijo y bonificación
public abstract class EmpleadoConBonificacion : Empleado
{
    public double SalarioBase { get; set; }
    public bool AlcanzoMeta { get; set; }

    public override double CalcularSalario()
    {
        return AlcanzoMeta ? SalarioBase : SalarioBase / 2;
    }
}

// Clase para docentes de contrato fijo
public class DocenteContratoFijo : EmpleadoConBonificacion
{
}

// Clase para empleados administrativos
public class EmpleadoAdministrativo : EmpleadoConBonificacion
{
}

class Program
{
    static void Main(string[] args)
    {
        List<Empleado> empleados = new List<Empleado>
        {
            new DocentePorHora { Nombre = "Juan Pérez", HorasTrabajadas = 40 },
            new DocenteContratoFijo { Nombre = "María Gómez", SalarioBase = 50000, AlcanzoMeta = true },
            new EmpleadoAdministrativo { Nombre = "Carlos Rodríguez", SalarioBase = 40000, AlcanzoMeta = false }
        };

        foreach (var empleado in empleados)
        {
            Console.WriteLine($"Empleado: {empleado.Nombre}");
            Console.WriteLine($"Salario: {empleado.CalcularSalario():C}");
            Console.WriteLine();
        }
    }
}