﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoverExpertAI
{
	public class Loader : MonoBehaviour
	{
        [SerializeField] private GameObject gameManager;

        private void Awake()
        {
            if (GameManager.Instance == null)
            {
                Instantiate(gameManager);
            }
        }
    }
}
