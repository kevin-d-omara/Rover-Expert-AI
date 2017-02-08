using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Tile is a visual entity. It belongs to a GameObject with a 32x32 sprite.
 * It's sprite is randomly chosen and given a random orientation (angle & flip)
 */

namespace RoverExpertAI
{
    [RequireComponent(typeof(SpriteRenderer))]
	public class Tile : MonoBehaviour
	{
        [SerializeField] private Tiles tileSprites;

        private void Start()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            // Randomly select a floor tile.
            spriteRenderer.sprite = tileSprites.RandomSprite;

            // Randomly orient sprite with equal chance for all orientations.
            // random rotation
            float randAngle = 90f * Random.Range(0, 4);
            transform.Rotate(new Vector3(0f, 0f, randAngle));

            // random flip
            if (Random.value > 0.33f)
            {
                if (Random.Range(0, 2) == 0)
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
