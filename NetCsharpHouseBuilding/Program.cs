// See https://aka.ms/new-console-template for more information
using NetCsharpHouseBuilding;

Basement basement = new Basement();
Walls wall1 = new Walls();
Walls wall2 = new Walls();
Walls wall3 = new Walls();
Walls wall4 = new Walls();
Door door = new Door();
Window window1 = new Window();
Window window2 = new Window();
Window window3 = new Window();
Window window4 = new Window();
Roof roof = new Roof();

House house=new House(new List<IPart> { basement, wall1, wall2, wall3, wall4, door, window1, window2, window3, window4, roof });


Worker worker1 = new Worker();
Worker worker2 = new Worker();
TeamLeader teamLeader = new TeamLeader();

Team team = new Team(new List<IWorker> { worker1, worker2, teamLeader });

team.BuildHouse(house);
