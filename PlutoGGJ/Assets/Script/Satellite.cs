using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    private GameObject owner = null;
    private Rigidbody2D rd;
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x-Camera.transform.position.x)>20 || Mathf.Abs(transform.position.y - Camera.transform.position.y) > 20)
        {
            Camera.GetComponent<Sponer>().generateSatellites();
            Object.Destroy(this.gameObject);
        }
        else if (owner != null)
        {
            float moveX = owner.transform.position.x - transform.position.x;
            float moveY = owner.transform.position.y - transform.position.y;
            Vector2 rotation;
            if (Mathf.Abs(moveX) > Mathf.Abs(moveY)) rotation = new Vector2(0,moveY / Mathf.Abs(moveY));
            else rotation = new Vector2(moveX / Mathf.Abs(moveX),0);
            Vector2 force = new Vector2(moveX / Mathf.Abs(moveX) * (10 + 5 * Mathf.Log(Mathf.Abs(moveX))),
                moveY / Mathf.Abs(moveY) * (10 + 5 * Mathf.Log(Mathf.Abs(moveY))));
            rd.AddForce(force); 
            rd.AddForce(rotation);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(owner == null)
        {
            if (collision.gameObject.tag == "Player")
            {
                owner = collision.gameObject;
                Camera.GetComponent<Sponer>().generateSatellites();
            }
            else
            {
                owner = collision.gameObject.GetComponent<Satellite>().owner;
                Camera.GetComponent<Sponer>().generateSatellites();
            }
        }
    }
}
