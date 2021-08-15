using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    public GameObject spell1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            float maxDistance = 300f;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                maxDistance = hit.distance;
            }
            GameObject obj = Instantiate(spell1, transform.position + new Vector3(0, 0.5f, 0f) + (transform.right * 0.3f) + (transform.forward * 0.4f), Quaternion.identity);
            obj.GetComponent<Spell1Move>().direction = transform.forward;
            obj.GetComponent<Spell1Move>().maxDistance = maxDistance;
            obj.GetComponent<Spell1Move>().initialPosition = obj.transform.position;
            Destroy(obj, 3f);
        }

        if (Input.GetMouseButton(1))
        {
            
        }
    }
}
