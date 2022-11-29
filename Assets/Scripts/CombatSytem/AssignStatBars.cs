using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignStatBars : MonoBehaviour
{
    public CombatUnit combatUnit;
    public Slider HPSlider;
    public Slider MPSlider;
    public Slider CDSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MaxHP = combatUnit.currentStats.maxHP;
        float CurrentHP = combatUnit.currentHP;

        float HPSliderValue = CurrentHP / MaxHP;

        float MaxMP = combatUnit.currentStats.maxMP;
        float CurrentMP = combatUnit.currentMP;

        float MPSliderValue = CurrentMP / MaxMP;

        HPSlider.value = HPSliderValue;
        MPSlider.value = MPSliderValue;





    }

}
