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
        ecosistem.AdaugaEntitate(new Erbivor("IepureM", 15, (1, 1), 0.7, 5, "Masculin"));
        ecosistem.AdaugaEntitate(new Erbivor("IepureF", 15, (4, 2), 0.7, 5, "Feminin"));
        ecosistem.AdaugaEntitate(new Carnivor("LupM", 20, (2, 2), 0.6, 7, "Masculin"));
        ecosistem.AdaugaEntitate(new Carnivor("LupF", 20, (2, 6), 0.6, 7, "Feminin"));
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