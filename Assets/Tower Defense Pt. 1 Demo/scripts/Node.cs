using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private Color startColor;

    private Renderer rend;

    private GameObject turret;
    public Vector3 positionOffset;

    public coinManagement purse;

    public int coinAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        coinAmount = purse.coins;
    }
    void OnMouseEnter()
    {
        rend.material.color = hoverColor;

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
        }
        else
        {


            if (coinAmount >= 5)
            {
                GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
                turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
                purse.SubtractCoins(5);
            }
            else
            {
                Debug.Log("You don't have enough coins");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
