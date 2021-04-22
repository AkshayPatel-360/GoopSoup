using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedState : BaseState
{
    public EnragedState(Monster _monster) : base("Enraged", _monster)
    {

    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void StayState(float dt)
    {
        monster.MoveTowardEnraged(PlayerManager.Instance.player.transform.position);
        base.StayState(dt);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
