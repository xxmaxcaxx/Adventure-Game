using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject spell1;
    private Animator anim;
    public int life = 2;
    public bool isCreated = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
        {
            float distance = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);
            if (distance < 5f)
            {
                transform.LookAt(GameObject.Find("Player").gameObject.transform);
                if (!isCreated)
                {
                    RaycastHit hit;
                    float maxDistance = 300f;
                    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
                    {
                        maxDistance = hit.distance;
                    }
                    anim.Play("attack01");
                    GameObject obj = Instantiate(spell1, transform.position + new Vector3(0, 0.5f, 0f) + (-transform.right * 0.3f) + (transform.forward * 0.4f), Quaternion.identity);
                    obj.GetComponent<Spell1Enemy>().direction = transform.forward;
                    obj.GetComponent<Spell1Enemy>().maxDistance = maxDistance;
                    obj.GetComponent<Spell1Enemy>().initialPosition = obj.transform.position;
                    Destroy(obj, 3f);
                    isCreated = true;
                    StartCoroutine(AttackDelay());
                    //anim.Play("walk");
                    //transform.position += transform.forward * 0.3f * Time.deltaTime;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "spell1" || col.gameObject.tag == "spell2")
        {
            anim.Play("GetHit");
            life--;

            if (life <= 0)
            {
                anim.Play("die");
                isCreated = true;
                StartCoroutine(ExampleCoroutine());
            }
        }
    }

    IEnumerator AttackDelay()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(3);
            isCreated = false;
    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
