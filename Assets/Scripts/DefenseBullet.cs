using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBullet : MonoBehaviour
{
    public bool hasBullet;
    public GameObject defenseBullet;
    [SerializeField] private AudioClip fireSound, getPowerup;
    private AudioSource _audioSource;

    public bool testFire;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0 && hasBullet) || testFire)
        {
            hasBullet = false;
            Instantiate(defenseBullet, transform.position, Quaternion.identity);
            _audioSource.clip = fireSound;
            _audioSource.Play();
            PowerupHUD.CurrentState.spriteEnable = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("powerUp"))
        {
            Destroy(other.gameObject);
            hasBullet = true;
            _audioSource.clip = getPowerup;
                _audioSource.Play();
                PowerupHUD.CurrentState.spriteEnable = true;
        }
    }
}
