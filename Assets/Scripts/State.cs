using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class State : MonoBehaviour
{
    public enum STATE
    {
        IDLE,
        PATROL,
        PURSUE,
        ATTACK
    }

    public enum EVENT
    {
        ENTER,
        UPDATE,
        EXIT
    }

    public STATE nameState;
    protected EVENT stage;
    protected GameObject npc;
    protected Transform player;
    protected NavMeshAgent agent;
    protected State nextState;

    float visDist = 10.0f;
    float visAngle = 30.0f;
    float shootDist = 7.0f;

    public State(GameObject _npc, NavMeshAgent _agent, Transform _player)
    {

        npc = _npc;
        agent = _agent;
        player = _player;
        stage = EVENT.ENTER;
    }

    public virtual void Enter() { stage = EVENT.UPDATE; }
    public virtual void Update() { stage = EVENT.UPDATE; }
    public virtual void Exit() { stage = EVENT.EXIT; }

    public State Process()
    {

        if (stage == EVENT.ENTER) Enter();
        if (stage == EVENT.UPDATE) Update();
        if (stage == EVENT.EXIT)
        {

            Exit();
            return nextState;
        }

        return this;
    }

    public bool CanSeePlayer()
    {

        Vector3 direction = player.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);

        if (direction.magnitude < visDist && angle < visAngle)
        {

            return true;
        }

        return false;
    }

    public bool CanAttackPlayer()
    {

        Vector3 direction = player.position - npc.transform.position;
        if (direction.magnitude < shootDist)
        {

            return true;
        }

        return false;
    }
}
