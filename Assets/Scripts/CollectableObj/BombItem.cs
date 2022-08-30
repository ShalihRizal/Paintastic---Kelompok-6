using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.GridSystem;
using Paintastic.Player;

namespace Paintastic.CollectibleObject
{
    public class BombItem : BaseCollectableObject
    {
        public override void ActiveEfect(GridCell[,] grid, Player.Player activator)
        {
            foreach (GridCell item in grid)
            {
                if (item.CompareTag(activator.tag)) item.ResetColor();
            }
		AudioManager.instance.PlaySfx("SFX_Bomb");
        }
    }

}
