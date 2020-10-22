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
    
    [SerializeField] public float bulletSpeed;

    public int projectileCount;
    
    [SerializeField] private int projectileMilestone = 100;
    private int milestoneIteration;

    [SerializeField] private bool getTrailRenderer;
    public static class CenterPoint
    {
        public static Vector3 position;
    }

    public void Start()
    {
        milestoneIteration = projectileMilestone;
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
        currentBullet.GetComponent<Bullet>().speed = bulletSpeed;
        if (getTrailRenderer)
        {
            var bulletTrail = currentBullet.GetComponent<TrailRenderer>();
            bulletTrail.endWidth = bulletTrail.startWidth =
                currentBullet.transform.localScale.x;
        }


        yield return new WaitForSecondsRealtime(Random.Range(spawnTimingRange.x, spawnTimingRange.y));
        projectileCount++;
        if (projectileCount >= projectileMilestone)
        {
            projectileMilestone += milestoneIteration;
            spawnTimingRange /= 1.1f;
            bulletSpeed *= 1.1f;
        }

        StartCoroutine(SpawnRate());
    }
}
