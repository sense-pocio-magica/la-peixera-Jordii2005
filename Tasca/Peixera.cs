using System.Net.NetworkInformation;

namespace Peixos;



class  Program
{
    static void Main(string[] args)
    {
        // Clases abstractas

        Peixera peixera = new Peixera();

        Peix peix = new Peix();

        Tauro tauro = new Tauro();

        Pop pop = new Pop();

        Tortuge tortuge = new Tortuge();

        Console.ReadKey();

    }
}

class Peixera
{
    double radio = 20.0;
    double altura = 50.0;
    const double pi = Math.PI;
    double volumenCm3;

    public Peixera()
    {
        volumenCm3 = pi * Math.Pow(radio, 2) * altura;
        double litros = volumenCm3 /1000;

        Console.WriteLine($"Dimensions: radio{radio}cm, Altura {altura}cm");
        Console.WriteLine($"La pecera circular tiene una capacidad de: {litros:F2} litros")
    }
}