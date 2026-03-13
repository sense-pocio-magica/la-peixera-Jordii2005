namespace Peixos;

class Tauro : Animal
{
    public int Vida = 75;

    public override string Tipus()
    {
        return "Tauro";
    }

    public override void Moure(int mida)
    {
        base.Moure(mida);

        Vida--;

        if (Vida <= 0)
            Mort = true;
    }
}