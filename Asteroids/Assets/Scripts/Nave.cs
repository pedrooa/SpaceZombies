using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public GameObject bullet;


    public float fireDelta = 0.5F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;
    public int lifes = 3;

    float torque = 0.05f;
    float speed = 1.0f;

    


    void FixedUpdate()
    {

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        float p = Input.GetAxis("Jump");

        Rigidbody rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * speed * p);
        rb.AddTorque(transform.up * torque * h);
        rb.AddTorque(transform.right * torque * v);
    }
    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire2") && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            GameObject instancia = Instantiate(bullet, transform.position + (transform.forward * 2), transform.rotation) as GameObject;
            instancia.GetComponent<Rigidbody>().velocity = 20.0f * transform.forward;
            Destroy(instancia, 5.0f); // Destroi o tiro depois de 5 segundos
            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }


}
