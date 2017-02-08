using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoverExpertAI
{
    [CreateAssetMenu(fileName = "Data", menuName = "Tiles/Dirt", order = 1)]
    public class DirtTiles : ScriptableObject
    {
        [SerializeField] private Sprite[] sprites;

        public Sprite[] Sprites()
        {
            return sprites;
        }
    }
}
