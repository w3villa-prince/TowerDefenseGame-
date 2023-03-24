using TMPro;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
