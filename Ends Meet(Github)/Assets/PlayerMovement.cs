using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject playerCamera;
    public CharacterController controller;
    public bool inCombat = false;
    public bool attacked = false;
    public float speed = 12f;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    bool readyToAttack = true;
    
    //playerStatsStuff
    GameObject[] enemies;
    public float characterDamage;
    public int sight;
    public int attackRange;
    public float attackSpeed;
    public float armor;
    public float lifeRegen;
    public float outOfCombatTime;
    public bool regenInCombat;
    bool healingOnCD = false;
    //playerStatsStuff
    //GameObject[] Enemies;
    Coroutine attacking;
    Coroutine combatChecking;
    Coroutine passiveRegen;
    void Start()
    { 
        enemies = new GameObject[50000];
        enemies = GameObject.Find("MobManagement").GetComponent<WaveManager>().currentZombies;
        speed = 0f;
    }
    void Update()
    {
        float dist = Vector3.Distance(enemies[findPlayerTarget()].transform.position,transform.position);
        if (dist <= attackRange && readyToAttack == true && speed == 0) {
            attacking = StartCoroutine(attackCooldown(enemies[findPlayerTarget()]));
        }

        if (inCombat == true & attacked == true & combatChecking == null) {
            attacked = false;
            combatChecking = StartCoroutine(outOfCombatCheck());
        } else if (inCombat == true & attacked == true & combatChecking != null) {
            attacked = false;
            StopCoroutine(combatChecking);
            combatChecking = StartCoroutine(outOfCombatCheck()); 
        }

        if (inCombat == false & healingOnCD == false & GetComponent<StatusManager>().health < GetComponent<StatusManager>().maxHealth) {
            passiveRegen = StartCoroutine(healingCooldown());
        }

        enemies = GameObject.Find("MobManagement").GetComponent<WaveManager>().currentZombies;

        //if (readyToAttack == true) {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            if (Input.GetKey("left shift") && isGrounded)
            {
                speed = 20f;
            }
            else if ((x != 0 | z != 0))
            {
                speed = 5f;
            }
            else
            {
                speed = 0f;
            }

            

            Vector3 move = playerCamera.transform.right * x + playerCamera.transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            /*if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }*/

        //}
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    
    IEnumerator attackCooldown(GameObject target) {
        attackPlayer(target);
        readyToAttack = false;
        yield return new WaitForSeconds(attackSpeed);
        readyToAttack = true;
    }

    IEnumerator outOfCombatCheck() {
        inCombat = true;
        yield return new WaitForSeconds(outOfCombatTime);
        inCombat = false;
    }

    IEnumerator healingCooldown() {
        passiveHealing();
        healingOnCD = true;
        yield return new WaitForSeconds(1);
        healingOnCD = false;
    }

    public void passiveHealing() {
        GetComponent<StatusManager>().health = GetComponent<StatusManager>().health + lifeRegen;
    }

    public void attackPlayer(GameObject target) {
        if ((characterDamage - target.GetComponent<AttackClosestPlayer>().armor) <= 0f) {
            transform.rotation = Quaternion.LookRotation((target.transform.position - transform.position),Vector3.up);
            target.GetComponent<StatusManager>().health = target.GetComponent<StatusManager>().health - 1;
        } else {
            transform.rotation = Quaternion.LookRotation((target.transform.position - transform.position),Vector3.up);
            target.GetComponent<StatusManager>().health = target.GetComponent<StatusManager>().health - (characterDamage - target.GetComponent<AttackClosestPlayer>().armor);
        }
    }

    public int findPlayerTarget() {
        int closestEnemy = 0;  
        float closestEnemyPoisiton = float.MaxValue;
        for (int i = 0; i<enemies.Length; i++) {
            if (enemies[i] != null) {
                if (Vector3.Distance(enemies[i].transform.position,transform.position) < closestEnemyPoisiton) {
                    closestEnemyPoisiton = Vector3.Distance(enemies[i].transform.position,transform.position);
                    closestEnemy = i;
                }
            }
        }
        return closestEnemy;
    }
    
}
