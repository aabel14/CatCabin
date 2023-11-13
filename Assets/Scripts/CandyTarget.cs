using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CandyTarget : MonoBehaviour
{
    public GameObject[] targetItems;
    bool mouseButtonUp;
    bool hasContact;
    GameObject targetItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collision detected");
        foreach(GameObject item in targetItems)
        {
            if (item == collision.gameObject)
            {
                hasContact = true;
                targetItem = item;
                return;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (GameObject item in targetItems)
        {
            if (item == collision.gameObject)
            {
                hasContact = false;
                targetItem = null;
                return;
            }
        }
    }


    void Update()
    {
        mouseButtonUp = Input.GetMouseButtonUp(0);
        if (mouseButtonUp && hasContact)
        {
            targetItem.transform.GetComponent<ItemManager>().enterTarget(targetItem.transform.position);
        }
    }
}
