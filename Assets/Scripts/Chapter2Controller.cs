using UnityEngine;

public class Chapter2Controller : MonoBehaviour
{
    public string NodeNameRecieved1 { get; } = "Согласиться на проводника";

    public string NodeNameRecieved2 { get; } = "Отказаться от проводника";

    public string NodeNameSent1 { get; } = "Угрозы проводнику";

    public string NodeNameSent2 { get; } = "На утро без проводника";

    public string CurrentNodeName { get; } = "После проводника";
        
    //nodes for checks if we need to load Year And Place window
    public string Chapter2NodeName1{ get; } = "Глава 2 Start";
        
    //text to load in Year and Place window
    public string TextForYearAndPlace1 { get; } = "Месяц спустя, Сен-Жан-Пье-де-Пор";
}