using UnityEngine;
using UnityEngine.UI;

public class YearAndPlace : MonoBehaviour
{
    public Button nextButton;

    public TextController textController;
        
    [Header("Year and Place window and text in the window")]
    [SerializeField] private Text yearAndPlace;
        
    //button to move to the next node
    private NextButtonController nextButtonScript;
        
    // Start is called before the first frame update
    void Start()
    {
        nextButton.onClick.AddListener(CloseWindow);
        nextButton.onClick.AddListener(ShowBook);
            
        //initialize script of next button
        nextButtonScript = GameObject.Find("NextBtn").GetComponent<NextButtonController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //close Year and Place window(used on Click method of button next in same window)
    private void CloseWindow()
    {
        gameObject.SetActive(false);
    }
        
        
    //show book with all elements that available for current node. on click event
    public void ShowBook()
    {
        textController.GETStoryDisplayText().gameObject.SetActive(true);
        textController.ShowOptions();
    }

    //if current node is one of the key points where story changes, show year and place window
    public void ShowYearAndPlace( string nodeName, string textForYearAndPlace)
    {
        if (!textController.GETNode().name.Equals(nodeName)) return;
        gameObject.SetActive(true);
        yearAndPlace.text = textForYearAndPlace;

        textController.GETFirstOptionBtn().gameObject.SetActive(false);
        textController.GETSecondOptionBtn().gameObject.SetActive(false);
        nextButtonScript.HideNextButton();
        textController.GETStoryDisplayText().gameObject.SetActive(false);
    }
}