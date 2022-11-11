using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : MonoBehaviour
{
    private GameObject owner = null;
    private Player player;
    private LinkedListNode<GameObject> node;
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
            
            if (owner != null) player.removeNode(node);
            else Camera.GetComponent<Sponer>().generateSatellites();
            Object.Destroy(this.gameObject);
        }
        else if (owner != null)
        {
            float moveX = owner.transform.position.x - transform.position.x;
            float moveY = owner.transform.position.y - transform.position.y;
            Vector2 force = new Vector2(moveX / Mathf.Abs(moveX) * (20 + 20 * Mathf.Log(Mathf.Abs(moveX))),
                moveY / Mathf.Abs(moveY) * (20 + 20 * Mathf.Log(Mathf.Abs(moveY))));
            rd.AddForce(force*Time.deltaTime);
            if (node.Next != null)
            {
                player.followingAttract(node);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(owner == null)
        {
            if (collision.gameObject.tag == "Player")
            {
                owner = collision.gameObject;
                player = owner.GetComponent<Player>();
                node = player.addSatellite(this.gameObject);                
                Camera.GetComponent<Sponer>().generateSatellites();
                this.GetComponent<SpriteRenderer>().color = Color.black;
            }
            else
            {
                owner = collision.gameObject.GetComponent<Satellite>().owner;
                if (owner != null)
                {
                    player = owner.GetComponent<Player>();
                    node = player.addSatellite(this.gameObject);
                    Camera.GetComponent<Sponer>().generateSatellites();
                    this.GetComponent<SpriteRenderer>().color = Color.black;
                }
                
            }
        }
    }
}
