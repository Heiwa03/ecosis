# Ecosystem Simulation

This project simulates an ecosystem with various entities such as plants, herbivores, carnivores, and omnivores. The simulation includes random events like storms and droughts, and entities can interact with each other by eating, moving, and reproducing.

## Features

- **Entities**: Plants, Herbivores, Carnivores, Omnivores
- **Interactions**: Eating, Moving, Reproducing
- **Random Events**: Storms, Droughts, New Species Appearance
- **Lifespan**: Entities have a lifespan based on their survival rate

## Getting Started

### Prerequisites

- [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

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
