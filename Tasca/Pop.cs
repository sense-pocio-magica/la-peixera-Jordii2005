namespace Peixos;

class Pop : Animal
{
    public override string Tipus()
    {
        return "Pop";
    }

    public override void Moure(int mida)
    {
        if (Direccio == Direccio.Amunt || Direccio == Direccio.Avall)
            Direccio = Direccio.Esquerra;

        base.Moure(mida);
    }
}