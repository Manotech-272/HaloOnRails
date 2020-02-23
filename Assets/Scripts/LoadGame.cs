using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private void Awake()
    {
       
       
            DontDestroyOnLoad(transform.gameObject);
       
    }
    void Start()
    {
        Invoke("LoadLevel", 4.0f );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel()
    {
        SceneManager.LoadScene("Game1");
    }
}
