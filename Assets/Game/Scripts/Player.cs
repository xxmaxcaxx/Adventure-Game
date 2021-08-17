using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject inventoryGameObject;
    [SerializeField] GameObject PauseGameText;
    [SerializeField] GameObject InventoryText;
    [SerializeField] KeyCode[] toggleInventoryKeys;

    public float walk = 0.5f;
    public float run = 1.0f;
    public Animator anim;
    public int life;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
        PauseGameText.SetActive(!PauseGameText.activeSelf);
        InventoryText.SetActive(!InventoryText.activeSelf);

        life = GameObject.FindGameObjectsWithTag("heart").Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate camera with mouse
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * 3f);

        //Player Move forward and Animation
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("w") || Input.GetKey(KeyCode.LeftShift) && Input.GetKey("up"))
        {
            transform.position += transform.forward * run * Time.deltaTime;
            anim.Play("Run");
        }
        else if (Input.GetKey("w") || Input.GetKey("up"))
        {
            transform.position += transform.forward * walk * Time.deltaTime;
            anim.Play("Walk");
        }

        //Player Move backward and Animation
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("s") || Input.GetKey(KeyCode.LeftShift) && Input.GetKey("down"))
        {
            transform.position -= transform.forward * run * Time.deltaTime;
            anim.Play("Run");
        }
        else if (Input.GetKey("s") || Input.GetKey("down"))
        {
            transform.position -= transform.forward * walk * Time.deltaTime;
            anim.Play("Walk");
        }

        //Player Move right and Animation
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("d") || Input.GetKey(KeyCode.LeftShift) && Input.GetKey("right"))
        {
            transform.position += transform.right * run * Time.deltaTime;
            anim.Play("Run");
        }
        else if (Input.GetKey("d") || Input.GetKey("right"))
        {
            transform.position += transform.right * walk * Time.deltaTime;
            anim.Play("Walk");
        }

        //Player Move left and Animation
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey("a") || Input.GetKey(KeyCode.LeftShift) && Input.GetKey("left"))
        {
            transform.position -= transform.right * run * Time.deltaTime;
            anim.Play("Run");
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            transform.position -= transform.right * walk * Time.deltaTime;
            anim.Play("Walk");
        }

        if (Input.GetMouseButton(0))
        {
            anim.Play("Attack01");
        }
        if (Input.GetMouseButton(1))
        {
            anim.Play("Attack02");
        }

        for(int i = 0; i < toggleInventoryKeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleInventoryKeys[i]))
            {
                inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
                if (inventoryGameObject.activeSelf)
                {
                    PauseGame();
                    ShowMouseCursor();
                    PauseGameText.SetActive(true);
                    InventoryText.SetActive(true);
                }
                else
                {
                    HideMouseCursor();
                    ResumeGame();
                    PauseGameText.SetActive(false);
                    InventoryText.SetActive(false);
                }
            }
        }
    }

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == "enemy")
        {
            anim.Play("GetHit");
            Destroy(GameObject.FindGameObjectWithTag("heart"));
            life--;
            if(life <= 0)
            {
                anim.Play("Death");
                StartCoroutine(ExampleCoroutine());    
            }
        }
    }
    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        //Application.LoadLevel(Application.loadedLevel);
    }
}
