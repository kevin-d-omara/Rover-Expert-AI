using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RoverExpertAI
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Tiles", order = 4)]
	public class Tiles : ScriptableObject
	{
        [SerializeField] private Sprite[] sprites;

        public Sprite RandomSprite
        {
            get { return sprites[Random.Range(0, sprites.Length)]; }
        }
	}
}
