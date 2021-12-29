using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatusManager : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthBarUI;
    public Slider slider;
    public Text healthNumericDisplay;


    public Transform camTransform;
	Quaternion originalRotation;
    public bool PresetCamera;

    public bool ismob;

    

    // Start is called before the first frame update
    void Start()
    {
        //camTransform = GameObject.Find("Main Camera").transform;
        health = maxHealth;
        slider.value = CalculateHealth();
        originalRotation = healthBarUI.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (camTransform == null && GameObject.Find("PlayerSpawner").GetComponent<SpawnSelectedCharacter>().currentPlayerCameras[0].transform != null && PresetCamera == false) {
        camTransform = GameObject.Find("PlayerSpawner").GetComponent<SpawnSelectedCharacter>().currentPlayerCameras[0].transform;
        }
        slider.value = CalculateHealth();
        healthNumericDisplay.text = (health).ToString()+"/"+(maxHealth).ToString();
        healthBarUI.transform.rotation = camTransform.rotation * originalRotation;
        if (health <= 0) {
            if (ismob == true) {
                StateNameController.XP+=1;
            }
            Destroy(gameObject);
        }

        if (health > maxHealth) {
            health = maxHealth;
        }
    }
    
    float CalculateHealth() {
        return health/maxHealth;
    }

    public void isZombieCounter() {
        GameObject.Find("MobManagement").GetComponent<WaveManager>().zombiesAlive = GameObject.Find("MobManagement").GetComponent<WaveManager>().zombiesAlive - 1;
    }
}
