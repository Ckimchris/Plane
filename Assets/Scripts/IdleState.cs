using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    public IdleState(GameObject _npc, NavMeshAgent _agent, Transform _player)
            : base(_npc, _agent, _player)
    {

        nameState = STATE.IDLE;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        nextState = new PatrolState(npc, agent, player);
        stage = EVENT.EXIT;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
