using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoverExpertAI
{
	public class BoardManager : MonoBehaviour
	{
        private SimulationParameters parameters;

        private void CreateEmptyBoard()
        {

        }

        private void InitializeValidMoves()
        {

        }

        private void PlaceObstacles()
        {

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
