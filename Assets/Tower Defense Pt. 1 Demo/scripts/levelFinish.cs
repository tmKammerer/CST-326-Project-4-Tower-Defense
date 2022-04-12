using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelFinish : MonoBehaviour
{
    
    public string menuSceneName = "SampleScene";

   

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(menuSceneName,LoadSceneMode.Additive);
    }
}
