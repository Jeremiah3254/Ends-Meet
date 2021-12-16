using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] zombieTypes;
    public GameObject[] currentZombies;

    public GameObject[] spawnableLocations;
    public int mobSpawnDelay = 5;

    public bool spawnNewWave;
    public bool currentWaveFound;
    public int zombiesAlive;

    public int zombieAmount;
    //Types of zombies to Spawn
    public int normalZombies;
    public int redZombies;
    //Types of zombies to spawn
    public Wave[] waves;
    void Start()
    {
        currentZombies = new GameObject[50000];
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaveFound == true) {
            currentWaveFound = false;
            zombiesAlive = 0;

            zombieAmount = waves[StateNameController.currentWave-1].zombieAmount;
            normalZombies = waves[StateNameController.currentWave-1].normalZombies;
            redZombies = waves[StateNameController.currentWave-1].redZombies;

            spawnNewWave = true;
        }


        if (zombieAmount != 0 && spawnNewWave == true) {
                StartCoroutine(spawnDelay());
        } else {
            spawnNewWave = false;
        }
    }

    IEnumerator spawnDelay() {
        addDifficultyBuff(spawningOrder(), zombieTypes[spawningOrder()].GetComponent<StatusManager>().maxHealth, zombieTypes[spawningOrder()].GetComponent<AttackClosestPlayer>().enemyDamage, zombieTypes[spawningOrder()].GetComponent<AttackClosestPlayer>().attackRange, zombieTypes[spawningOrder()].GetComponent<AttackClosestPlayer>().attackSpeed);
        tallyZombies();
        yield return new WaitForSeconds(mobSpawnDelay);
    }

    public int spawningOrder() {
        if (normalZombies > 0) {
            return 0;
        } else if (redZombies > 0) {
            return 1;
        }
        return 0;
    }

    public void tallyZombies() {
        if (spawningOrder() == 0) {
            normalZombies = normalZombies-1;
        }else if (spawningOrder() == 1) {
            redZombies = redZombies-1;
        }
        zombieAmount = zombieAmount-1;
    }

    public void addDifficultyBuff(int zombieType,float health,float damage,float range,float attackSpeed) {
        if (StateNameController.difficulty == 1) {
            health = (health*0.1f);
            damage = (damage*0.1f);
            range = (range*0.1f);
            attackSpeed = (int) (attackSpeed*0.1f);
        }
        addChallengeEffects(zombieType,health,damage,range,attackSpeed);
    }

    public void addChallengeEffects(int zombieType,float health,float damage,float range,float attackSpeed) {

        spawnZombie(zombieType,health,damage,range,attackSpeed);
    }

    public void spawnZombie(int zombieType,float health,float damage,float range,float attackSpeed) { 
        GameObject newZombie = Instantiate(zombieTypes[zombieType],spawnableLocations[(int) (Random.Range(0,spawnableLocations.Length))].transform.position, zombieTypes[zombieType].transform.rotation);
        //assign zombie buffs
        newZombie.GetComponent<StatusManager>().maxHealth = health;
        newZombie.GetComponent<StatusManager>().health = health;
        newZombie.GetComponent<AttackClosestPlayer>().enemyDamage = damage;
        newZombie.GetComponent<AttackClosestPlayer>().attackRange = range;
        newZombie.GetComponent<AttackClosestPlayer>().attackSpeed = attackSpeed;
        //assign zombie buffs

        //(int) (Random.Range(0,spawnableLocations.Length))
        currentZombies[zombiesAlive] = newZombie;
        zombiesAlive+=1;
    }
}
