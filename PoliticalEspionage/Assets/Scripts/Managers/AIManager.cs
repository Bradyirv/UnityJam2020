using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    public static AIManager instance = null;

    public List<AIBehaviour> waitingAI;
    public AIBehaviour currentAI;
    public Transform AISpawnLocation;
    public Transform confessionSeatLocation;
    [SerializeField] GameObject AIPrefab;
    [SerializeField] Transform AIHeirarchyLocation;

    [Header("Testing")]
    [SerializeField] bool spawnAtStart;
    [SerializeField] bool spawnAnAITest;
    [SerializeField] bool callNextAIForPrayer;
    [SerializeField] bool currentPrayerCompleted;
    
    [Header("Name Generation")]
    [SerializeField] int namesPerClan;
    [SerializeField] bool regenerateNames;
    [SerializeField] List<AI> AIInformation = new List<AI>();
    private string[] clans = {"Frigg", "Thor", "Loki", "Balder", "Hod", "Heimdall", "Tyr"};

    public Dictionary<int, GameObject> preGeneratedAI = new Dictionary<int, GameObject>();
    int numAI;

    [System.Serializable]
    public class AI
    {
        public int id;
        public string first = "";
        public string last = "";
        public string clan = "";
        public int timesVisited = 0;

        public AI(string f, string l, string c, int i)
        {
            first = f;
            last = l;
            clan = c;
            id = i;
        }
    }

    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }

    private void Start()
    {
        numAI = namesPerClan * 7;
        if (regenerateNames)
        {
            APIHandler.instance.GenerateNames((names) =>
            {
                int iteration = 0;
                for (int i=0; i<7; i++)
                {
                    for (int j = 0; j < namesPerClan; j++)
                    {
                        AIInformation.Add(new AI(names.results[iteration].name.first, names.results[iteration].name.last, clans[i], iteration));
                        iteration++;
                    }
                }

                SpawnAI();
            }, numAI); // NUmber of names to request
        }
        else
        {
            SpawnAI();

            if(spawnAtStart)
            {
                SetActiveAI();
            }
        }

        ConfessionManager.onConfessionFinish += CompleteCurrentAIPrayer;
    }

    private void OnDestroy()
    {
        ConfessionManager.onConfessionFinish -= CompleteCurrentAIPrayer;
    }

    private void Update()
    {
        if(spawnAnAITest)
        {
            SetActiveAI();
            spawnAnAITest = false;
        }

        if (callNextAIForPrayer)
        {
            CalledForNextAI();
            callNextAIForPrayer = false;
        }

        if (currentPrayerCompleted)
        {
            CompleteCurrentAIPrayer();
            currentPrayerCompleted = false;
        }

    }

    public void SpawnAI()
    {
        for (int i=0; i< numAI; i++)
        {
            AIBehaviour newAI = Instantiate(AIPrefab, AISpawnLocation.position, AISpawnLocation.rotation).GetComponent<AIBehaviour>();
            newAI.agent.Warp(AIManager.instance.AISpawnLocation.position);
            newAI.transform.SetParent(AIHeirarchyLocation);
            newAI.myInformation = AIInformation[i];
            newAI.gameObject.SetActive(false);
            newAI.Init();
            preGeneratedAI.Add(newAI.myInformation.id, newAI.gameObject);
        }
    }

    public void SetActiveAI()
    {
        int r = Random.Range(0, numAI);
        AIBehaviour aiToActivate = preGeneratedAI[r].GetComponent<AIBehaviour>();
        aiToActivate.myInformation.timesVisited++;
        preGeneratedAI[r].SetActive(true);
        waitingAI.Add(aiToActivate);
    }

    public void Dispose(AIBehaviour targetOfTheAssassination)
    {
        targetOfTheAssassination.gameObject.SetActive(false);
        targetOfTheAssassination.transform.forward = AISpawnLocation.forward;
    }

    public void CalledForNextAI()
    {
        if(waitingAI.Count > 0)
        {
            currentAI = waitingAI[0];
            currentAI.callForPrayer();
            waitingAI.Remove(currentAI);
        }
    }

    public void CompleteCurrentAIPrayer()
    {
        currentAI.madePrayer = true;
        if (currentAI != null)  {
            currentAI.CompletedPrayer();
        }
    }
}
