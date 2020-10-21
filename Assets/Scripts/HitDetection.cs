using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ouch"))
        {
            Destroy(other.gameObject);
            _audioSource.Play();
        }
    }
}
