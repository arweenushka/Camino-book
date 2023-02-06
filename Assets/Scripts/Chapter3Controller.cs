using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter3Controller : MonoBehaviour
{
    public string NodeNameRecieved1 { get; } = "Вместе";

    public string NodeNameRecieved2 { get; } = "По очереди";

    public string NodeNameSent1 { get; } = "Вдвоем бык за спиной";

    public string NodeNameSent2 { get; } = "Один бык за спиной";
    
    public string CurrentNodeName { get; } = "Забег3";
    
    public string NodeNameRecieved3 { get; } = "Подставить Хавьера";
    
    public string NodeNameRecieved4 { get; } = "Обмануть быка вместе";
    
    public string NodeNameSent3 { get; } = "Толкали";

    public string NodeNameSent4 { get; } = "Ужин в Памплоне";
    
    public string CurrentNodeName2 { get; } = "Финиш2";
        
    //nodes for checks if we need to load Year And Place window
    public string Chapter3NodeName1{ get; } = "Глава 3 Start";
        
    //text to load in Year and Place window
    public string TextForYearAndPlace1 { get; } = "Памплона 4 дня спустя";
    
    //nodes for checks if we need to load Year And Place window
    
    public string Chapter3NodeName2{ get; } = "Ужин в Памплоне";
        
    //text to load in Year and Place window
    public string TextForYearAndPlace2 { get; } = "Вечером того же дня";
}
