using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private BoxCollider _boxCollider;
    private AudioSource _audioSource;
    private MeshFilter _meshFilter;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _audioSource = GetComponent<AudioSource>();
        _meshFilter = transform.GetChild(0).GetComponent<MeshFilter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ouch"))
        {
            Destroy(other.gameObject);
            StartCoroutine(DestructionProcess());
        }
    }
    IEnumerator DestructionProcess()
    {
        _boxCollider.enabled = false;
        _meshFilter.mesh = null;
        _audioSource.Play();
        yield return new WaitForSecondsRealtime(3f);   
        Destroy(gameObject);
    }
}
