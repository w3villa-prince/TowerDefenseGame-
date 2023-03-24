using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // public TextMeshProUGUI roundsText;
    public SceneFader sceneFader;

    public string menuSceneName = "MainMenu";

    // Start is called before the first frame update
    private void Start()
    {
    }

    /*  private void OnEnable()
      {
          roundsText.text = PlayerStats.Rounds.ToString();
      }
  */

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void main()
    {
        sceneFader.FadeTo(menuSceneName);
        Debug.Log(" Game of Sence MAin Menu ");
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
