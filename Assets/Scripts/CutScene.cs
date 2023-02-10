using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    bool canEnter = true;
   
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") == true && canEnter)
        {
            canEnter = false;
            SceneManager.LoadScene("FindInstitute", LoadSceneMode.Additive);
            FindObjectOfType<DisableRoot>().gameObject.SetActive(false);
        }
    }
}
