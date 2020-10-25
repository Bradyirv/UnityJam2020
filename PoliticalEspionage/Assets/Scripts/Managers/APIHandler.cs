using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class APIHandler : MonoBehaviour
{
    public static APIHandler instance;
    private void Awake()
    {
        if (instance) Destroy(this);
        else instance = this;
    }
    
    public UnityWebRequestAsyncOperation data;
    private string endpointA = "http://randomuser.me/api/?results=";
    private string endpointB = "&nat=ca&gender=male&inc=name&noinfo";
    private string finalEndpoint;

    public void GenerateNames(System.Action<Root> action, int names)
    {
        finalEndpoint = endpointA + names.ToString() + endpointB;
        //Debug.Log("Requested Names: " + names + ", To Endpoint: " + finalEndpoint);
        StartCoroutine(GETRequest(action, false));
    }

    public IEnumerator GETRequest(System.Action<Root> callback, bool debugResponse = false)
    {
        // Assign local storage for web request, and send the request
        UnityWebRequest req = UnityWebRequest.Get(finalEndpoint);
        data = req.SendWebRequest();

        // Wait for the web request to complete
        while (!data.isDone)
        {
            yield return null;
        }

        using (req)
        {   
            // Serialize data in event of no NET or WEB errors
            if (!req.isNetworkError || !req.isHttpError)
            {
                string response = req.downloadHandler.text;
                Root Names = JsonUtility.FromJson<Root>(response);
                if (debugResponse) Debug.Log(response);
                callback(Names);
            }
            else Debug.Log(req.error);
        }
    }

    [System.Serializable]
    public class Name
    {
        public string title;
        public string first;
        public string last;
    }

    [System.Serializable]
    public class Result
    {
        public Name name;
    }

    [System.Serializable]
    public class Root
    {
        public Result[] results;
    }
}