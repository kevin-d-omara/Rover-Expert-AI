using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoverExpertAI
{
    [CreateAssetMenu(fileName = "Data", menuName = "Tiles/Rock", order = 1)]
    public class RockTiles : ScriptableObject
    {
        [SerializeField] private Sprite[] sprites;

        public Sprite[] Sprite()
        {
            return sprites;
        }
    }
}
