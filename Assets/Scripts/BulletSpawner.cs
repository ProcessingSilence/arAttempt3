using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private Vector2 spawnRangeX, spawnRangeY;
    
    [SerializeField]
    private GameObject bullet;

    [SerializeField] private Vector2 spawnTimingRange;

    [SerializeField] private float spawnOffset;

    [SerializeField] private Vector3 bulletRotation;

    [SerializeField] private Vector2 scaleRange;
    public static class CenterPoint
    {
        public static Vector3 position;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRate());
        CenterPoint.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRate()
    {   
        GameObject currentBullet =
        Instantiate(bullet, new Vector3(
            Random.Range(spawnRangeX.x, spawnRangeX.y) + transform.position.x, 
            Random.Range(spawnRangeY.x, spawnRangeY.y) + transform.position.y, 
            spawnOffset + transform.position.z), 
            Quaternion.Euler(bulletRotation));

        currentBullet.transform.localScale *= Random.Range(scaleRange.x, scaleRange.y);
        var bulletTrail = currentBullet.GetComponent<TrailRenderer>();
        bulletTrail.endWidth = bulletTrail.startWidth =
            currentBullet.transform.localScale.x;
        yield return new WaitForSecondsRealtime(Random.Range(spawnTimingRange.x, spawnTimingRange.y));
        StartCoroutine(SpawnRate());
    }
}
