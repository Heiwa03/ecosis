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

    public Animal(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire, int viteza, string tipHrana)
        : base(nume, energie, pozitie, rataSupravietuire)
    {
        Viteza = viteza;
        TipHrana = tipHrana;
    }

    public abstract void Mananca();
    public abstract void Deplaseaza();
}

// Herbivore class
public class Erbivor : Animal
{
    public Erbivor(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire, int viteza)
        : base(nume, energie, pozitie, rataSupravietuire, viteza, "Plante") { }

    public override void Actioneaza()
    {
        // Logic for herbivore actions
    }

    public override void Mananca()
    {
        // Logic for eating plants
    }

    public override void Deplaseaza()
    {
        // Logic for moving
    }
}

// Carnivore class
public class Carnivor : Animal
{
    public Carnivor(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire, int viteza)
        : base(nume, energie, pozitie, rataSupravietuire, viteza, "Animale") { }

    public override void Actioneaza()
    {
        // Logic for carnivore actions
    }

    public override void Mananca()
    {
        // Logic for eating other animals
    }

    public override void Deplaseaza()
    {
        // Logic for moving
    }
}

// Omnivore class
public class Omnivor : Animal
{
    public Omnivor(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire, int viteza)
        : base(nume, energie, pozitie, rataSupravietuire, viteza, "Plante si Animale") { }

    public override void Actioneaza()
    {
        // Logic for omnivore actions
    }

    public override void Mananca()
    {
        // Logic for eating plants and animals
    }

    public override void Deplaseaza()
    {
        // Logic for moving
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

    public void SimuleazaPas()
    {
        foreach (var entitate in entitati)
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