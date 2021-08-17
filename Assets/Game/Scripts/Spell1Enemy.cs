using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell1Enemy : MonoBehaviour
{

    public Vector3 direction;
    public Vector3 initialPosition;
    public float maxDistance = 0;
    public float spd = 0.03f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * spd;
        if (Vector3.Distance(transform.position, initialPosition) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
    }
}
