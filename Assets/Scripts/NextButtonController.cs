using UnityEngine;
using UnityEngine.UI;

public class NextButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //nextBtn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void HideNextButton()
    {
        gameObject.SetActive(false);
    }
        
    public void ShowNextButton()
    {
        gameObject.SetActive(true);
    }
}