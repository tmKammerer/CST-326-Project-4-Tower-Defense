using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coinManagement : MonoBehaviour
{

    public int coins;

    public TextMeshProUGUI coinCount;
    // Start is called before the first frame update
    void Start()
    {
        coins = 5;
        coinCount.text =coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(int coins)
    {
        this.coins += coins;
        coinCount.text = this.coins.ToString();
    }

    public void SubtractCoins(int coins)
    {
        this.coins -= coins;
        coinCount.text = this.coins.ToString();
    }
}
