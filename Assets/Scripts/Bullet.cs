using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    [SerializeField]private Vector3 originPos;

    [SerializeField]
    private float allowedDist;
    // Start is called before the first frame update
    void Awake()
    {
        originPos = BulletSpawner.CenterPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, originPos) > allowedDist)
        {
            Destroy(gameObject);
        }
    }
}
