// Abstract class for animals
public abstract class Animal : EntitateEcosistem
{
    public int Viteza { get; set; }
    public string TipHrana { get; set; }
    public string Gen { get; set; }

    public Animal(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire, int viteza, string tipHrana, string gen)
        : base(nume, energie, pozitie, rataSupravietuire)
    {
        Viteza = viteza;
        TipHrana = tipHrana;
        Gen = gen;
    }

    public abstract void Mananca();
    public abstract void Deplaseaza();
    public abstract void Reproduce();

    public override void Actioneaza()
    {
        Mananca();
        Deplaseaza();
        Reproduce();
    }
}