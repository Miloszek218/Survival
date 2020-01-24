using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerAi : MonoBehaviour
{
    Animator animator;
    Transform player;
    Rigidbody rigidbody;
    public enum State
    {
        Idle, Attack, GoToPlayer
    }

    public State state = State.Idle;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                animator.SetFloat("speed", 0);
                if (Vector3.Distance(transform.position, player.position) < 9f)
                    state = State.GoToPlayer;
                return;
            case State.GoToPlayer:
                animator.SetFloat("speed", 1);
                transform.LookAt(player);
                rigidbody.velocity = transform.forward * 1f;
                if (Vector3.Distance(transform.position, player.position) > 10f)
                    state = State.Idle;
                if (Vector3.Distance(transform.position, player.position) < 3f)
                    state = State.Attack;
                return;
            case State.Attack:
                animator.SetTrigger("attack");
                transform.LookAt(player);
                if (Vector3.Distance(transform.position, player.position) > 4f)
                    state = State.GoToPlayer;
                return;

        }
    }
}
