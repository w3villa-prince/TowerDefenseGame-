using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameoverUI;

    public GameObject levelCompelteUI;

    /* public string nextLevel = "Level-2";

     public int levelToUnloked = 2;*/

    public SceneFader sceneFader;

    // Start is called before the first frame update
    private void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (GameIsOver) return;

        if (Input.GetKeyDown("s"))
        {
            EndGame();
        }
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        GameIsOver = true;

        gameoverUI.SetActive(true);
        Debug.Log("Game Over !");
    }

    public void WinLevel()
    {
        GameIsOver = true;
        levelCompelteUI.SetActive(true);
    }
}
