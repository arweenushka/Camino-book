using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [Header("Text of the story which displays on the screen")] [SerializeField]
    private Text storyDisplayText;

    [Header("Choose node to start your story")] [SerializeField]
    private Node startingNode;

    private Node node;
    private string nameOfNodeToLoad = "null";

    //List of the names of nodes that was called by the player during the whole game
    private List<string> usedNodes;

    [Header("Dialogue options")] [SerializeField]
    public Button firstOptionBtn;

    public Button secondOptionBtn;
    private TMP_Text firstOptionDisplayText;
    private TMP_Text secondOptionDisplayText;

    //button to move to the next node
    private NextButtonController nextButtonScript;

    //button to move to specific node
    private NextButtonController loadSpecificNodeScript;

    //data related to the Chapter 1
    private Chapter1Controller chapter1Script;

    //data related to the Chapter 2
    private Chapter2Controller chapter2Script;

    //data related to the Chapter 3
    private Chapter3Controller chapter3Script;

    //year and place script
    private YearAndPlace yearAndPlace;

    public GameManager gameManager;

    private GameSession gameSession;

    public Text GETStoryDisplayText()
    {
        return storyDisplayText;
    }

    public Node GETNode()
    {
        return node;
    }

    public Button GETFirstOptionBtn()
    {
        return firstOptionBtn;
    }

    public Button GETSecondOptionBtn()
    {
        return secondOptionBtn;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        //initialize beginning of our story
        node = startingNode;
        storyDisplayText.text = node.GetNodeStory();

        //initialize text of possible choices
        firstOptionDisplayText = firstOptionBtn.GetComponentInChildren<TMP_Text>();
        secondOptionDisplayText = secondOptionBtn.GetComponentInChildren<TMP_Text>();

        //initialize script of next button
        nextButtonScript = GameObject.Find("NextBtn").GetComponent<NextButtonController>();

        //initialize script of load specific node button
        loadSpecificNodeScript = GameObject.Find("LoadSpecificNodeBtn").GetComponent<NextButtonController>();

        //initialize list of the called nodes
        usedNodes = new List<string>();

        //hide next button in the first node of the chapter
        nextButtonScript.HideNextButton();

        //hide load specific node button in the first node of the chapter
        loadSpecificNodeScript.HideNextButton();

        //initialize script of Chapter 1
        chapter1Script = GameObject.Find("Chapter1").GetComponent<Chapter1Controller>();

        //initialize script of Chapter 2
        chapter2Script = GameObject.Find("Chapter2").GetComponent<Chapter2Controller>();

        //initialize script of Chapter 3
        chapter3Script = GameObject.Find("Chapter3").GetComponent<Chapter3Controller>();

        //initialize year and place script
        yearAndPlace = GameObject.Find("YearAndPlaceWindow").GetComponent<YearAndPlace>();
        ;

        //if needed show Year and Place window
        yearAndPlace.ShowYearAndPlace(chapter1Script.Chapter1NodeName1, chapter1Script.TextForYearAndPlace1);
        yearAndPlace.ShowYearAndPlace(chapter2Script.Chapter2NodeName1, chapter2Script.TextForYearAndPlace1);
        yearAndPlace.ShowYearAndPlace(chapter3Script.Chapter3NodeName1, chapter3Script.TextForYearAndPlace1);
    }

    // Update is called once per frame
    void Update()
    {
        //update names of the next possible choices of nodes
        DisplayOptionsNames();
    }

    //load first node of the possible list of options  
    public void LoadFirstOption()
    {
        var nextNodes = node.GetNextNodes();
        node = nextNodes[0];
        storyDisplayText.text = node.GetNodeStory();
        ShowOptions();
        AddNodeToListOfUsedNodes();

        //if needed show Year and Place window
        yearAndPlace.ShowYearAndPlace(chapter1Script.Chapter1NodeName2, chapter1Script.TextForYearAndPlace2);
        yearAndPlace.ShowYearAndPlace(chapter3Script.Chapter3NodeName2, chapter3Script.TextForYearAndPlace2);
    }

    //load second node of the possible list of options 
    public void LoadSecondOption()
    {
        var nextNodes = node.GetNextNodes();
        node = nextNodes[1];
        storyDisplayText.text = node.GetNodeStory();
        ShowOptions();
        AddNodeToListOfUsedNodes();

        //if needed show Year and Place window
        yearAndPlace.ShowYearAndPlace(chapter1Script.Chapter1NodeName2, chapter1Script.TextForYearAndPlace2);
        yearAndPlace.ShowYearAndPlace(chapter3Script.Chapter3NodeName2, chapter3Script.TextForYearAndPlace2);
    }

    //next button is available only if there is only one next node. in this case load it
    public void LoadNextPartOfStory()
    {
        var nextNodes = node.GetNextNodes();
        node = nextNodes[0];
        storyDisplayText.text = node.GetNodeStory();
        ShowOptions();
        AddNodeToListOfUsedNodes();

        //if needed show Year and Place window
        yearAndPlace.ShowYearAndPlace(chapter1Script.Chapter1NodeName2, chapter1Script.TextForYearAndPlace2);
        yearAndPlace.ShowYearAndPlace(chapter3Script.Chapter3NodeName2, chapter3Script.TextForYearAndPlace2);

        CheckChaptersToLoad();
    }

    //depends of the previous user decision, check if needed to load some specific node
    private void CheckChaptersToLoad()
    {
        //checks for Chapter 1
        VerifyWhatToLoadNext(chapter1Script.NodeNameRecieved1,
            chapter1Script.NodeNameSent1,
            chapter1Script.CurrentNodeName);
        VerifyWhatToLoadNext(chapter1Script.NodeNameRecieved2,
             chapter1Script.NodeNameSent2,
             chapter1Script.CurrentNodeName);

        //checks for Chapter 2
        VerifyWhatToLoadNext(chapter2Script.NodeNameRecieved1,
            chapter2Script.NodeNameSent1,
            chapter2Script.CurrentNodeName);
        VerifyWhatToLoadNext(chapter2Script.NodeNameRecieved2,
            chapter2Script.NodeNameSent2,
            chapter2Script.CurrentNodeName);

        //checks for Chapter 3
        VerifyWhatToLoadNext(chapter3Script.NodeNameRecieved1,
            chapter3Script.NodeNameSent1,
            chapter3Script.CurrentNodeName);
        VerifyWhatToLoadNext(chapter3Script.NodeNameRecieved2,
            chapter3Script.NodeNameSent2,
            chapter3Script.CurrentNodeName);
        VerifyWhatToLoadNext(chapter3Script.NodeNameRecieved3,
            chapter3Script.NodeNameSent3,
            chapter3Script.CurrentNodeName2);

        //TODO не закрыжвается поп ап вечером того же дня
        VerifyWhatToLoadNext(chapter3Script.NodeNameRecieved4,
            chapter3Script.NodeNameSent4,
            chapter3Script.CurrentNodeName2);
        //TODO не закрыжвается поп ап вечером того же дня
        VerifyWhatToLoadNext(chapter3Script.NodeNameRecieved2,
            chapter3Script.NodeNameSent4,
            chapter3Script.CurrentNodeName2);
    }

    //show only next options available for current node 
    public void ShowOptions()
    {
        var nextNodes = node.GetNextNodes();

            foreach( var x in nextNodes) {
                Debug.Log( x.ToString());
            }

        //if there is no choices and only one possible next node, then display button next and disable options visibility for the player
        if (nextNodes.Length == 1)
        {
            firstOptionBtn.gameObject.SetActive(false);
            secondOptionBtn.gameObject.SetActive(false);
            nextButtonScript.ShowNextButton();
        }
        //if there are choices and few possible nodes to load next, then disable button next and display options for the player
        else if (nextNodes.Length == 2)
        {
            firstOptionBtn.gameObject.SetActive(true);
            secondOptionBtn.gameObject.SetActive(true);
            nextButtonScript.HideNextButton();
        }
        //if there is no next nodes(end of the game) then don´t show next options and next button
        else
        {
            /*firstOptionBtn.gameObject.SetActive(false);
                secondOptionBtn.gameObject.SetActive(false);
                nextButtonScript.HideNextButton();*/

            //save current scene index(to know which chapter to load next)
            gameSession.SetSceneIndex();
            //load map of camino 
            gameManager.LoadLevelsMap();
        }
    }

    //display only names of the available next options for current node
    private void DisplayOptionsNames()
    {
        var nextNodes = node.GetNextNodes();
        if (nextNodes.Length == 1)
        {
            firstOptionDisplayText.text = node.GetNextNodes()[0].name;
        }
        else if (nextNodes.Length == 2)
        {
            firstOptionDisplayText.text = node.GetNextNodes()[0].name;
            secondOptionDisplayText.text = node.GetNextNodes()[1].name;
        }
    }

    //add nodes to the list where then you can see all nodes that player called in the game
    private void AddNodeToListOfUsedNodes()
    {
        usedNodes.Add((node.name));
    }

    //check specific options related to the each chapter and depends of it load specific story text 
    //call in case if you need to display text only if some option was chose by player
    private void VerifyWhatToLoadNext(string nodeNameRecieved, string nodeNameSent, string currentNodeName)
    {
        if (node.name != currentNodeName) return;
        loadSpecificNodeScript.ShowNextButton();
        firstOptionBtn.gameObject.SetActive(false);
        secondOptionBtn.gameObject.SetActive(false);
        if (usedNodes.Contains(nodeNameRecieved))
        {
            /*foreach( var x in usedNodes) {
                Debug.Log( x.ToString());
            }*/
            nameOfNodeToLoad = nodeNameSent;
        }
    }

 public void LoadSpecificNode()
 {
     var nextNodes = node.GetNextNodes();
     foreach (var x in nextNodes)
     {
         Debug.Log(x.ToString());
     }

     AddNodeToListOfUsedNodes();
     foreach (var i in nextNodes)
     {
         string nameOfAvailableNode = i.name;
         if (!nameOfNodeToLoad.Equals(nameOfAvailableNode)) continue;
         node = i;
         ShowOptions();
         loadSpecificNodeScript.HideNextButton();
         storyDisplayText.text = node.GetNodeStory();
     }
 }

    // TODO может сделать разные методы с разным кол-вом параментроов и использовать в разных главах?
    private void VerifyWhatToLoadNext(string nodeNameRecieved1, string nodeNameSent1, string nodeNameRecieved2,
        string nodeNameSent2, string currentNodeName)
    {
        if (node.name != currentNodeName) return;
        loadSpecificNodeScript.ShowNextButton();
        firstOptionBtn.gameObject.SetActive(false);
        secondOptionBtn.gameObject.SetActive(false);
        if (usedNodes.Contains(nodeNameRecieved1))
        {
            nameOfNodeToLoad = nodeNameSent1;
            Debug.Log("node to load" + nameOfNodeToLoad);
        }
    }
}