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


    private float randomDistance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

 


    private IEnumerator EnemyAIUpdate()
    {
        while (player.gameObject.activeInHierarchy)
        {
            switch (currentState)
            {
                case State.Idle:
                    if (PlayerInRange(randomDistance))
                    {
                        currentState = State.Chasing;
                    }
                    break;

                case State.Chasing:
                    if (PlayerInRange(attackRange))
                    {
                        currentState = State.Attacking;
                    }
                    else if (!PlayerInRange(randomDistance))
                    {
                        currentState = State.Idle;
                    }
                    else
                    {
                        ChasePlayer();
                    }
                    break;

                case State.Attacking:
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

            yield return null; // Memberi kesempatan pada frame berikutnya
        }
    }


    void Start()
    {
        randomDistance = Random.Range(50, chaseRange);
        StartCoroutine(EnemyAIUpdate());
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