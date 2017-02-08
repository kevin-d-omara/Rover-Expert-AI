using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoverExpertAI
{
    [CreateAssetMenu(fileName = "Data", menuName = "Tiles/Pit", order = 1)]
    public class PitTiles : ScriptableObject
    {
        [SerializeField] private Sprite[] sprites;

        public Sprite[] Sprite()
        {
            return sprites;
        }
    }
}
