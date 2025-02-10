// using System;
// using Unity.AI.Navigation;
// using UnityEngine;
// using UnityEngine.AI;
// using UnityEngine.EventSystems;


// public class Monster : MonoBehaviour
// {
//     public Transform target;
//     public float speed = 3.5f;
//     public float attackRange = 1.5f;
//     public int damage = 10;
//     public float attackCooldown = 1.0f;
//     private float lastAttackTime;
//     public int health = 50;

//     // not sure about this
//     //public NavMeshSurface surface;
//     private NavMeshAgent agent;
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         agent = GetComponent<NavMeshAgent>();
//         agent.speed = speed;
//         //surface.BuildNavMesh();

//         //setting the target--prolly have to change later to find nearest tower
//         //necesarry for spawned in prefabs
//         if (target == null) {
//             target = FindObjectsByType<Tower>(FindObjectsSortMode.None)[0].transform;
//         }
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (target != null) {
//             agent.SetDestination(target.position);
//             if (isInrange() && readyToAttack()) {
//                 attack();
//                 lastAttackTime = Time.time;
//             }
//         }
//     }

//     void attack() {
//          Tower tower = target.GetComponent<Tower>();
//         if (tower != null)
//         {
//             tower.takeDamage(damage);
//         }
//     }

//     public void takeDamage(int amount) {
//         health -= amount;
//         if (health <= 0) {
//             Destroy(gameObject);
//         }
//     }

//     bool isInrange() {
//         return Vector3.Distance(transform.position,target.position) <= attackRange;
//     }

//     bool readyToAttack() {
//         return Time.time - lastAttackTime > attackCooldown;
//     }

//     public void SetTarget(Transform t)
//     {   
//         Debug.Log("resetting target");
//         target = t;
//         // if (agent != null && target != null)
//         // {
//         //     Debug.Log("resetting target");
//         //     agent.SetDestination(target.position);
//         // }
//     }

//     // method: find nearest tower.
//     public Transform findNearestTower() {
//         Tower[] towers = FindObjectsByType<Tower>(FindObjectsSortMode.None);
        
//         return null;
//     }

    
// }
