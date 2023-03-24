using UnityEngine;

using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public SceneFader fader;

    public Button[] levelButton;

    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

    private void Start()
    {
        int levelReched = PlayerPrefs.GetInt("levelReached", 1);
        for (int i = 0; i < levelButton.Length; i++)
        {
            if (i + 1 > levelReched)
            {
                levelButton[i].interactable = false;
            }
        }
    }
}
