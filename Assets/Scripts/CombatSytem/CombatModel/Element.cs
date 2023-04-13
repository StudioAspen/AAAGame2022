using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class ElementEffect {
    
    public static Sprite GetElementIcon(Element _element)
    {
        switch(_element)
        {
            case Element.FIRE:
                //Debug.Log(Resources.Load<Sprite>("Sprites/redSquare"));
                return Resources.Load<Sprite>("Sprites/ElementIcons/redSquare");
            case Element.WATER:
                return Resources.Load<Sprite>("Sprites/ElementIcons/blueSquare");
            case Element.TERA:
                return Resources.Load<Sprite>("Sprites/ElementIcons/greenSquare");
        }
        return null;
    }
}

public enum Element
{
    FIRE,
    WATER,
    TERA,
    NONE
}
