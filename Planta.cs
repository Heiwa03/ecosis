// Derived class for plants
public class Planta : EntitateEcosistem
{
    public int Lifespan { get; set; }
    private static Random random = new Random();

    public Planta(string nume, int energie, (int x, int y) pozitie, double rataSupravietuire)
        : base(nume, energie, pozitie, rataSupravietuire)
    {
        Lifespan = (int)(rataSupravietuire * 100); // Example: lifespan is based on survival rate
    }

    public override void Actioneaza()
    {
        Creste();
        Lifespan--;

        if (Lifespan <= 0)
        {
            Ecosistem.Instance.EliminaEntitate(this);
            Console.WriteLine($"{Nume} a murit de batranete.");
            Reproduce();
        }
    }

    private void Creste()
    {
        // Logic for plant growth
        Energie += 5; // Example: increase energy by 5 units
        Console.WriteLine($"{Nume} a crescut si acum are energie {Energie}");
    }

    private void Reproduce()
    {
        // 20% chance to reproduce
        if (random.NextDouble() <= 0.2)
        {
            int numNewPlants = random.Next(1, 4); // Random number of new plants between 1 and 3
            for (int i = 0; i < numNewPlants; i++)
            {
                // Generate a random nearby position
                int dx = random.Next(-1, 2);
                int dy = random.Next(-1, 2);
                var newPosition = (Pozitie.x + dx, Pozitie.y + dy);

                // Create and add the new plant to the ecosystem
                var newPlanta = new Planta($"{Nume} Jr.", 10, newPosition, RataSupravietuire);
                Ecosistem.Instance.AdaugaEntitate(newPlanta);
                Console.WriteLine($"{Nume} a produs o noua planta la pozitia ({newPosition})");
            }
        }
    }
}