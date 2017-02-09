using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RoverExpertAI
{
	public class BoardManager : MonoBehaviour
	{
        private SimulationParameters parameters;
        private Transform boardTileHolder;

        // Create rectangular grid of floor tiles with an invisible wall border.
        private void CreateEmptyBoard()
        {
            boardTileHolder = new GameObject("Board").transform;

            for (int x = 0; x <= parameters.width + 1; ++x)
            {
                for (int y = 0; y <= parameters.height + 1; ++y)
                {
                    GameObject toInstantiate = parameters.floorTiles;
                    if (x == 0 || x == parameters.width + 1 || y == 0 || y == parameters.height + 1)
                    {
                        int obstacleIndex = Random.Range(0, parameters.obstacleTypes.Count);
                        toInstantiate = parameters.obstacleTypes[obstacleIndex];
                    }

                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(boardTileHolder);
                }
            }
        }

        private void InitializeValidMoves()
        {

        }

        private void PlaceObstacles()
        {
            for (int x = 1; x <= parameters.width; ++x)
            {
                for (int y = 1; y <= parameters.height; ++y)
                {
                    if (Random.value <= parameters.obstacleDensity)
                    {
                        int obstacleIndex = Random.Range(0, parameters.obstacleTypes.Count);
                        GameObject toInstantiate = parameters.obstacleTypes[obstacleIndex];
                        GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                        instance.transform.SetParent(boardTileHolder);
                    }
                }
            }
        }


        public void SetupBoard(SimulationParameters parameters)
        {
            this.parameters = parameters;

            // Create outer walls and floors.
            CreateEmptyBoard();

            // Create a list including valid board positions, excludes outer
            // wall and start and end positions.
            InitializeValidMoves();

            // Add Rocks, Pits, etc. to the board.
            PlaceObstacles();
        }
    }
}
