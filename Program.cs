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

// Derived class for plants
public class Planta : EntitateEcosistem
{
    public Planta(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire)
        : base(nume, energie, pozitie, rataSupravietuire) { }

    public override void Actioneaza()
    {
        Creste();
        Reproduce();
    }

    private void Creste()
    {
        // Logic for plant growth
        Energie += 5; // Example: increase energy by 5 units
        Console.WriteLine($"{Nume} a crescut si acum are energie {Energie}");
    }

    private void Reproduce()
    {
        // Logic for plant reproduction
        if (Energie > 20) // Example: reproduce if energy is greater than 20
        {
            Energie -= 10; // Example: reduce energy by 10 units for reproduction
            Console.WriteLine($"{Nume} s-a reprodus si acum are energie {Energie}");
            // Add new plant to the ecosystem
            var newPlanta = new Planta($"{Nume} Jr.", 10, Pozitie, RataSupravietuire);
            Ecosistem.Instance.AdaugaEntitate(newPlanta);
        }
    }
}

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
}

// Herbivore class
public class Erbivor : Animal
{
    public Erbivor(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire, int viteza, string gen)
        : base(nume, energie, pozitie, rataSupravietuire, viteza, "Plante", gen) { }

    public override void Actioneaza()
    {
        Mananca();
        Deplaseaza();
    }

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
        // Logic for moving
        Pozitie = (Pozitie.x + Viteza, Pozitie.y + Viteza);
        Console.WriteLine($"{Nume} s-a deplasat la pozitia ({Pozitie.x}, {Pozitie.y})");
    }
}

// Carnivore class
public class Carnivor : Animal
{
    public Carnivor(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire, int viteza, string gen)
        : base(nume, energie, pozitie, rataSupravietuire, viteza, "Animale", gen) { }

    public override void Actioneaza()
    {
        Mananca();
        Deplaseaza();
    }

    public override void Mananca()
    {
        var erbivor = Ecosistem.Instance.GetEntitateAtPosition(Pozitie) as Erbivor;
        if (erbivor != null)
        {
            Energie += erbivor.Energie;
            Ecosistem.Instance.EliminaEntitate(erbivor);
            Console.WriteLine($"{Nume} a mancat {erbivor.Nume} si acum are energie {Energie}");
        }
    }

    public override void Deplaseaza()
    {
        // Logic for moving
        Pozitie = (Pozitie.x + Viteza, Pozitie.y + Viteza);
        Console.WriteLine($"{Nume} s-a deplasat la pozitia ({Pozitie.x}, {Pozitie.y})");
    }
}

// Omnivore class
public class Omnivor : Animal
{
    public Omnivor(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire, int viteza, string gen)
        : base(nume, energie, pozitie, rataSupravietuire, viteza, "Plante si Animale", gen) { }

    public override void Actioneaza()
    {
        Mananca();
        Deplaseaza();
    }

    public override void Mananca()
    {
        var planta = Ecosistem.Instance.GetEntitateAtPosition(Pozitie) as Planta;
        if (planta != null)
        {
            Energie += planta.Energie;
            Ecosistem.Instance.EliminaEntitate(planta);
            Console.WriteLine($"{Nume} a mancat {planta.Nume} si acum are energie {Energie}");
        }
        else
        {
            var erbivor = Ecosistem.Instance.GetEntitateAtPosition(Pozitie) as Erbivor;
            if (erbivor != null)
            {
                Energie += erbivor.Energie;
                Ecosistem.Instance.EliminaEntitate(erbivor);
                Console.WriteLine($"{Nume} a mancat {erbivor.Nume} si acum are energie {Energie}");
            }
        }
    }

    public override void Deplaseaza()
    {
        // Logic for moving
        Pozitie = (Pozitie.x + Viteza, Pozitie.y + Viteza);
        Console.WriteLine($"{Nume} s-a deplasat la pozitia ({Pozitie.x}, {Pozitie.y})");
    }
}

// Interface for interactions
public interface Interactiune
{
    void Ataca(Animal prada);
    void Reproduce();
}

// Singleton Ecosystem class to manage entities and simulate interactions
public class Ecosistem
{
    private static Ecosistem instance;
    private List<EntitateEcosistem> entitati;
    private Random random;

    private Ecosistem()
    {
        entitati = new List<EntitateEcosistem>();
        random = new Random();
    }

    public static Ecosistem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Ecosistem();
            }
            return instance;
        }
    }

    public void AdaugaEntitate(EntitateEcosistem entitate)
    {
        entitati.Add(entitate);
    }

    public void EliminaEntitate(EntitateEcosistem entitate)
    {
        entitati.Remove(entitate);
    }

    public EntitateEcosistem GetEntitateAtPosition((int x, int y) pozitie)
    {
        return entitati.FirstOrDefault(e => e.Pozitie == pozitie);
    }

    public void SimuleazaPas()
    {
        foreach (var entitate in entitati.ToList())
        {
            entitate.Actioneaza();
        }

        // Handle random events
        EvenimenteAleatorii();
    }

    private void EvenimenteAleatorii()
    {
        int eveniment = random.Next(0, 100);
        if (eveniment < 10)
        {
            Console.WriteLine("Furtuna a lovit ecosistemul!");
            // Logic for storm event
        }
        else if (eveniment < 20)
        {
            Console.WriteLine("Seceta a lovit ecosistemul!");
            // Logic for drought event
        }
        else if (eveniment < 30)
        {
            Console.WriteLine("O nouă specie a apărut în ecosistem!");
            // Logic for new species event
        }
    }

    public void AfiseazaStare()
    {
        foreach (var entitate in entitati)
        {
            Console.WriteLine($"{entitate.Nume} la pozitia ({entitate.Pozitie.x}, {entitate.Pozitie.y}) cu energie {entitate.Energie}");
        }
    }

    public void GenereazaRaportFinal()
    {
        Console.WriteLine("Raport final al ecosistemului:");
        foreach (var entitate in entitati)
        {
            Console.WriteLine($"{entitate.Nume} la pozitia ({entitate.Pozitie.x}, {entitate.Pozitie.y}) cu energie {entitate.Energie}");
        }
    }
}

// Simulation class to manage the simulation process
public class Simulare
{
    private Ecosistem ecosistem;

    public Simulare()
    {
        ecosistem = Ecosistem.Instance;
    }

    public void Initializeaza()
    {
        // Add initial entities to the ecosystem
        ecosistem.AdaugaEntitate(new Planta("Floare", 10, (0, 0), 0.8));
        ecosistem.AdaugaEntitate(new Erbivor("Iepure", 15, (1, 1), 0.7, 5, "Masculin"));
        ecosistem.AdaugaEntitate(new Erbivor("Iepure", 15, (1, 1), 0.7, 5, "Feminin"));
        ecosistem.AdaugaEntitate(new Carnivor("Lup", 20, (2, 2), 0.6, 7, "Masculin"));
        ecosistem.AdaugaEntitate(new Omnivor("Urs", 25, (3, 3), 0.9, 4, "Feminin"));
    }

    public void Ruleaza(int pasi)
    {
        for (int i = 0; i < pasi; i++)
        {
            Console.WriteLine($"Pasul {i + 1}:");
            ecosistem.SimuleazaPas();
            ecosistem.AfiseazaStare();
            Console.WriteLine();
        }

        ecosistem.GenereazaRaportFinal();
    }
}

// Main program loop
class Program
{
    static void Main(string[] args)
    {
        Simulare simulare = new Simulare();
        simulare.Initializeaza();
        simulare.Ruleaza(10); // Run the simulation for 10 steps
    }
}