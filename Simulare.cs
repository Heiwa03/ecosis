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
        // Generate a random number of entities
        int numPlante = random.Next(5, 15);
        int numErbivori = random.Next(3, 10);
        int numCarnivori = random.Next(2, 7);
        int numOmnivori = random.Next(1, 5);

        // Add plants
        for (int i = 0; i < numPlante; i++)
        {
            ecosistem.AdaugaEntitate(new Planta($"Floare{i}", random.Next(5, 15), (random.Next(0, 10), random.Next(0, 10)), 0.8));
        }

        // Add herbivores
        for (int i = 0; i < numErbivori; i++)
        {
            ecosistem.AdaugaEntitate(new Erbivor($"Iepure{i}", random.Next(10, 20), (random.Next(0, 10), random.Next(0, 10)), 0.7, 5, GetRandomGen()));
        }

        // Add carnivores
        for (int i = 0; i < numCarnivori; i++)
        {
            ecosistem.AdaugaEntitate(new Carnivor($"Lup{i}", random.Next(15, 25), (random.Next(0, 10), random.Next(0, 10)), 0.6, 7, GetRandomGen()));
        }

        // Add omnivores
        for (int i = 0; i < numOmnivori; i++)
        {
            ecosistem.AdaugaEntitate(new Omnivor($"Urs{i}", random.Next(20, 30), (random.Next(0, 10), random.Next(0, 10)), 0.9, 4, GetRandomGen()));
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