using UnityEngine;

public class Shop : MonoBehaviour
{
    private BulidManager bulidManager;

    public TurretBuleprint turret;

    public TurretBuleprint missileLauncher;

    public TurretBuleprint laserBeamer;

    private void Start()
    {
        bulidManager = BulidManager.instance;
    }

    public void SelectStandardTurret()
    {
        bulidManager.SelectTurretToBuild(turret);
    }

    public void SelectMissileLauncher()
    {
        bulidManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        bulidManager.SelectTurretToBuild(laserBeamer);
    }

    // Start is called before the first frame update
    /* public void PurchaseStandardTurret()
     {
         Debug.Log("OnTurrentFirstSelect");

         bulidManager.SetTurretToBulid(bulidManager.standardTurrentPrefab);
     }

     public void PurchaseMissileLuncher()
     {
         Debug.Log("OnTurrentSceond Select");
         bulidManager.SetTurretToBulid(bulidManager.missileLuncherPrefabs);
     }*/
}
