using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoverExpertAI
{
	public class Cell : MonoBehaviour
	{
        public bool BlocksMove
        {
            get { return obstacle != null ? obstacle.BlocksMove : false; }
        }
        public bool BlocksSonar
        {
            get { return obstacle != null ? obstacle.BlocksSonar : false; }
        }

        [SerializeField] private Obstacle obstacle;
    }
}
