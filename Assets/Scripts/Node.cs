using UnityEngine;

[CreateAssetMenu(menuName = "Node")]
public class Node : ScriptableObject
{
    [TextArea(30, 10)][SerializeField]private string storyText;
    [SerializeField] private Node[] nextNodes;

    public string GetNodeStory()
    {
        return storyText;
    }

    public Node[] GetNextNodes()
    {
        return nextNodes;
    }
}