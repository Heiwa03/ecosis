using System;
using System.Collections.Generic;
using System.Linq;

public class Ecosistem
{
    private static Ecosistem instance;
    private List<EntitateEcosistem> entitati;
    private Random random;
    private Logger logger;

    public static List<string> PlantNames = new List<string> { "Floare", "Iarbă", "Copac", "Tufă" };
    public static List<string> HerbivoreNames = new List<string> { "Iepure", "Cerb", "Caprioară" };
    public static List<string> CarnivoreNames = new List<string> { "Lup", "Leu", "Tigru" };
    public static List<string> OmnivoreNames = new List<string> { "Urs", "Porc", "Câine" };

    private Ecosistem()
    {
        entitati = new List<EntitateEcosistem>();
        random = new Random();
        logger = new Logger();
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
        logger.LogAction("Added", entitate.Pozitie, entitate.Nume);
    }

    public void EliminaEntitate(EntitateEcosistem entitate)
    {
        entitati.Remove(entitate);
        logger.LogAction("Removed", entitate.Pozitie, entitate.Nume);
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
            int numEntitiesToKill = random.Next(0, entitati.Count + 1);
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
            int numEntitiesToKill = random.Next(0, entitati.Count + 1);
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
            AdaugaNouaSpecie();
        }
    }

    private void AdaugaNouaSpecie()
    {
        int specieType = random.Next(0, 4);
        EntitateEcosistem newEntity = null;

        switch (specieType)
        {
            case 0:
                string plantName = PlantNames[random.Next(PlantNames.Count)];
                newEntity = new Planta(plantName, random.Next(5, 15), (random.Next(0, 10), random.Next(0, 10)), 0.8);
                break;
            case 1:
                string herbivoreName = HerbivoreNames[random.Next(HerbivoreNames.Count)];
                newEntity = new Erbivor(herbivoreName, random.Next(10, 20), (random.Next(0, 10), random.Next(0, 10)), 0.7, 5, GetRandomGen());
                break;
            case 2:
                string carnivoreName = CarnivoreNames[random.Next(CarnivoreNames.Count)];
                newEntity = new Carnivor(carnivoreName, random.Next(15, 25), (random.Next(0, 10), random.Next(0, 10)), 0.6, 7, GetRandomGen());
                break;
            case 3:
                string omnivoreName = OmnivoreNames[random.Next(OmnivoreNames.Count)];
                newEntity = new Omnivor(omnivoreName, random.Next(20, 30), (random.Next(0, 10), random.Next(0, 10)), 0.9, 4, GetRandomGen());
                break;
        }

        if (newEntity != null)
        {
            AdaugaEntitate(newEntity);
            Console.WriteLine($"O nouă specie {newEntity.Nume} a apărut la pozitia ({newEntity.Pozitie.x}, {newEntity.Pozitie.y})");
        }
    }

    private string GetRandomGen()
    {
        return random.Next(0, 2) == 0 ? "Masculin" : "Feminin";
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

    public void PlotData()
    {
        logger.PlotData();
    }
}