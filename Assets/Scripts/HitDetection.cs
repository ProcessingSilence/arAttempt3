﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    private AudioSource _audioSource;

    public int health;

    private bool playOnce;
    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && playOnce == false)
        {
            playOnce = true;
            _audioSource.pitch = 0.5f;
            _audioSource.Play();
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ouch"))
        {
            Destroy(other.gameObject);
            _audioSource.Play();
            health -= 1;
        }
    }
}
