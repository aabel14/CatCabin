using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    Vector3 startPos;
    Vector3 startScale;
    public string staticTag = "StaticItem";
    public GameObject outline;
    public float staticScale = 1;
    public GameObject attatchedTarget;
    public bool isPolaroid = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        startScale = this.transform.localScale;
        if (attatchedTarget)
        {
            attatchedTarget.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void enterTarget(Vector3 newPos)
    {
        if (attatchedTarget)
        {
            attatchedTarget.SetActive(true);
            this.gameObject.SetActive(false);
        }
        this.GetComponent<Rigidbody2D>().MovePosition(newPos);
        this.transform.localScale = new Vector3(staticScale, staticScale, staticScale);
        this.transform.tag = staticTag;
    }

    public void enterTarget(Vector3 newPos, Vector3 newRotation)
    {
        if (attatchedTarget)
        {
            attatchedTarget.SetActive(true);
            this.gameObject.SetActive(false);
        }
        this.GetComponent<Rigidbody2D>().MovePosition(newPos);
        this.transform.Rotate(newRotation);
        this.transform.localScale = new Vector3(staticScale, staticScale, staticScale);
        this.transform.tag = staticTag;
    }

    public Vector3 originalPosition()
    {
        return startPos;
    }

    public Vector3 originalScale()
    {
        return startScale;
    }

    public float biggerScale()
    {
        return staticScale;
    }

    public void OnMouseEnter()
    {
        if (outline != null && !this.CompareTag("MoveableItem"))
        {
            outline.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        if(outline != null && !this.CompareTag("MoveableItem"))
        {
            outline.SetActive(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(collision.collider, this.GetComponent<Collider2D>());
    }
}


