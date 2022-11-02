using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class ElementSystem : MonoBehaviour
{
    private ElementActivation[,] activationLookup = new ElementActivation[(int)ElementEffect.NumberOfTypes, (int)ElementEffect.NumberOfTypes];

    private void Awake()
    {
        InitalizeLookup();
    }

    public void InitalizeLookup()
    {
        //List of all element activations
        ElementActivation[] allActivations = {
                new FireFireActivation(),
                new WaterWaterActivation(),
                new FireWaterActivation()
            };

        //Constructing matrix of all element activations
        foreach(ElementActivation elementActivation in allActivations)
        {
            activationLookup[(int)elementActivation.key[0], (int)elementActivation.key[1]] = elementActivation;

            //Adding duplicate for swapped element values
            if (elementActivation.key[0] != elementActivation.key[1])
            {
                activationLookup[(int)elementActivation.key[1], (int)elementActivation.key[0]] = elementActivation;
            }
        }
    }

    public void ActivateElement(CombatUnit target, Stats userStats, ElementEffect element1, ElementEffect element2)
    {
        activationLookup[(int)element1, (int)element2].ActivateElementEffect(target, userStats);
    }
}
