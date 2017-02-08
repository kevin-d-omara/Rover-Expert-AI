using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoverExpertAI
{
	public class Obstacle : MonoBehaviour
	{
        [SerializeField] private bool blocksMove = false;
        [SerializeField] private bool blocksSonar = false;

        public bool BlocksMove { get { return blocksMove; } }
        public bool BlocksSonar { get { return blocksSonar; } }
    }
}
