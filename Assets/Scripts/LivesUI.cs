using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " Lives";
    }
}
