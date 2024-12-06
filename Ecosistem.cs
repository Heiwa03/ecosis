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
        int eveniment = random.Next(0, 4000);
        if (eveniment < 10)
        {
            Console.WriteLine("Furtuna a lovit ecosistemul!");
            // Logic for storm event
            int numEntitiesToKill = random.Next(0, entitati.Count/2);
            for (int i = 0; i < numEntitiesToKill; i++)
            {
                if (entitati.Count == 0) break;
                int indexToKill = random.Next(0, entitati.Count);
                var entity = entitati[indexToKill];
                Console.WriteLine($"{entity.Nume} a fost ucis de furtuna!");
                EliminaEntitate(entity);
            }
        }
        else if (eveniment < 20)
        {
            Console.WriteLine("Seceta a lovit ecosistemul!");
            // Logic for drought event
            int numEntitiesToKill = random.Next(0, entitati.Count/2);
            for (int i = 0; i < numEntitiesToKill; i++)
            {
                if (entitati.Count == 0) break;
                int indexToKill = random.Next(0, entitati.Count);
                var entity = entitati[indexToKill];
                Console.WriteLine($"{entity.Nume} a fost ucis de seceta!");
                EliminaEntitate(entity);
            }
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