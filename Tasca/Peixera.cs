using System;
using System.Collections.Generic;
using System.Linq;

namespace Peixos;

class Peixera
{
    int mida = 20;
    List<Animal> animals = new List<Animal>();
    Random rnd = new Random();

    public void Inicialitzar()
    {
        for (int i = 0; i < 50; i++)
        {
            animals.Add(CrearAnimal<Peix>(Sexe.Mascle));
            animals.Add(CrearAnimal<Peix>(Sexe.Femella));
        }

        for (int i = 0; i < 10; i++)
        {
            animals.Add(CrearAnimal<Tauro>(Sexe.Mascle));
            animals.Add(CrearAnimal<Tauro>(Sexe.Femella));
        }

        for (int i = 0; i < 15; i++)
            animals.Add(CrearAnimal<Pop>(Sexe.Cap));

        for (int i = 0; i < 6; i++)
            animals.Add(CrearAnimal<Tortuga>(rnd.Next(2) == 0 ? Sexe.Mascle : Sexe.Femella));
    }

    Animal CrearAnimal<T>(Sexe sexe) where T : Animal, new()
    {
        return new T
        {
            X = rnd.Next(mida),
            Y = rnd.Next(mida),
            Sexe = sexe,
            Direccio = (Direccio)rnd.Next(4)
        };
    }

    public void Simular(int rondes)
    {
        for (int r = 0; r < rondes; r++)
        {
            foreach (var a in animals)
                if (!a.Mort)
                    a.Moure(mida);

            Interaccions();

            animals.RemoveAll(a => a.Mort);
        }
    }

    void Interaccions()
    {
        var grups = animals.Where(a => !a.Mort).GroupBy(a => (a.X, a.Y));

        foreach (var grup in grups)
        {
            var llista = grup.ToList();

            for (int i = 0; i < llista.Count; i++)
            {
                for (int j = i + 1; j < llista.Count; j++)
                {
                    var a = llista[i];
                    var b = llista[j];

                    if (a.Mort || b.Mort) continue;

                    if (a.Tipus() == b.Tipus() && a.Sexe != Sexe.Cap && a.Sexe != b.Sexe)
                        animals.Add(CrearFill(a));

                    if (a.Tipus() == b.Tipus() && a.Sexe == b.Sexe && a.Sexe != Sexe.Cap)
                    {
                        if (!(a is Pop))
                        {
                            a.Mort = true;
                            b.Mort = true;
                        }
                        else
                        {
                            a.Direccio = (Direccio)rnd.Next(4);
                            b.Direccio = (Direccio)rnd.Next(4);
                        }
                    }

                    if (a is Tauro && !(b is Tortuga))
                        b.Mort = true;

                    if (b is Tauro && !(a is Tortuga))
                        a.Mort = true;

                    if (a is Tauro && b is Tortuga)
                        a.Direccio = (Direccio)rnd.Next(4);

                    if (b is Tauro && a is Tortuga)
                        b.Direccio = (Direccio)rnd.Next(4);
                }
            }
        }
    }

    Animal CrearFill(Animal pare)
    {
        Animal fill;

        if (pare is Peix) fill = new Peix();
        else if (pare is Tauro) fill = new Tauro();
        else if (pare is Tortuga) fill = new Tortuga();
        else return null;

        fill.X = pare.X;
        fill.Y = pare.Y;
        fill.Sexe = rnd.Next(2) == 0 ? Sexe.Mascle : Sexe.Femella;
        fill.Direccio = (Direccio)rnd.Next(4);

        return fill;
    }

    public void Resultats()
    {
        Console.WriteLine("RESULTATS FINALS");
        Console.WriteLine("Peixos: " + animals.Count(a => a is Peix));
        Console.WriteLine("Taurons: " + animals.Count(a => a is Tauro));
        Console.WriteLine("Pops: " + animals.Count(a => a is Pop));
        Console.WriteLine("Tortugues: " + animals.Count(a => a is Tortuga));
    }
}