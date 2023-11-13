using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject targetItem;
    bool mouseButtonUp;
    bool hasContact;
    public float rotationZ = 1;
    bool notPlaced;

    private void Start()
    {
        notPlaced = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == targetItem)
        {
            hasContact = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == targetItem)
        {
            hasContact = false;
        }
    }

    void Update()
    {
        mouseButtonUp = Input.GetMouseButtonUp(0);
        if (mouseButtonUp && hasContact && notPlaced)
        {
            if (rotationZ != 1)
            {
                targetItem.transform.GetComponent<ItemManager>().enterTarget(this.transform.position, new Vector3(0, 0, rotationZ));

            }else
            {
                targetItem.transform.GetComponent<ItemManager>().enterTarget(this.transform.position);
            }
            notPlaced = false;
            
        }
    }
    
   
}
