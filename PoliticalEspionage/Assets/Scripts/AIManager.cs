using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static AIManager instance = null;
    
    public List<AIBehaviour> activeAI;
    public Transform AISpawnLocation;
    public Transform confessionSeatLocation;
    [SerializeField] GameObject AIPrefab;
    public bool spawnAnAITest;

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

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
        activeAI.Add(newAI);
    }

    public void Dispose(AIBehaviour targetOfTheAssassination)
    {
        activeAI.Remove(targetOfTheAssassination);
    }

    public void CallForConfession()
    {
        activeAI[0].CallForConfession();
    }
}
