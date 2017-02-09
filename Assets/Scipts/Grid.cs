using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RoverExpertAI
{
	public class Grid
	{
        // width of the 'wall' cell border
        public const int buffer = 1;

        // dimensions including buffer
        public readonly int width;
        public readonly int height;

        public readonly Cell[,] cell;
        public readonly Vector2 start;
        public readonly Vector2 goal;

        // dimensions discluding the buffer
        private readonly int innerWidth;
        private readonly int innerHeight;

        // 'positions' excludes the border of walls defined by 'buffer'
        private List<Vector2> validPos = new List<Vector2>();

        public Grid(Vector2 dimensions, Vector2 start, Vector2 goal,
            float obstacleDensity)
        {
            innerWidth = (int)dimensions.x;
            innerHeight = (int)dimensions.y;
            width = innerWidth + 2 * buffer;
            height = innerHeight + 2 * buffer;

            // offset start & end points by buffer
            this.start = new Vector2(start.x + buffer, start.y + buffer);
            this.goal = new Vector2(goal.x + buffer, goal.y + buffer);

            // create grid of 'floor' cells w/ a 'wall' cell border
            cell = new Cell[width, height];
            for (int y = 0; y < height; ++y)
            {
                for (int x = 0; x < width; ++x)
                {
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        // 'wall' border
                        cell[x, y] = new Cell(Cell.Type.Wall);
                    }
                    else
                    {
                        // valid positions
                        cell[x, y] = new Cell(Cell.Type.Floor);
                        validPos.Add(new Vector2(x, y));
                    }
                }
            }

            PlaceRandomObstacles(ref cell, obstacleDensity);
        }

        // randombly place obstacles on grid, not including start & goal
        private void PlaceRandomObstacles(ref Cell[,] cell, float obstacleDensity)
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
            int numObstacles = (int)(innerWidth * innerHeight * obstacleDensity);
            numObstacles = Mathf.Min(numObstacles, innerWidth * innerHeight - 2);
            Random random = new Random();
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
