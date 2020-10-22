using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthState : MonoBehaviour
{
    private AudioSource _audioSource;

    public int health;

    public bool isDead;

    [SerializeField] private AudioClip ouchSound;

    [SerializeField] private Material[] matHealth;

    private MeshRenderer _meshRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && isDead == false)
        {
            isDead = true;
            
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponent<DefenseBullet>().enabled = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            
            PowerupHUD.CurrentState.spriteEnable = false;

            _audioSource.pitch = 0.5f;
            PlaySound(ouchSound);
        }

        switch (health)
        {
            case 3:
                _meshRenderer.material = matHealth[0];
                break;
            case 2:
                _meshRenderer.material = matHealth[1];
                break;
            case 1:
                _meshRenderer.material = matHealth[2];
                break;
            default:
                _meshRenderer.material = matHealth[3];
                break;               
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ouch") || other.CompareTag("ouchSmall") )
        {
            Destroy(other.gameObject);
            PlaySound(ouchSound);
            health -= 1;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
