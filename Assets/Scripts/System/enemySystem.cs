using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemySystem : MonoBehaviour{

    public float hp = 1f;
    public int dmgExplosion = 20;

    public GameObject explosion;
    public Avatar walk;
    public Avatar fall;
    public GameObject zombieMeshAnim;

    private NavMeshAgent agent;
    private scoreSystem scr;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        scr = GameObject.FindGameObjectWithTag("score").GetComponent<scoreSystem>();
        zombieMeshAnim.GetComponent<Animator>().avatar = walk;
    }
	
	void Update () {
        agent.destination = GameObject.FindGameObjectWithTag("Player").transform.position;
	}

    public void Damaged (float valueDmg) {
        hp -= valueDmg;
        if (hp <= 0)
            Death(false);
    }

    void Death(bool isExploded) {
        if (isExploded) { 
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
            scr.deleteHealth(dmgExplosion);
            Destroy(this.gameObject);
        }
        else {
            scr.addPoint(100);
            Destroy(this.gameObject.GetComponent<MeshCollider>());
            zombieMeshAnim.GetComponent<Animator>().avatar = fall;
            zombieMeshAnim.GetComponent<Animator>().SetTrigger("isDead");
            Destroy(this.gameObject, 0.8f);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player")
            Death(true);
    }
}
