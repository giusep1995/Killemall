using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour {

    public float dmg = 1f;
    public float range = 100f;
    public float fireRate = 1f;
    public float bullets = 6f;

    public GameObject impactEmission;
    public ParticleSystem muzzleFlash;
    public ParticleSystem tracer;

    private Camera fpsCam;
    private float bulletsInCharge;

    private void Start() {
        fpsCam = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
        bulletsInCharge = bullets;
    }

    void Update () {
        if (Input.GetButtonDown("Attack")){
            bulletsInCharge -= 1;
            Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
	}

    void Shoot() {
        RaycastHit hit;
        muzzleFlash.Play();
        tracer.Play();
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            if (hit.transform.tag == "monster") {
                hit.transform.GetComponent<enemySystem>().Damaged(dmg);
            }
            GameObject imp = Instantiate(impactEmission, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(imp, 2f);
        }
    }

    void Reload() {
        bulletsInCharge = bullets;
    }
}
