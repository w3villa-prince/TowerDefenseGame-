using UnityEngine;

public class AppFunctionTest : MonoBehaviour
{
    private void OnApplicationFocus(bool focus)
    {
        Debug.Log("On  Application Focus " + focus);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("On Application Quit");
    }

    private void OnApplicationPause(bool pause)
    {
        Debug.Log("On Application Pause" + pause);
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
