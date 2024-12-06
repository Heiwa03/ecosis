using System;
using System.Collections.Generic;

// Simulation class to manage the simulation process
public class Simulare
{
    private Ecosistem ecosistem;
    private Random random;

    public Simulare()
    {
        ecosistem = Ecosistem.Instance;
        random = new Random();
    }

    public void Initializeaza()
    {
        // Generate entities
        GenerateEntities<Planta>(5, 15, Ecosistem.PlantNames, (name, position) => new Planta(name, random.Next(5, 15), position, 0.8));
        GenerateEntities<Erbivor>(3, 10, Ecosistem.HerbivoreNames, (name, position) => new Erbivor(name, random.Next(10, 20), position, 0.7, 5, GetRandomGen()));
        GenerateEntities<Carnivor>(2, 7, Ecosistem.CarnivoreNames, (name, position) => new Carnivor(name, random.Next(15, 25), position, 0.6, 7, GetRandomGen()));
        GenerateEntities<Omnivor>(1, 5, Ecosistem.OmnivoreNames, (name, position) => new Omnivor(name, random.Next(20, 30), position, 0.9, 4, GetRandomGen()));
    }

    private void GenerateEntities<T>(int minCount, int maxCount, List<string> names, Func<string, (int, int), T> createEntity) where T : EntitateEcosistem
    {
        int count = random.Next(minCount, maxCount);
        for (int i = 0; i < count; i++)
        {
            string name = names[random.Next(names.Count)];
            var position = (random.Next(0, 10), random.Next(0, 10));
            ecosistem.AdaugaEntitate(createEntity(name, position));
        }
    }

    private string GetRandomGen()
    {
        return random.Next(0, 2) == 0 ? "Masculin" : "Feminin";
    }

    public void Ruleaza(int pasi, int skip = 1)
    {
        for (int i = 0; i < pasi; i++)
        {
            Console.WriteLine($"Pasul {i + 1}:");
            ecosistem.SimuleazaPas();
            if (i % skip == 0)
            {
                ecosistem.AfiseazaStare();
                Console.WriteLine();
            }
        }

        ecosistem.GenereazaRaportFinal();
    }
}