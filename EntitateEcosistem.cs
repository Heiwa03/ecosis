// Abstract base class for all ecosystem entities
public abstract class EntitateEcosistem
{
    public string Nume { get; set; }
    public int Energie { get; set; }
    public (int x, int y) Pozitie { get; set; }
    public double RataSupravietuire { get; set; }

    public EntitateEcosistem(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire)
    {
        Nume = nume;
        Energie = energie;
        Pozitie = pozitie;
        RataSupravietuire = rataSupravietuire;
    }

    public abstract void Actioneaza();
}