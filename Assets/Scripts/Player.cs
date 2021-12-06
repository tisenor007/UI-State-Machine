using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource gunFire;
    private RaycastHit rayHit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gunFire.Play();
            Shoot();
        }
    }

    public void Shoot()
    {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out rayHit, 100))
        {
            if (rayHit.transform.gameObject.name == "Character") { Destroy(rayHit.transform.gameObject); }
        }
    }
}
