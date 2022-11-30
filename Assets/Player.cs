using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 5;
    public int xp = 10;
    public int gold = 20;

    public Quest quest;

    public void Battle()
    {
        hp -= 1;
        xp += 2;
        gold += 10;
    }
}
