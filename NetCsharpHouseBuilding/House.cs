using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCsharpHouseBuilding
{
    interface IPart
    {
        string Name { get; set; }
        bool isBuilt { get; set; }
        void Build();
    }
    interface IWorker
    {
        void Work(House house);
    }
    class House
    {
        public List<IPart> Parts { get; set; }
        public bool IsComplete => Parts.TrueForAll(part => part.isBuilt);
        public House(IEnumerable<IPart> parts)
        {
            Parts = new List<IPart>(parts);
        }

    }

    abstract class PartBase : IPart
    {
        public string Name { get; set; }
        public bool isBuilt { get; set; }

        protected PartBase(string name)
        {
            Name = name;
        }
        public virtual void Build()
        {
            isBuilt = true;
            Console.WriteLine($"{Name} was built");
        }
    }


    class Basement : PartBase
    {
        public Basement() : base("Basement") { }
    }
    class Walls : PartBase
    {
        public Walls() : base("Wall") { }
    }
    class Door : PartBase
    {
        public Door() : base("Door") { }
    }
    class Window : PartBase
    {
        public Window() : base("Window") { }
    }
    class Roof : PartBase
    {
        public Roof() : base("Roof") { }
    }
    class Worker : IWorker
    {
        public void Work(House house)
        {
            foreach (var part in house.Parts)
            {
                if (!part.isBuilt)
                {
                    part.Build();
                    return;
                }
            }
        }
    }
    class TeamLeader : IWorker
    {
        public void Work(House house)
        {
            Console.WriteLine("Team Leader Report:");
            foreach (var part in house.Parts)
            {
                Console.WriteLine($"{part.Name}: {(part.isBuilt ? "Built" : "Not Built")}");
            }
        }
    }
    class Team
    {
        public List<IWorker> Workers { get; set; }
        public Team(IEnumerable<IWorker> workers)
        {
            Workers = new List<IWorker>(workers);
        }
        public void BuildHouse(House house)
        {
            while (!house.IsComplete)
            {
                foreach (var worker in Workers)
                {
                    if (house.IsComplete) break;
                    worker.Work(house);
                }
            }

            Console.WriteLine("The house is complete!");
            DrawHouse();
        }
        private void DrawHouse()
        {
            Console.WriteLine("   ^   ");
            Console.WriteLine("  / \\  ");
            Console.WriteLine(" /   \\ ");
            Console.WriteLine("/_____\\");
            Console.WriteLine("|  _  |");
            Console.WriteLine("| | | |");
            Console.WriteLine("|_|_|_|");
        }


    }
}