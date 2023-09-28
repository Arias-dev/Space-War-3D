using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public enum State
    {
        Idle,
        Chasing,
        Attacking
    }

    public State currentState = State.Idle;

    [SerializeField] private EnemyProjectilePool enemyProjectile;

    private Transform player;
    public float chaseRange;
    public float attackRange;
    public float moveSpeed; // Kecepatan gerak


    public Vector3 fireDirection; // Menentukan arah tembakan


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(player.gameObject.activeInHierarchy == true)
        {


            switch (currentState)
            {
                case State.Idle:
                    // Logika untuk keadaan idle
                    if (PlayerInRange(chaseRange))
                    {
                        currentState = State.Chasing;
                    }
                    break;

                case State.Chasing:
                    // Logika untuk keadaan chasing
                    if (PlayerInRange(attackRange))
                    {
                        currentState = State.Attacking;
                    }
                    else if (!PlayerInRange(chaseRange))
                    {
                        currentState = State.Idle;
                    }
                    else
                    {
                        ChasePlayer();
                    }
                    break;

                case State.Attacking:
                    // Logika untuk keadaan attacking
                    if (!PlayerInRange(attackRange))
                    {
                        currentState = State.Chasing;
                    }
                    else
                    {
                        AttackPlayer();
                    }
                    break;
            }

        }
       
    }

    bool PlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.position) <= range;
    }

    void ChasePlayer()
    {
        // Menghadap ke arah pemain
        transform.LookAt(player);

        // Gerak maju ke arah pemain
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void AttackPlayer()
    {

        FireFromEnemy();


        // Logika serangan
        // Contoh: player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }

    void FireFromEnemy()
    {

        enemyProjectile.FireProjectile();

    }
}
