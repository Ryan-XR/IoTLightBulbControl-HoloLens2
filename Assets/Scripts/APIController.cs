using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIController : MonoBehaviour
{
    // Tutorial for IFTTT setup: https://xrlab.dev/control-iot-light-bulb-with-hololens/
    private const string APIKey = "YOUR_API_KEY";

    public void ToggleLightButtonClick() {
        StartCoroutine(CallWebHookAPI());
    }

    IEnumerator CallWebHookAPI() {

        // API URL
        // Tutorial for IFTTT setup: https://xrlab.dev/control-iot-light-bulb-with-hololens/
        string iftttURL = "YOUR_IFTTT_API_URL" + APIKey;

        UnityWebRequest iftttWebRequest = UnityWebRequest.Get(iftttURL);
        
        yield return iftttWebRequest.SendWebRequest();

        if(iftttWebRequest.isNetworkError || iftttWebRequest.isHttpError)
        {
            print(iftttWebRequest.error);
            yield break;
        } else
        {
            print("API CALLED");
        }
    }
}
