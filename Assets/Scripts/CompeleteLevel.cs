using UnityEngine;

public class CompeleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;
    public string menuSceneName = "MainMenu";

    public string nextLevel = "Level-2";

    public int levelToUnloked = 2;

    public void Continue()
    {
        Debug.Log("Level Won !");
        PlayerPrefs.SetInt("levelReached", 2);

        sceneFader.FadeTo(nextLevel);
    }

    public void MainMenu()
    {
        sceneFader.FadeTo(menuSceneName);
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
