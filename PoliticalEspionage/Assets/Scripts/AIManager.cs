using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public bool confessionInProgress;
    public List<AIBehaviour> activeAI;
    public Transform AISpawnLocation;
    public GameObject AIPrefab;
    public bool spawnAnAITest;

    private void Update()
    {
        if(spawnAnAITest)
        {
            SpawnAI();
            spawnAnAITest = false;
        }
    }

    public void SpawnAI()
    {
        AIBehaviour newAI = Instantiate(AIPrefab, AISpawnLocation.position, AISpawnLocation.rotation).GetComponent<AIBehaviour>();

    }
}
