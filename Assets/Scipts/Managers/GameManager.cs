using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RoverExpertAI
{
	public class GameManager : MonoBehaviour
	{
        private static GameManager _instance = null;
        public static GameManager Instance
        {
            get { return _instance; }
            private set { _instance = value; }
        }

        // Component references.
        [SerializeField] private BoardManager boardManager;

        // Prefab references.
        [SerializeField] private GameObject rover;

        [SerializeField] private SimulationParameters defaultSimulationParams;  
        private SimulationParameters customSimulationParams;

        private void Awake()
        {
            // Enforce Singleton pattern.
            if (Instance == null)
            {
                Instance = this;
                // Perform one-time setup of GameManager.
                SetupGameManager();
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        private void SetupGameManager()
        {
            customSimulationParams = Instantiate(defaultSimulationParams);

            boardManager.SetupBoard(customSimulationParams);
        }
    }
}
