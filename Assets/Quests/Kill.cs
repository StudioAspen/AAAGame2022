using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : Quest
{
    // Start is called before the first frame update
    void Start()
    {
        title = "Kill Things";
        description = "Kill three things";
        xpReward = 100;
        goldReward = 200;

        goals.Add(new KillGoal(this, 0, "Kill three things", false, 0, 3));

        goals.ForEach(g => g.Init());
        //goes though each goes and does init
    }
}
