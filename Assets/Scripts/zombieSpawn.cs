using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawn : MonoBehaviour {

    public int secondSpawn = 5;
    public GameObject monster;

	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
	}

    IEnumerator Spawn() {
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("spawnPoint");
        while (true) { 
            foreach (GameObject spawn in spawnPoints) {
                Instantiate(monster, spawn.transform.position, spawn.transform.rotation);
            }
            yield return new WaitForSeconds(secondSpawn);
        }
    }
}
