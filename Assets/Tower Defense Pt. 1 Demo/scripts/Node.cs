using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    private Renderer rend;

    [Header("Optional")]
    public GameObject turret;
    public Vector3 positionOffset;

    public turretBlueprint turretBlueprint;



    public int coinAmount;

    BuildManager buildManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
        
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }

        

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Tower already placed");
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }

        buildManager.BuildTurretOn(this);
        
    }
    void BuildTurret(turretBlueprint blueprint)
    {
        if (coinManagement.coins < blueprint.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        coinManagement.coins -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBlueprint = blueprint;

        

        Debug.Log("Turret build!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
