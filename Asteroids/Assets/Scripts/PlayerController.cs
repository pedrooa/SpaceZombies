using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 8; // velocidade do jogador
    public float gravity = -9.8f; // valor da gravidade
    public LayerMask groundMask;
    CharacterController character;
    Vector3 velocity;
    bool isGrounded;
    private Animator anim;
    public AudioSource footstep;


    void Start()
    {
        character = gameObject.GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        footstep = GetComponent<AudioSource>();

    }


    void Update()
    {

        // Verifica se encostando no chão (o centro do objeto deve ser na base)
        isGrounded = Physics.CheckSphere(transform.position, 0.2f, groundMask);

        // Se no chão e descendo, resetar velocidade
        if (isGrounded && velocity.y < 0.0f)
        {
            velocity.y = -1.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        anim.SetFloat("virar", x);
        anim.SetFloat("correr", z);

        // Rotaciona personagem
        transform.Rotate(0, x * speed * 10 * Time.deltaTime, 0);

        // Move personagem
        Vector3 move = transform.forward * z;
        character.Move(move * Time.deltaTime * speed);

        // Aplica gravidade no personagem
        velocity.y += gravity * Time.deltaTime;
        character.Move(velocity * Time.deltaTime);

    }
    private void Footstep()
    {
        footstep.Play();
    }
}

