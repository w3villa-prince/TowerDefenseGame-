using UnityEngine;

public class BulidManager : MonoBehaviour
{
    public static BulidManager instance;
    private TurretBuleprint turretToBulid;
    private Node selectedNode;

    public GameObject standardTurrentPrefab;

    public GameObject missileLuncherPrefabs;
    public GameObject buildEffect;
    public NodeUI nodeUI;

    public GameObject sellEffect;

    /*  public GameObject GetTurretToBuild()
      {
          return turretToBulid;
      }*/

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More Than One BuildManager in Scene !");
            return;
        }

        instance = this;
    }

    public bool CanBuild
    { get { return turretToBulid != null; } }

    public bool HasMoney
    { get { return PlayerStats.Money >= turretToBulid.cost; } }

    // Start is called before the first frame update
    /*private void Start()
    {
        turretToBulid = standardTurrentPrefab;
    }*/

    /*public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBulid.cost)
        {
            Debug.Log("Not Enough Money to Build that ! ");
            return;
        }

        PlayerStats.Money -= turretToBulid.cost;
        GameObject turret = (GameObject)Instantiate(turretToBulid.prefab, node.transform.position, Quaternion.identity); // GameObject turret = (GameObject)Instantiate(turretToBulid.prefab, node.transform.position + node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);

        Destroy(effect, 5f);
        Debug.Log("Turret Build ! Money Left :" + PlayerStats.Money);
    }*/

    public void SelectNode(Node node)
    {
        if (selectedNode != null)
        {
            Debug.Log(" Hide Calll.......................................................");
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBulid = null;

        nodeUI.SetTarget(node);
    }

    public void SelectTurretToBuild(TurretBuleprint turret)
    {
        turretToBulid = turret;
        DeselectNode();
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBuleprint GetTurretToBuild()
    {
        return turretToBulid;
    }

    /*  public void SetTurretToBulid(GameObject turret)
      {
          turretToBulid = turret;
      }*/

    // Update is called once per frame
    private void Update()
    {
    }
}
