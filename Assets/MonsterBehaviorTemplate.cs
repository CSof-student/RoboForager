using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR.Haptics;

public class MonsterBehaviorTemplate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Transform target;
    public float speed = 3.5f;
    //public float attackRange = 1.5f;
    public int damage = 10;
    public float attackCooldown = 1.5f;
    private float nextDamageTime = 0f;
    private float lastAttackTime;
    public int health = 50;

    // monster intelligence stuff
    public enum monsterState {Idle, Chasing};
    private monsterState currentState = monsterState.Idle;
    public float detectionRange = 10f;  // How close the player must be to get noticed
    public float stopChasingDistance = 15f; // If the player gets this far, monster stops chasing
    public float wanderRadius = 5f; // Random movement area for idle state
    public float wanderTime = 3f; // time between random wandering actions

    public Player player;

   
    private NavMeshAgent agent;
    private float wanderTimer;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        player = FindObjectsByType<Player>(FindObjectsSortMode.None)[0];
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
       if (distanceToPlayer <=  detectionRange) {
            currentState = monsterState.Chasing; 
       }
       else if (distanceToPlayer >= stopChasingDistance) {
            currentState = monsterState.Idle;
       }
       if (currentState == monsterState.Chasing) {
            ChasePlayer();
       }
       else if (currentState == monsterState.Idle) {
            wander();
       }
    }
   

    private void OnCollisionStay(Collision other) {
        //Debug.Log("monster has made contact");
        if (other.gameObject.CompareTag("Player") && Time.time >= nextDamageTime) {
            player.takeDamage(damage);
            nextDamageTime = Time.time + attackCooldown;
        }
    }

    void ChasePlayer() {
        agent.SetDestination(target.position);
    }

    void wander() {
        wanderTimer -= Time.deltaTime;

        if (wanderTimer <= 0)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * wanderRadius;
            randomDirection += transform.position;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1))
            {
                agent.SetDestination(hit.position);
            }
            wanderTimer = wanderTime;
        }
    }


}
