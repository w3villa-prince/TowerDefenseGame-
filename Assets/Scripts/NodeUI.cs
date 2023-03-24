using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellCost;

    public Button upgradeButton;

    public void SetTarget(Node _target)
    {
        target = _target;
        transform.position = target.GetBuildPosition();
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBuleprint.upgradeCost;
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeCost.text = "Done";
            upgradeButton.interactable = false;
        }

        sellCost.text = "$" + target.turretBuleprint.GetSellAmount();

        ui.SetActive(true);
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BulidManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BulidManager.instance.DeselectNode();
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
