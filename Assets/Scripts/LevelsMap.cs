using UnityEngine;
using UnityEngine.UI;

public class LevelsMap : MonoBehaviour
{
    
    public Button continueButton;
    
    public GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(gameManager.LoadNextScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}