namespace Peixos;

class Program
{
    static void Main()
    {
        Peixera p = new Peixera();

        p.Inicialitzar();
        p.Simular(100);
        p.Resultats();

        Console.ReadKey();
    }
}