using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float xOrg; // posição X no Perlin Noise
    public float yOrg; // posição Y no Perlin Noise
    public float scale = 1.0F; // escala na busca do Perlin Noise

    private Texture2D noiseTex; // textura de ruido
    private Color[] pix;    // pixels da imagem
    //private Renderer rend;  // renderizador do objeto
    public Transform explosionPrefab;
    public GameObject NaveObject;
    public AudioClip explosion1;
    public AudioClip explosion2;
    public AudioClip explosion3;
    private AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        NaveObject = GameObject.FindGameObjectWithTag("Player");


        scale = Random.Range(3.0f, 10.0f); // gera números aleatórios para escala
        xOrg = Random.Range(0, 99); // gera números aleatórios para posição x
        yOrg = Random.Range(0, 99); // gera números aleatórios para posição y

        //rend = GetComponent<Renderer>(); // pega o renderizador do objeto
        //noiseTex = new Texture2D(18, 18); // a textura gerada será de 18x18
        //pix = new Color[noiseTex.width * noiseTex.height]; //pixels da textura
        //rend.material.SetTexture("_MainTex", noiseTex); // textura cor
        //rend.material.SetTexture("_DispTex", noiseTex); //textura deslocamento
        //CalcNoise(); // calcula a textura de ruido
    }

    //void CalcNoise()
    //{
    //    int y = 0;
    //    while (y < noiseTex.height)
    //    {
    //        int x = 0;
    //        while (x < noiseTex.width)
    //        {
    //            float xCoord;
    //            float yCoord;
    //            // Para evitar que os pólos da esfera fiquem estranhos
    //            if (y < 3 || y > noiseTex.height - 3)
    //            {
    //                xCoord = (xOrg / noiseTex.width) * scale;
    //                yCoord = (yOrg / noiseTex.height) * scale;
    //            }
    //            else
    //            {
    //                xCoord = xOrg + ((float)x / noiseTex.width) * scale;
    //                yCoord = yOrg + ((float)y / noiseTex.height) * scale;
    //            }

    //            float sample = Mathf.PerlinNoise(xCoord, yCoord);
    //            pix[y * noiseTex.width + x] = new Color(sample, sample, sample);

    //            x++;
    //        }
    //        y++;
    //    }

    //    // Copia os pixeis para a textura e carrega na GPU.
    //    noiseTex.SetPixels(pix);
    //    noiseTex.Apply();
    //}
    void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        var instancia = Instantiate(explosionPrefab, pos, rot);

        if (collision.gameObject.tag == "Player")
        {
            Nave Nave = NaveObject.GetComponent<Nave>();


            if (Nave.lifes >= 1)
            {
                //audioSource.PlayOneShot(explosion1);
                Nave.lifes -= 1;
                //Destroy(instancia.gameObject, 0.5f);
                //Destroy(gameObject);

            }
            else
            {
                audioSource.PlayOneShot(explosion1);
                Destroy(instancia.gameObject, 0.5f);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        } else if (collision.gameObject.tag == "Bullet")
        {
            //audioSource.PlayOneShot(explosion1);
            
            Destroy(instancia.gameObject, 0.5f);
            Destroy(collision.gameObject);
            gameObject.GetComponentInChildren<Renderer>().enabled = false;
            StartCoroutine(Explosion());
            //Destroy(gameObject);
        }
        else
        {
            Destroy(instancia.gameObject, 0.5f);
            Destroy(gameObject);
            
        }
    }

    IEnumerator Explosion()
    {
        audioSource.PlayOneShot(explosion1);
        

        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }

    void Update()
    {
        //CalcNoise();
    }
}
