using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class ElementEffect {
    
    public static Sprite GetElementIcon(Element _element)
    {
        Sprite output = null;
        switch(_element)
        {
            case Element.FIRE:
                output = Resources.Load<Sprite>("Sprites/ElementIcons/redSquare");
                break;
            case Element.WATER:
                output = Resources.Load<Sprite>("Sprites/ElementIcons/blueSquare");
                break;
            case Element.TERA:
                output = Resources.Load<Sprite>("Sprites/ElementIcons/greenSquare");
                break;
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
