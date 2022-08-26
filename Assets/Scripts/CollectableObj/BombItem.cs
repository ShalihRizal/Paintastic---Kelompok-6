using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : BaseCollectableObject
{
    private Action activationAction;

    public override void ActiveEfect()
    {
        activationAction();
        activationAction = null;
    }

    public override void SubscribeActivation(Action action)
    {
        activationAction += action;
    }
}
