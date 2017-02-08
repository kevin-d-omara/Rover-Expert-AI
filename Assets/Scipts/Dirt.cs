using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RoverExpertAI
{
    [RequireComponent(typeof(SpriteRenderer))]
	public class Dirt : MonoBehaviour
	{
        [SerializeField] private DirtTiles dirtTiles;

        private void Start()
        {
            // Randomly select a 'dirt' sprite from 'DirtTiles' data.
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            Sprite[] sprites = dirtTiles.Sprites();
            spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];

            // Randomly orient sprite with equal chance for all orientations.
            
            // random rotation
            if (Random.value > 0.75)
            {
                // rotate 90, 180, or 270 degrees
                float randAngle = 90f * Random.Range(1, 4);
                transform.Rotate(new Vector3(0f, 0f, randAngle));
            }

            // random flip
            if (Random.value > 0.33f)
            {
                if (Random.Range(0,2) == 0)
                {
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.flipY = true;
                }
            }
        }
    }
}
