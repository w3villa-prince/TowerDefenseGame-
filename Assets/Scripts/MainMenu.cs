using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "DemoGameScene";
    public SceneFader SceneFader;

    public void Play()
    {
        Debug.Log("Play");

        SceneFader.FadeTo(levelToLoad);
        //SceneManager.LoadScene(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Quit................");
        Application.Quit();
    }

    // Start is called before the first frame update
}
