// Derived class for plants
public class Planta : EntitateEcosistem
{
    public Planta(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire)
        : base(nume, energie, pozitie, rataSupravietuire) { }

    public override void Actioneaza()
    {
        Creste();
    }

    private void Creste()
    {
        // Logic for plant growth
        Energie += 5; // Example: increase energy by 5 units
        Console.WriteLine($"{Nume} a crescut si acum are energie {Energie}");
    }
}