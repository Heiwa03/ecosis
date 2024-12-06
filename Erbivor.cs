// Herbivore class
public class Erbivor : Animal
{
    public Erbivor(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire, int viteza, string gen)
        : base(nume, energie, pozitie, rataSupravietuire, viteza, "Plante", gen) { }

    public override void Mananca()
    {
        var planta = Ecosistem.Instance.GetEntitateAtPosition(Pozitie) as Planta;
        if (planta != null)
        {
            Energie += planta.Energie;
            Ecosistem.Instance.EliminaEntitate(planta);
            Console.WriteLine($"{Nume} a mancat {planta.Nume} si acum are energie {Energie}");
        }
    }

    public override void Deplaseaza()
    {
        // Logic for moving 1 unit in any direction
        var random = new Random();
        int dx = random.Next(-1, 2);
        int dy = random.Next(-1, 2);
        Pozitie = (Pozitie.x + dx, Pozitie.y + dy);
        Console.WriteLine($"{Nume} s-a deplasat la pozitia ({Pozitie.x}, {Pozitie.y})");
    }

    public override void Reproduce()
    {
        var other = Ecosistem.Instance.GetEntitateAtPosition(Pozitie) as Erbivor;
        if (other != null && other.Gen != this.Gen)
        {
            var newErbivor = new Erbivor($"{Nume} Jr.", 10, Pozitie, RataSupravietuire, Viteza, "Masculin");
            Ecosistem.Instance.AdaugaEntitate(newErbivor);
            Console.WriteLine($"{Nume} si {other.Nume} s-au reprodus si au creat {newErbivor.Nume}");
        }
    }
}