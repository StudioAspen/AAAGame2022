using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// INCOMPLETE, NOT USED ANYWHERE
/// </summary>
public class ElementStatus
{
    public string name;
    public Element element;
    public CombatUnit owner;
    public ElementStatus(Element _element, CombatUnit _owner)
    {
        owner = _owner;
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
    

public void ElementActivation(Element activationElement, CombatUnit target)
    {
        HashSet<Element> elements = new HashSet<Element>();
        elements.Add(element);
        elements.Add(activationElement);

        if(elements.Contains(Element.FIRE))
        {
            if(elements.Contains(Element.WATER))
            {
                //FIRE WATER
                target.ChangeHP(-25);
                target.AddStatEffect(new AttackDownEffect(1)) ;
            }
            else if(elements.Contains(Element.TERA))
            {
                //FIRE TERA
            }
            else
            {
                //FIRE FIRE
                target.ChangeHP(-50);
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
                target.AddStatEffect(new AttackDownEffect(3));
            }
        }
        else if (elements.Contains(Element.TERA))
        {
            //TERA TERA
        }
    }
}
