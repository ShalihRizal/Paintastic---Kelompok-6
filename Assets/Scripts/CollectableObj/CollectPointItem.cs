using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Player;

public class CollectPointItem : BaseCollectableObject
{
    public override void ActiveEfect(GridCell[,] _grids, Player activator)
    {
        int score = 0;
        foreach (GridCell go in _grids)
        {
            //kirim score
            //reset warna
            if (go.CompareTag(activator.tag))
            {
                score += 1;
                go.ResetColor();
            }
        }

        activator.SendMyScore(score);
		AudioManager.instance.PlaySfx("SFX_CollectPoint");
    }
}
