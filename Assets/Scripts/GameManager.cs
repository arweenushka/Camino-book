using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    private void QuitGame()
    {
        //Stop play mode (comment line before build game)
        //UnityEditor.EditorApplication.isPlaying = false;
        //stop game not in editor
        Application.Quit();
    }
    
    public void LoadLevelsMap()
    {
        SceneManager.LoadScene("MapOfCamino");
    }
        
    public void LoadNextScene()
    {
        int currentSceneIndex = gameSession.GetSceneIndex();
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    
    
}