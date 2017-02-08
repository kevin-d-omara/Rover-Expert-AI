using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoverExpertAI
{
	public class Cell : MonoBehaviour
	{
        public bool BlocksMove
        {
            get { return Obstacle != null ? Obstacle.BlocksMove : false; }
        }
        public bool BlocksSonar
        {
            get { return Obstacle != null ? Obstacle.BlocksSonar : false; }
        }

        public Obstacle Obstacle { get; set; }
    }
}
