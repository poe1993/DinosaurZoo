using System;
using System.Collections.Generic;
using System.Linq;

namespace DinosaurZoo
{
    class Dinosaurs
    {
        public string name { get; set; }
        public string species { get; set; }

        public string dietType { get; set; }
        public DateTime whenAcquired { get; set; } = new DateTime();
        public int weight { get; set; }
        public int enclosureNumber { get; set; }
        public string Description()
        {
            var description = $"{name} is a {species}, which is a {dietType}. It was acquired {whenAcquired}, weighs {weight} lbs, and is located in enclosure {enclosureNumber}. ";
            return description;
        }
    }
    class Program
    {
        static Dinosaurs PromptandFind(List<Dinosaurs> dinoToSearchWithin)
        {
            Console.Write("Name: ");
            var dinoName = Console.ReadLine();
            var foundDino = dinoToSearchWithin.FirstOrDefault(dinosaurs => dinosaurs.name == dinoName);
            return foundDino;
        }
        static void Main(string[] args)
        {
            var dinosaurs = new List<Dinosaurs>();
            {
                dinosaurs.Add(new Dinosaurs()
                {
                    name = "Littlefoot",
                    species = "Apatosaurus",
                    dietType = "Herbivore",
                    whenAcquired = DateTime.Now.AddMonths(-3),
                    weight = 38000,
                    enclosureNumber = 1,
                });

                dinosaurs.Add(new Dinosaurs()
                {
                    name = "Cera",
                    species = "Triceratops",
                    dietType = "Herbivore",
                    whenAcquired = DateTime.Now.AddMonths(-2),
                    weight = 20000,
                    enclosureNumber = 2,
                });

                dinosaurs.Add(new Dinosaurs()
                {
                    name = "Chomper",
                    species = "Tyrannosaurus Rex",
                    dietType = "Carnivore",
                    whenAcquired = DateTime.Now.AddMonths(-1),
                    weight = 29000,
                    enclosureNumber = 3
                });
            };


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to our dinosaur zoo!");
            Console.WriteLine();
            Console.WriteLine();

            var quitApplication = false;
            while (quitApplication == false)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("View");
                Console.WriteLine("Add");
                Console.WriteLine("Remove");
                Console.WriteLine("Transfer");
                Console.WriteLine("Summary");
                Console.WriteLine("Quit");
                Console.WriteLine();
                Console.Write("Choice: ");
                var choice = Console.ReadLine();

                if (choice == "View")
                {
                    var dinosaursInOrder = dinosaurs.OrderBy(dinosaurs => dinosaurs.whenAcquired);
                    foreach (var dino in dinosaursInOrder)
                    {
                        Console.WriteLine(dino.Description());
                    }
                }

                if (choice == "Add")
                {
                    Console.Write("What is it's name?: ");
                    var name = Console.ReadLine();
                    Console.Write("What is it's species?: ");
                    var species = Console.ReadLine();
                    Console.Write("What is it's diet type? Herbivore or Carnivore?: ");
                    var diet = Console.ReadLine();
                    Console.Write("How much does it weigh?: ");
                    var weight = int.Parse(Console.ReadLine());
                    Console.Write("Which enclosure would you like it to be in?: ");
                    var enclosure = int.Parse(Console.ReadLine());


                    var dinosaur = new Dinosaurs()
                    {
                        name = name,
                        species = species,
                        dietType = diet,
                        weight = weight,
                        whenAcquired = DateTime.Now,
                        enclosureNumber = enclosure,

                    };

                    dinosaurs.Add(dinosaur);

                }

                if (choice == "Remove")
                {
                    var foundDino = PromptandFind(dinosaurs);
                    if (foundDino != null)
                    {
                        Console.WriteLine(foundDino.Description());
                        Console.Write("Are you sure you want to remove this dinosaur? Yes or No: ");
                        var answer = Console.ReadLine();
                        if (answer == "Yes")
                        {
                            dinosaurs.Remove(foundDino);
                        }

                    }
                    else
                    {
                        Console.WriteLine($"No dinosaur found with that name.");
                    }



                }

                if (choice == "Transfer")
                {
                    {
                        var foundDino = PromptandFind(dinosaurs);
                        if (foundDino != null)
                        {
                            Console.WriteLine(foundDino.Description());
                            Console.Write("Are you sure you want to remove this dinosaur? Yes or No : ");
                            var answer = Console.ReadLine();
                            if (answer == "Yes")
                            {
                                Console.Write("New enclosure: ");
                                var newEnclosureNumber = int.Parse(Console.ReadLine());
                                foundDino.enclosureNumber = newEnclosureNumber;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No dinosaur found with that name.");
                        }
                    }
                }

                if (choice == "Summary")
                {
                    int herbDinos = dinosaurs.Count(dinosaurs => dinosaurs.dietType == "Herbivore");
                    int carnDinos = dinosaurs.Count(dinosaurs => dinosaurs.dietType == "Carnivore");
                    Console.WriteLine($"There are currently {herbDinos} herbivore(s) and {carnDinos} carnivore(s) at the zoo.");
                }

                if (choice == "Quit")
                {
                    quitApplication = true;
                }

            };
            Console.WriteLine("...Have a good day...");
        }
    }
}