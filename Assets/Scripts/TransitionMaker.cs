using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TransitionMaker : MonoBehaviour
{
    public Image image;
    private UnityEvent afterTransition = new UnityEvent();
    public void StartTransition(Color _color, UnityEvent _afterTransition = null)
    {
        gameObject.SetActive(true);
        image = GetComponent<Image>();
        image.color = _color;
        image.color = new Vector4(image.color.r, image.color.g, image.color.b, 0);
        if (_afterTransition != null)
        {
            afterTransition = _afterTransition;
        }
        StartCoroutine(Transitioning());
    }
    IEnumerator Transitioning()
    {
        float alpha;
        while (Mathf.Abs(1f - image.color.a) > 0.001f)
        {
            alpha = Mathf.Lerp(image.color.a, 1, 0.05f);
            image.color = new Vector4(image.color.r, image.color.g, image.color.b, alpha);

            yield return new WaitForSeconds(0.01f);
        }
        afterTransition.Invoke();
    }
}
