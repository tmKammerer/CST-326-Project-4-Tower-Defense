using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShop : MonoBehaviour
{

    public turretBlueprint turret;
    BuildManager builder;
    // Start is called before the first frame update
    void Start()
    {
        builder = BuildManager.instance;
    }


    public void purchaseTurret()
    {
        builder.SelectTurretToBuild(turret);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
