using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoverExpertAI
{
	public class Rover : MonoBehaviour
	{
        // Internal State
        public int NumMoves { get; private set; }
        public Vector2 LastMove { get; private set; }

        private Stack<Vector2> Moves;

        // Database


        // Movement Set
        // [todo]

        // Sonar Set
        // [todo]

        // Intelligent Control
        // [todo]

        private void Awake()
        {
            NumMoves = 0;
        }
    }
}
