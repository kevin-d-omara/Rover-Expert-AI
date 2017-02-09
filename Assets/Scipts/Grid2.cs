using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RoverExpertAI
{
    public class Grid2
    {
        // width of the 'wall' cell border
        public const int buffer = 1;

        // dimensions discluding the buffer
        public readonly int width;
        public readonly int height;

        public readonly Cell[,] cell;
        public readonly Vector2 start;
        public readonly Vector2 goal;

        public readonly float obstacleDensity;

        // 'positions' excludes the border of walls defined by 'buffer'
        private List<Vector2> validPos = new List<Vector2>();

        public Grid2(SimulationParameters parameters)
        {
            width = parameters.width;
            height = parameters.height;
            start = parameters.startPos;
            goal = parameters.goalPos;
            obstacleDensity = parameters.obstacleDensity;


            // create grid of 'floor' cells w/ a 'wall' cell border
            cell = new Cell[width + 2, height + 2];
            for (int y = 0; y < height + 1; ++y)
            {
                for (int x = 0; x < width + 1; ++x)
                {
                    if (x == 0 || x == width + 1 || y == 0 || y == height + 1)
                    {
                        // 'wall' border
                        cell[x, y] = new Cell(Cell.Type.Wall);
                    }
                    else
                    {
                        // valid positions
                        cell[x, y] = new Cell();
                        validPos.Add(new Vector2(x, y));
                    }
                }
            }

            //PlaceRandomObstacles(ref cell);
        }

        // randombly place obstacles on grid, not including start & goal
        private void PlaceRandomObstacles(ref Cell[,] cell)
        {
            // make list of valid positions to place obstacles
            List<Vector2> tmpPos = new List<Vector2>();
            foreach (Vector2 pos in validPos)
            {
                tmpPos.Add(new Vector2(pos.x, pos.y));
            }
            tmpPos.Remove(this.start);
            tmpPos.Remove(this.goal);

            // place obstacles on grid
            int numObstacles = (int)(width * height * obstacleDensity);
            numObstacles = Mathf.Min(numObstacles, width * height - 2);
            for (int i = 0; i < numObstacles; ++i)
            {
                int randomIndex = Random.Range(0, tmpPos.Count);
                Vector2 randPos = tmpPos[randomIndex];

                // prevent position from being used twice
                tmpPos.RemoveAt(randomIndex);

                cell[(int)randPos.x, (int)randPos.y] = new Cell(Cell.Type.Wall);
            }
        }

    }
}
