using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static bool GameIsDone;

    public GameObject gameOverUI;
    public GameObject completeLevelUI;
    // Start is called before the first frame update
    void Start()
    {
        GameIsDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsDone)
            return;

        if (coinManagement.lives <= 0)
        {
            GameIsDone = true;
            gameOverUI.SetActive(true);
        }

        
    }

    public void levelComplete()
    {
        GameIsDone = true;
        completeLevelUI.SetActive(true);
    }
}
