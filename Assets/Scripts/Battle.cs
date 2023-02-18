using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    public Collider player;
    public Collider ground;
    public Collider trigger;
    public GameObject character;

    public bool battleScene = false;

    [SerializeField]
    private CharacterStats characterStats;
    void Update()
    {
        characterStats.overworldPos = character.transform.position;
    }
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") == true)
        {
            characterStats.battleScene = true;

            SceneManager.LoadScene("Battle");
            Debug.Log("Battle begins");
        }


    }


}
