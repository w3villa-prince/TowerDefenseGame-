using UnityEngine;

[System.Serializable]
public class TurretBuleprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return cost / 2;
    }

    // Start is called before the first frame update
}
