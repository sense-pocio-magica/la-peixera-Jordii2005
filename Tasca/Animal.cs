namespace Peixos;

abstract class Animal
{
    public int X;
    public int Y;
    public Sexe Sexe;
    public Direccio Direccio;
    public bool Mort = false;

    public abstract string Tipus();

    public virtual void Moure(int mida)
    {
        switch (Direccio)
        {
            case Direccio.Amunt: Y--; break;
            case Direccio.Avall: Y++; break;
            case Direccio.Esquerra: X--; break;
            case Direccio.Dreta: X++; break;
        }

        if (X < 0) X = mida - 1;
        if (X >= mida) X = 0;
        if (Y < 0) Y = mida - 1;
        if (Y >= mida) Y = 0;
    }
}