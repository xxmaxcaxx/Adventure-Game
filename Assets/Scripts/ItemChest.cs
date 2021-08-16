using UnityEngine;

public class ItemChest : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Item item2;
    [SerializeField] Inventory inventory;
    [SerializeField] GameObject planeItem1;
    [SerializeField] GameObject planeItem2;
    [SerializeField] GameObject planeItem3;
    [SerializeField] GameObject Empty;

    private bool isInRange;

    private void Start()
    {
        planeItem1.SetActive(false);
        planeItem2.SetActive(false);
        planeItem3.SetActive(false);
        Empty.SetActive(false);
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (item != null)
            {
                inventory.AddItem(item);
                inventory.AddItem(item);
                inventory.AddItem(item2);
                planeItem1.SetActive(false);
                planeItem2.SetActive(false);
                planeItem3.SetActive(false);
                Empty.SetActive(true);
                item = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
        if (item == null)
        {
            Empty.SetActive(true);
        }
        else
        {
            planeItem1.SetActive(true);
            planeItem2.SetActive(true);
            planeItem3.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
        Empty.SetActive(false);
        planeItem1.SetActive(false);
        planeItem2.SetActive(false);
        planeItem3.SetActive(false);
    }
}
