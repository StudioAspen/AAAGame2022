using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class ElementEffect {
    
    public static Sprite GetElementIcon(Element _element)
    {
        Sprite output = null;
        string elementSpriteName = "";
        switch(_element)
        {
            case Element.FIRE:
                elementSpriteName = "Icons_for_daybreak_7";
                break;
            case Element.WATER:
                elementSpriteName = "Icons_for_daybreak_8";
                break;
            case Element.TERA:
                elementSpriteName = "Icons_for_daybreak_9";
                break;
            default:
                elementSpriteName = "Icons_for_daybreak_4"; // Transparent Image
                break;
        }
        Sprite[] allSprites = Resources.LoadAll<Sprite>("Sprites/Icons_for_daybreak");
        foreach(Sprite sprite in allSprites)
        {
            if (sprite.name == elementSpriteName) {
                output = sprite;
            }
        }
        return output;
    }
}

public enum Element
{
    FIRE,
    WATER,
    TERA,
    NONE
}
