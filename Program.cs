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
    }
    class Program
    {
        static void Main(string[] args)
        {
            var dinosaurs = new List<Dinosaurs>();
            {
                dinosaurs.Add(new Dinosaurs()
                {
                    name = "Littlefoot",
                    species = "Apatosaurus",
                    dietType = "herbivore",
                    whenAcquired = DateTime.Now.AddMonths(-3),
                    weight = 38000,
                    enclosureNumber = 1,
                });

                dinosaurs.Add(new Dinosaurs()
                {
                    name = "Cera",
                    species = "Triceratops",
                    dietType = "herbivore",
                    whenAcquired = DateTime.Now.AddMonths(-2),
                    weight = 20000,
                    enclosureNumber = 2,
                });

                dinosaurs.Add(new Dinosaurs()
                {
                    name = "Chomper",
                    species = "Tyrannosaurus Rex",
                    dietType = "carnivore",
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
                        Console.WriteLine($"{dino.name} is a {dino.species}, which is a {dino.dietType}. It was acquired {dino.whenAcquired}, weighs {dino.weight} lbs, and is located in enclosure {dino.enclosureNumber}. "); ;
                    }
                }

                if (choice == "Add")
                {
                    Console.Write("What is it's name?: ");
                    var name = Console.ReadLine();
                    Console.Write("What is it's species?: ");
                    var species = Console.ReadLine();
                    Console.Write("What is it's diet type?: ");
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
                    Console.Write("Name: ");
                    var dinoNameToSearchFor = Console.ReadLine();
                    var foundDino = dinosaurs.FirstOrDefault(dinosaurs => dinosaurs.name == dinoNameToSearchFor);
                    if (foundDino != null)
                    {
                        Console.WriteLine($"{foundDino.name} is a {foundDino.species}, which is a {foundDino.dietType}. It was acquired {foundDino.whenAcquired}, weighs {foundDino.weight} lbs, and is located in enclosure {foundDino.enclosureNumber}. "); ;
                        Console.Write("Are you sure you want to remove this dinosaur?: ");
                        var answer = Console.ReadLine();
                        if (answer == "Yes")
                        {
                            dinosaurs.Remove(foundDino);
                        }

                    }
                    else
                    {
                        Console.WriteLine($"No dinosaur found with the name {dinoNameToSearchFor}.");
                    }



                }

                if (choice == "Transfer")
                {
                    Console.Write("What dinosaur would you like to transfer?: ");
                    var dinoNameToTransfer = Console.ReadLine();
                    var foundDinoToTransfer = dinosaurs.FindIndex(dinosaurs => dinosaurs.name == dinoNameToTransfer);
                    Console.Write($"What enclosure would you like to transfer it to?:  ");
                    var enclosureToTransferTo = int.Parse(Console.ReadLine());
                    dinosaurs[foundDinoToTransfer].enclosureNumber = enclosureToTransferTo;



                }

                if (choice == "Summary")
                {
                    int herbDinos = dinosaurs.Where(dinosaur => dinosaur.dietType == "herbivore").Count();
                    int carnDinos = dinosaurs.Where(dinosaurs => dinosaurs.dietType == "carnivore").Count();
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

