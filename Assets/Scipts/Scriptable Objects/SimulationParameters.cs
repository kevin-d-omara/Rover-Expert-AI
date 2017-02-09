using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoverExpertAI
{
    [CreateAssetMenu(fileName = "Parameters", menuName = 
        "Data/Simulation Parameters", order = 4)]
	public class SimulationParameters : ScriptableObject
	{
        [Range(1, 100)] public int width;
        [Range(1, 100)] public int height;

        public Vector2 startPos;
        public Vector2 goalPos;

        [Range(0f, 1f)] public float obstacleDensity;
        public List<GameObject> obstacleTypes;
        public GameObject floorTiles;
    }
}
