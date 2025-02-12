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
    public float detectionRange = 15f;  // How close the player must be to get noticed
    public float stopChasingDistance = 17f; // If the player gets this far, monster stops chasing
    public float wanderRadius = 5f; // Random movement area for idle state
    public float wanderTime = 3f; // time between random wandering actions

    // monster grid stuff
    public Vector3 gridCenter;
    public Vector2 gridDimensions = new Vector2(10f, 10f);

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

        bool isPlayerInGrid = IsPositionInsideGrid(target.position);

       if (isPlayerInGrid && distanceToPlayer <=  detectionRange) {
            currentState = monsterState.Chasing; 
       }
       else if (!isPlayerInGrid || distanceToPlayer >= stopChasingDistance) {
            currentState = monsterState.Idle;
       }
       if (currentState == monsterState.Chasing) {
            ChasePlayer();
       }
       else if (currentState == monsterState.Idle) {
            WanderWithinGrid();
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
    //for when gridranges aren't used
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
    // for when gridRanges are used
    void WanderWithinGrid()
    {
        wanderTimer -= Time.deltaTime;

        if (wanderTimer <= 0)
        {
            Vector3 randomPosition = GetRandomPositionInGrid();
            agent.SetDestination(randomPosition);
            wanderTimer = wanderTime;
        }
    }

    private bool IsPositionInsideGrid(Vector3 position)
    {
        return position.x >= (gridCenter.x - gridDimensions.x / 2) &&
               position.x <= (gridCenter.x + gridDimensions.x / 2) &&
               position.z >= (gridCenter.z - gridDimensions.y / 2) &&
               position.z <= (gridCenter.z + gridDimensions.y / 2);
    }

    private Vector3 GetRandomPositionInGrid()
    {
        float randomX = UnityEngine.Random.Range(gridCenter.x - gridDimensions.x / 2, gridCenter.x + gridDimensions.x / 2);
        float randomZ = UnityEngine.Random.Range(gridCenter.z - gridDimensions.y / 2, gridCenter.z + gridDimensions.y / 2);
        return new Vector3(randomX, transform.position.y, randomZ);
    }

    public void setGrid(Vector3 gridCenter, Vector2 gridDimensions) {
        this.gridCenter = gridCenter;
        this.gridDimensions = gridDimensions;
    }
// sets target to player-- shouldn't ever change and is necesary for setup
    public void setTarget() {
        Debug.Log("target set");
        this.target = FindObjectsByType<Player>(FindObjectsSortMode.None)[0].transform;
    }


}
