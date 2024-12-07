# Ecosystem Simulation

This project simulates an ecosystem with various entities such as plants, herbivores, carnivores, and omnivores. The simulation includes random events like storms and droughts, and entities can interact with each other by eating, moving, and reproducing.

## Features

- **Entities**: Plants, Herbivores, Carnivores, Omnivores
- **Interactions**: Eating, Moving, Reproducing
- **Random Events**: Storms, Droughts, New Species Appearance
- **Lifespan**: Entities have a lifespan based on their survival rate

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/yourusername/ecosystem-simulation.git
   cd ecosystem-simulation
   ```
2. Restore the dependencies:
   ```sh
   dotnet restore
   ```

### Running the simulation 
To run the simulation, use the following command:
   ```sh
   dotnet run
   ```
The simulation will run for 10 steps by default. You can modify the number of steps in the Program.cs file.

## UML Diagram
![Source](//www.plantuml.com/plantuml/png/hPFDRjim3CVlVWeTNMnvWs9eq6KVGBS5oR3Bi0DZim41YJ8eAWTtU_V9beqfCTeUbfEb7ob-_4tU1GNHw6m5Xw02ZPh6GWXcmqeAYfl61mgApZnLngnCSY8-cg_HuNWdrkIBSgHyhnDuEz0Ri_KzwOHR7myMpGuKzh4JE15g91cCRyp9KslMZP9dX1xgc-fFLUKojXPO8USUSptG8uOE-9c7oItJUy6WM98TTkBRs62EVz7lcic1BHBz8CKUofw_K_T9WC_OH-GNIli23DpakYRq7hkK3w4lQLdRQufiv40dB-Rflz8K0Uz1-BeHlxah1xmSmeTqkLrCw3k36T7ej0DklJCoVWfLMuX7c1_NYoX5BHjBZlXLtmLEKw4pNEisKINFzR_LA7BioKKxYB25K9UvJyZaa5E4P5OlH6UpyKYZT7i5mTAG1X9biEoWyw8VYC4MKkPy89YLB9J5-VIIU9-PbC1Il_XjkOcXnN9xnHy5tFaW4DTvUNx-6bsNyjt-NgscpN_EcjUrof-CfiKesJZR2pYDPtKHSbQccWyPJprKTyXjTFOl)

## Project Structure
- Ecosistem.cs: Manages the ecosystem and handles random events.
- EntitateEcosistem.cs: Abstract base class for all ecosystem entities.
- Planta.cs: Represents a plant entity.
- Animal.cs: Abstract base class for all animal entities.
- Erbivor.cs: Represents a herbivore entity.
- Carnivor.cs: Represents a carnivore entity.
- Omnivor.cs: Represents an omnivore entity.
- Simulare.cs: Manages the simulation process.
- Program.cs: Main program loop.

## Classes and Methods
### Ecosistem
- AdaugaEntitate(EntitateEcosistem entitate): Adds an entity to the ecosystem.
- EliminaEntitate(EntitateEcosistem entitate): Removes an entity from the ecosystem.
- GetEntitateAtPosition((int x, int y) pozitie): Gets an entity at a specific position.
- SimuleazaPas(): Simulates a single step in the ecosystem.
- EvenimenteAleatorii(): Handles random events like storms and droughts.
- AfiseazaStare(): Displays the current state of the ecosystem.
- GenereazaRaportFinal(): Generates a final report of the ecosystem.

### EntitateEcosistem
- Nume: Name of the entity.
- Energie: Energy level of the entity.
- Pozitie: Position of the entity in the ecosystem.
- RataSupravietuire: Survival rate of the entity.
- Actioneaza(): Abstract method to define the actions of the entity.

### Planta
- Creste(): Logic for plant growth.
- Reproduce(): Logic for plant reproduction.

### Animal
- Viteza: Speed of the animal.
- TipHrana: Type of food the animal eats.
- Gen: Gender of the animal.
- Lifespan: Lifespan of the animal.
- Mananca(): Abstract method for eating.
- Deplaseaza(): Abstract method for moving.
- Reproduce(): Abstract method for reproducing.

### Erbivor
- Mananca(): Logic for eating plants.
- Deplaseaza(): Logic for moving.
- Reproduce(): Logic for reproducing with another herbivore.

### Carnivor
- Mananca(): Logic for eating herbivores.
- Deplaseaza(): Logic for moving.
- Reproduce(): Logic for reproducing with another carnivore.

### Omnivor
- Mananca(): Logic for eating plants and herbivores.
- Deplaseaza(): Logic for moving.
- Reproduce(): Logic for reproducing with another omnivore.

### Simulare
- Initializeaza(): Initializes the ecosystem with entities.
- Ruleaza(int pasi): Runs the simulation for a specified number of steps.

## Dificultăți Întâlnite și Soluțiile Adoptate
### Dificultate 1: Gestionarea Duratei de Viață a Entităților
Problemă: Inițial, durata de viață a entităților nu era gestionată corect, ceea ce ducea la entități care trăiau indefinit.

Soluție: Am adăugat un atribut Lifespan pentru fiecare entitate, care este inițializat pe baza rataSupravietuire. În fiecare pas de simulare, Lifespan este decrementat, iar entitatea este eliminată din ecosistem când Lifespan ajunge la zero.

### Dificultate 2: Implementarea Evenimentelor Aleatorii
Problemă: Gestionarea evenimentelor aleatorii, cum ar fi furtunile și secetele, a fost dificilă deoarece trebuia să se asigure că entitățile sunt eliminate corect și că probabilitatea evenimentelor este respectată.

Soluție: Am creat metoda EvenimenteAleatorii în clasa Ecosistem, care gestionează logica pentru fiecare tip de eveniment. Am folosit Random pentru a determina dacă un eveniment are loc și pentru a selecta entitățile care sunt afectate.

### Dificultate 3: Reproducerea Entităților
Problemă: Implementarea logicii de reproducere pentru entități a fost complexă, deoarece trebuia să se asigure că entitățile de același tip și genuri diferite se pot reproduce corect.

Soluție: Am adăugat metoda Reproduce în clasa Animal și am suprascris-o în clasele derivate (Erbivor, Carnivor, Omnivor). Metoda verifică dacă există o entitate de același tip și gen diferit în aceeași poziție și creează o nouă entitate dacă condițiile sunt îndeplinite.

