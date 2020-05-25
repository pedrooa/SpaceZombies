using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Zombie : MonoBehaviour
{
    public float screamDelta = 5F;
    public float speed = 1;
    private Transform target;
    private float nextScream = 5F;
    private float myTime = 0.0F;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("LooseScene");
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);

        transform.position += transform.forward * speed * Time.deltaTime;

        myTime = myTime + Time.deltaTime;

        if (myTime > nextScream)
        {
            nextScream = myTime + screamDelta;
            audioSource.Play();

            nextScream = nextScream - myTime;
            myTime = 0.0F;
        }
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
