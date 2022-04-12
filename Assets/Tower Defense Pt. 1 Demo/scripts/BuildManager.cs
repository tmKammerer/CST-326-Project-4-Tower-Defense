using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private turretBlueprint turretToBuild;
    public GameObject standardTurrretPrefab;
   
    // Start is called before the first frame update

    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HasMoney { get { return coinManagement.coins >= turretToBuild.cost; } }
    public bool CanBuild { get{ return turretToBuild != null; } }

    public void BuildTurretOn(Node node)
    {
        if (coinManagement.coins < turretToBuild.cost)
        {
            Debug.Log("not enough money");
            return;
        }
        coinManagement.coins-=turretToBuild.cost;

        GameObject turret=(GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(),Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret Built!");
    }
    public void SelectTurretToBuild(turretBlueprint turret)
    {
        turretToBuild = turret;
    }

}
