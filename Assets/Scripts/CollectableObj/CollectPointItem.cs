using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Player;
using Paintastic.GridSystem;
using Paintastic.Audio;

namespace Paintastic.CollectibleObject
{
    public class CollectPointItem : BaseCollectableObject
    {
        public override void ActiveEfect(GridCell[,] _grids, Player.Player activator)
        {
            int score = 0;
            foreach (GridCell go in _grids)
            {
                if (go.CompareTag(activator.tag))
                {
                    score += 1;
                    go.ResetColor();
                }
            }

            AudioManager.instance.PlaySfx("SFX_CollectPoint");
            activator.SendMyScore(score);
        }

    }
}
