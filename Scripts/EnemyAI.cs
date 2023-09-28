using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{

    public static EnemyAI Instance { get; private set; }
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

    public float minDistanceBetweenEnemies;
    public float changeDirectionDistance;

    public List<Transform> nearbyEnemies = new List<Transform>();

    public static event System.Action<Transform> OnEnemySpawned;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    private void OnEnable()
    {
        OnEnemySpawned?.Invoke(transform);
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

            CheckEnemyDistances(); // Panggil fungsi pemantauan jarak
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

    private void CheckEnemyDistances()
    {
        foreach (Transform enemy in nearbyEnemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.position);
            if (distance < minDistanceBetweenEnemies)
            {
                if (distance < changeDirectionDistance)
                {
                    // Jarak terlalu dekat, ubah arah haluan
                    ChangeDirection();
                }
            }
        }
    }

    private void ChangeDirection()
    {
        // Mengubah arah haluan dengan rotasi acak
        transform.Rotate(Vector3.up, Random.Range(0, 360));
    }
}