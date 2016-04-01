namespace Problem2SweepAndPrune
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class SweepAndPruneMain
    {
        public static void Main()
        {
            var gameObjects = new List<GameObject>();
            var commandArgs = Console.ReadLine().Split();
            while (commandArgs[0] == "add")
            {
                string name = commandArgs[1];
                int x1 = int.Parse(commandArgs[2]);
                int y1 = int.Parse(commandArgs[3]);
                var gameObj = new GameObject(name, x1, y1);
                gameObjects.Add(gameObj);

                commandArgs = Console.ReadLine().Split();
            }

            if (commandArgs[0] == "start")
            {
                Run(gameObjects);
            }
        }

        private static void Run(IList<GameObject> gameObjects)
        {
            var commandArgs = Console.ReadLine().Split();
            int tick = 0;
            while (true)
            {
                string commandName = commandArgs[0];

                switch (commandName)
                {
                    case "tick":
                        break;
                    case "move":
                        Move(commandArgs[1], int.Parse(commandArgs[2]), int.Parse(commandArgs[3]), gameObjects);
                        break;
                }

                tick++;
                gameObjects = gameObjects.OrderBy(go => go.X1).ToList();
                var collidedObjects = FindCollidedObjects(gameObjects);
                foreach (var obj in collidedObjects)
                {
                    Console.WriteLine("({0}) {1} collides with {2}", tick, obj.Key, string.Join(", ", obj.Value));
                }

                commandArgs = Console.ReadLine().Split();
            }
        }

        private static MultiDictionary<GameObject, GameObject> FindCollidedObjects(IList<GameObject> gameObjects)
        {
            var collidedCandidats = new MultiDictionary<GameObject, GameObject>(true);
            for (int i = 0; i < gameObjects.Count; i++)
            {
                var currentObj = gameObjects[i];
                for (int j = i + 1; j < gameObjects.Count; j++)
                {
                    var collidedCandidate = gameObjects[j];
                    if (gameObjects[j].X1 <= currentObj.X2)
                    {
                        bool yOverlap1 = currentObj.Y1 < collidedCandidate.Y1 && currentObj.Y2 >= collidedCandidate.Y1;
                        bool yOverlap2 = collidedCandidate.Y1 < currentObj.Y1 && collidedCandidate.Y2 >= currentObj.Y1;
                        if (yOverlap1 || yOverlap2)
                        {
                           collidedCandidats.Add(currentObj, gameObjects[j]);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return collidedCandidats;
        }

        private static void Move(string name, int x1, int y1, IList<GameObject> gameObjects)
        {
            var obj = gameObjects.FirstOrDefault(o => o.Name == name);
            obj.X1 = x1;
            obj.Y1 = y1;
        }
    }
}
