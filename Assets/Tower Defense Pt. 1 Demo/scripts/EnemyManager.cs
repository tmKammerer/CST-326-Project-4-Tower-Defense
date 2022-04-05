using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyManager : MonoBehaviour
{

    
    public coinManagement scoreManager;
    public EnemyDemo prefab;

    public Transform spawnPoint;
    public int amountRoaming;

    public int round;

    public int amountDead;

    public float spawnNext = 5f;

    private float countdown = 3f;

    private int wave = 1;

    public TextMeshProUGUI timer;

    // Start is called before the first frame update

    private void Awake()
    {
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(spawnWave());
            countdown = spawnNext;
        }
        countdown -= Time.deltaTime;

        timer.text = Mathf.Floor(countdown).ToString();
    }

    IEnumerator spawnWave()
    {
        Debug.Log("Enemies rolling in");
        for(int i = 0; i < wave; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        wave++;
    }

   

    void OnEnemyDestroyed(EnemyDemo enemy)
    {
        
        enemy.OnEnemyDestroyed -= OnEnemyDestroyed;
        
        scoreManager.AddCoins(enemy.coin);
        
    }

    void spawnEnemy()
    {
        Instantiate(prefab, spawnPoint.position,spawnPoint.rotation);

    }
}
