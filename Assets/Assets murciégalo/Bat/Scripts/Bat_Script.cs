using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Script : MonoBehaviour
{

    public float visionRadius;
    public float speed;
    private Animator anim;
    public AudioClip SqueakSound;


    GameObject player;
    Vector3 initialPosition;
    private AudioSource audioBat_Enemy;

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
        anim = GetComponent<Animator>();
        audioBat_Enemy = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 target = initialPosition;
        float distancia = Vector3.Distance(player.transform.position, transform.position);
        if (distancia < visionRadius)
        {
            target = player.transform.position;
            audioBat_Enemy.clip = SqueakSound;
            audioBat_Enemy.Play();
        }
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        anim.SetFloat("distancia", distancia);
        Debug.Log(distancia);
    }



}
