using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

[System.Serializable]
public class OnDirectionsLoaded : UnityEvent<GoogleDirections>
{
}

public class GoogleDirectionsApi : MonoBehaviour
{

    public OnDirectionsLoaded OnDirectionsLoaded;

    // input for API key
    public TextAsset apiKey;

    public string origin;
    public string destination;

    // endpoint for directions API
    private string api = "https://maps.googleapis.com/maps/api/directions/json";

    void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(
            api +
            "?key=" + apiKey.text +
            "&origin=" + origin +
            "&destination=" + destination
            );

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {

            // parse the data
            GoogleDirections directions = JsonUtility.FromJson<GoogleDirections>(www.downloadHandler.text);

            // call listeners
            OnDirectionsLoaded.Invoke(directions);

        }
    }

}
