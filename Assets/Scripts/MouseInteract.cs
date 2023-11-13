using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseInteract : MonoBehaviour
{
    public Rigidbody2D selectedObject;
    Vector3 offset;
    Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject && targetObject.gameObject.CompareTag("MoveableItem"))
            {
                selectedObject = targetObject.gameObject.GetComponent<Rigidbody2D>();
                offset = selectedObject.transform.position - mousePosition;
            }
            else if (targetObject && !targetObject.gameObject.CompareTag("MoveableItem"))
            {
                if (targetObject.CompareTag("ToCandyBowl"))
                {
                    SceneManager.LoadScene("CandyBowlScene");

                }
                if (targetObject.CompareTag("ToBookshelf"))
                {
                    SceneManager.LoadScene("Bookshelf");
                }
                if (targetObject.CompareTag("ToBulletinBoard"))
                {
                    SceneManager.LoadScene("BulletinBoard 1");
                }
                if (targetObject.CompareTag("Candy"))
                {
                    Vector3 rotationToAdd = new Vector3(0, 0, 30);
                    targetObject.transform.Rotate(rotationToAdd);
                }
                if (targetObject.CompareTag("Book"))
                {
                    Vector3 rotationToAdd = new Vector3(0, 0, 180);
                    targetObject.transform.Rotate(rotationToAdd);
                }
            }

        }
        
        if (Input.GetMouseButtonUp(0) && selectedObject && selectedObject.gameObject.CompareTag("MoveableItem"))
        {
            Vector3 startPos = selectedObject.transform.GetComponent<ItemManager>().originalPosition();
            Vector3 startScale = selectedObject.transform.GetComponent<ItemManager>().originalScale();
            selectedObject.transform.localScale = startScale;
            selectedObject.MovePosition(startPos);

            selectedObject = null;
        }
        
    }

    private void FixedUpdate()
    {
        if (selectedObject && selectedObject.gameObject.CompareTag("MoveableItem"))
        {
            selectedObject.MovePosition(mousePosition + offset);
            float scale = selectedObject.transform.GetComponent<ItemManager>().biggerScale();
            selectedObject.transform.localScale = new Vector3(scale, scale, scale);


        }
    }

   
}
