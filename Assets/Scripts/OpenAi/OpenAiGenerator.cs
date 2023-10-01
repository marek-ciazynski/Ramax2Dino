using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class OpenAiGenerator : MonoBehaviour
{
    [SerializeField] private Text dinosaurName;
    [SerializeField] private Text dinosaurMotto;

    private static string API_URL = "http://localhost:3000";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateDinosaur());
    }

    IEnumerator GenerateDinosaur()
    {
        // Create an instance of your data class and populate it
        DinosaurRequest jsonData = new DinosaurRequest();
        jsonData.keywords = GetTopFoodByCount(3);
        Debug.Log(string.Join(", ", jsonData.keywords));

        // Convert the data to JSON format
        string json = JsonUtility.ToJson(jsonData);

        // Create a UnityWebRequest with the POST method
        UnityWebRequest request = new UnityWebRequest($"{API_URL}/dinosaur", "POST");

        // Set the request headers
        request.SetRequestHeader("Content-Type", "application/json");

        // Attach the JSON data to the request body
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(jsonBytes);
        request.downloadHandler = new DownloadHandlerBuffer();


        // Send the request
        yield return request.SendWebRequest();

        Debug.Log("RESPONSE CODE: " + request.responseCode);
        Debug.Log("RESPONSE RESULT: " + request.result);

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error While Sending: " + request.error);
            dinosaurName.text = "You're a mystery ;)";
        }
        else
        {
            var responseJson = request.downloadHandler.text;
            DinosaurResponse dinoResponse = JsonUtility.FromJson<DinosaurResponse>(responseJson);
            Debug.Log("Received: " + responseJson);
            Debug.Log("Your dino's name: " + dinoResponse.name);
            Debug.Log("Your dino's motto: " + dinoResponse.motto);
            dinosaurName.text = dinoResponse.name;
            dinosaurMotto.text = dinoResponse.motto;
        }
    }

    private List<string> GetTopFoodByCount(int top) {
        var stats = Statistics.statistics;
        return stats.OrderByDescending(kv => kv.Key)
            .Take(top)
            .Select(kv => kv.Key)
            .ToList();
    }

}
