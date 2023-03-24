using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    private Renderer rend;
    private Color startColor;

    private Vector3 positionOffset = new Vector3(0, .5f, 0);
    private BulidManager bulidManager;

    [HideInInspector]
    public GameObject turret;

    [HideInInspector]
    public TurretBuleprint turretBuleprint;

    [HideInInspector]
    public bool isUpgraded;

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        bulidManager = BulidManager.instance;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!bulidManager.CanBuild)
            return;
        if (bulidManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            Debug.Log("Can not Buiild There ! ");
            bulidManager.SelectNode(this);
            return;
        }

        if (!bulidManager.CanBuild)
            return;

        BuildTuuret(bulidManager.GetTurretToBuild());

        // bulidManager.BuildTurretOn(this);
        /* GameObject turrentToBuild = bulidManager.GetTurretToBuild();
         turret = (GameObject)Instantiate(turrentToBuild, transform.position + positionOffset, transform.rotation);*/
    }

    private void BuildTuuret(TurretBuleprint buleprint)
    {
        if (PlayerStats.Money < buleprint.cost)
        {
            Debug.Log("Not Enough Money to Build that ! ");
            return;
        }

        PlayerStats.Money -= buleprint.cost;
        GameObject _turret = (GameObject)Instantiate(buleprint.prefab, transform.position, Quaternion.identity); // GameObject turret = (GameObject)Instantiate(turretToBulid.prefab, node.transform.position + node.GetBuildPosition(), Quaternion.identity);

        turret = _turret;
        turretBuleprint = buleprint;

        GameObject effect = (GameObject)Instantiate(bulidManager.buildEffect, GetBuildPosition(), Quaternion.identity);

        Destroy(effect, 5f);
        Debug.Log("Turret Build ! Money Left :" + PlayerStats.Money);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBuleprint.upgradeCost)
        {
            Debug.Log("Not Enough Money to Upgrade  that ! ");
            return;
        }

        PlayerStats.Money -= turretBuleprint.upgradeCost;

        // Get Rid of the Old Turret
        Destroy(turret);
        // build  a New One
        GameObject _turret = (GameObject)Instantiate(turretBuleprint.upgradePrefab, transform.position, Quaternion.identity); // GameObject turret = (GameObject)Instantiate(turretToBulid.prefab, node.transform.position + node.GetBuildPosition(), Quaternion.identity);```

        turret = _turret;

        GameObject effect = (GameObject)Instantiate(bulidManager.buildEffect, GetBuildPosition(), Quaternion.identity);

        Destroy(effect, 5f);

        isUpgraded = true;
        Debug.Log("Turret Upgrade ! Money Left :" + PlayerStats.Money);
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBuleprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(bulidManager.sellEffect, GetBuildPosition(), Quaternion.identity);

        Destroy(effect, 3f);

        Destroy(turret);
        turretBuleprint = null;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
