using System;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1Controller : MonoBehaviour
{
    //nodes for checks after specific player choices
    public string NodeNameRecieved1 { get; } = "Подслушать";

    public string NodeNameRecieved2 { get; } = "Постучаться в дверь";

    public string NodeNameSent1 { get; } = "Подслушивали";

    public string NodeNameSent2 { get; } = "Не подслушивали";
    public string CurrentNodeName { get; } = "Возмущение аббата";
        
    //nodes for checks if we need to load Year And Place window
    public string Chapter1NodeName1{ get; } = "Глава 1 Start";
    public string Chapter1NodeName2 { get; } = "В замке барона";
        
    //text to load in Year and Place window
    public string TextForYearAndPlace1 { get; } = "1130 год Партене, Франция";
    public string TextForYearAndPlace2 { get; } = "Неделю спустя в замке барона фон Беф";

}