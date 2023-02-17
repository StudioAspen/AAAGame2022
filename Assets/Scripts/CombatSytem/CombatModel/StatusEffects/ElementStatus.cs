using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// INCOMPLETE, NOT USED ANYWHERE
/// </summary>
public class ElementStatus
{
    public enum Element { 
        FIRE,
        WATER,
        TERA
    }

    public string name;
    public Element element;

    ElementStatus(Element _element)
    {
        element = _element;
        switch(element) {
            case Element.FIRE:
                name = "Fire Element";
                break;
            case Element.WATER:
                name = "Water Element";
                break;
            case Element.TERA:
                name = "Tera Element";
                break;
            default:
                name = "No Element";
                break;
        }
    }
    

protected void ElementActivation(Element element1, Element element2, CombatUnit combatUnit)
    {
        HashSet<Element> elements = new HashSet<Element>();
        elements.Add(element1);
        elements.Add(element2);

        if(elements.Contains(Element.FIRE))
        {
            if(elements.Contains(Element.WATER))
            {
                //FIRE WATER
                combatUnit.ChangeHP(-25);
                combatUnit.AddStatEffect(new AttackDownEffect(1)) ;
            }
            else if(elements.Contains(Element.TERA))
            {
                //FIRE TERA
            }
            else
            {
                //FIRE FIRE
                combatUnit.ChangeHP(-50);
            }
        }
        else if(elements.Contains(Element.WATER))
        {
            if (elements.Contains(Element.TERA))
            {
                //WATER TERA
            }
            else
            {
                //WATER WATER
                combatUnit.AddStatEffect(new AttackDownEffect(3));
            }
        }
        else if (elements.Contains(Element.TERA))
        {
            //TERA TERA
        }
    }
}
