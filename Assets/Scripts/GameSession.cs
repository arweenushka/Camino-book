using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//class with singlton. for data that  should not be reset on each scene
public class GameSession : MonoBehaviour
{
    
    private int sceneId = 0;
    
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int GetSceneIndex()
    {
        return sceneId;
    }

    public void SetSceneIndex()
    {
        sceneId = SceneManager.GetActiveScene().buildIndex;
    }
}
