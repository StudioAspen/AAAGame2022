using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActionBar : MonoBehaviour
{
    [SerializeField]
    GameObject layoutGroup;
    [SerializeField]
    GameObject actionSlider;

    CombatController combatController;
    Dictionary<Slider, CombatUnit> combatUnits = new Dictionary<Slider, CombatUnit>();
    List<Slider> sliders = new List<Slider>();
    RectTransform originalRect;

    // Start is called before the first frame update
    void Start()
    {
        originalRect = actionSlider.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < combatUnits.Count; i++)
        {
            SliderUpdate(i);
        }
    }
    public void InitalizeBars(CombatController combatController)
    {
        foreach (GameObject player in combatController.players)
        {
            AssignActionBar(player.GetComponent<CombatUnit>());
        }
        foreach (GameObject enemy in combatController.enemies)
        {
            AssignActionBar(enemy.GetComponent<CombatUnit>());
        }

    }
    void SliderUpdate(int index)
    {
        //Updating slider based on unit cd
        Slider currentSlider;
        currentSlider = sliders[index];
        CombatUnit currentUnit = combatUnits[currentSlider];
        currentSlider.value = 1 - (currentUnit.currentMoveCD / currentUnit.currentStats.SpeedToSec());

        //Moving to layout group if ready
        /*
        if(currentSlider.value >= 0.9)
        {
            currentSlider.transform.SetParent(layoutGroup.transform);
        }
        else
        {
            
            RectTransform currentSliderRectTransform = currentSlider.GetComponent<RectTransform>();
            RectTransform rectTransform = GetComponent<RectTransform>();
            currentSlider.transform.SetParent(transform);
            //currentSliderRectTransform.SetParent(rectTransform);
            currentSliderRectTransform.anchoredPosition = rectTransform.position;
            currentSliderRectTransform.pivot = new Vector2(0.5f, 0.5f);
            currentSliderRectTransform.anchorMin = new Vector2(0, 0.5f);
            currentSliderRectTransform.anchorMax = new Vector2(1, 0.5f);
            //currentSliderRectTransform.sizeDelta = rectTransform.rect.size;
            //currentSliderRectTransform.position = new Vector2(0, 0);
            //currentSliderRectTransform.transform.SetParent(rectTransform);
            
            if (originalRect != null)
            {
                //RectTransform currentSliderRectTransform = currentSlider.GetComponent<RectTransform>();
                
                //currentSliderRectTransform. = new Rect(0, 0, 0, 0);
                /*
                currentSliderRectTransform = originalRect;
                currentSliderRectTransform.anchorMin = new Vector2(0, 0.5f);
                currentSliderRectTransform.anchorMax = new Vector2(1, 0.5f);
                currentSliderRectTransform.pivot = new Vector2(0.5f, 0.5f);
                
            }

        }
        */
    }
    void AssignActionBar (CombatUnit unit)
    {
        
        GameObject newSlider = Instantiate(actionSlider, transform.position, Quaternion.identity, transform);
        newSlider.GetComponentInChildren<Image>().sprite = unit.GetComponent<CombatUnit>().profile;
        sliders.Add(newSlider.GetComponent<Slider>());
        combatUnits.Add(newSlider.GetComponent<Slider>(), unit);
    }
}
