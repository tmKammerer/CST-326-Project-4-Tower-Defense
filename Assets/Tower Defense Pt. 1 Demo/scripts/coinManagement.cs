using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coinManagement : MonoBehaviour
{

    public static int coins;

    public int startMoney = 5;

    public static int lives;
    public int startLives = 3;

    public TextMeshProUGUI coinCount;
    public TextMeshProUGUI livesCount;
    // Start is called before the first frame update
    void Start()
    {
        coins = startMoney;
        coinCount.text =coins.ToString();
        lives = startLives;
        livesCount.text = lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinCount.text = coins.ToString();
        livesCount.text = lives.ToString();
    }

    
}
