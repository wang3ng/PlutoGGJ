using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 StartPostion;
    public float PlayerSpeed;
    public LinkedList<GameObject> satellites;
    private float MoveX;
    private Rigidbody2D rd;
    // Use this for initialization
    void Start()
    {
        satellites = new LinkedList<GameObject>();
        transform.position = Vector3.MoveTowards(transform.position, StartPostion, 10000);
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerposition = transform.position;
        //float MoveX = 0;
        //float MoveY = 0;
        //if (Input.GetKey(KeyCode.W))
        //{
        //    MoveY += Time.deltaTime * PlayerSpeed;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    MoveY -= Time.deltaTime * PlayerSpeed;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    MoveX -= Time.deltaTime * PlayerSpeed;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    MoveX += Time.deltaTime * PlayerSpeed;
        //}
        //if (playerposition.x + MoveX <= -8 || playerposition.x + MoveX >= 8.5) MoveX = 0;
        //if (playerposition.y + MoveY <= -4.5 || playerposition.y + MoveY >= 3) MoveY = 0;
        //transform.Translate(MoveX, MoveY, 0);
        MoveX = Input.GetAxis("Horizontal");
        float MoveY = Input.GetAxis("Vertical");
        Vector2 movingVector = new Vector2(MoveX,MoveY);
        rd.AddForce(movingVector * PlayerSpeed*Time.deltaTime);
    }

    public LinkedListNode<GameObject> addSatellite(GameObject a)
    {
        if (satellites.Last != null) { 
            satellites.Last.Value.GetComponent<Pilot>().active = false; 
            satellites.Last.Value.GetComponent<SpriteRenderer>().color = Color.black;
        }
        satellites.AddLast(a);
        satellites.Last.Value.GetComponent<Pilot>().active = true;
        satellites.Last.Value.GetComponent<SpriteRenderer>().color = Color.red;
        return satellites.Last;
    }

    public void followingAttract(LinkedListNode<GameObject> a)
    {
        Vector2 postion = a.Value.GetComponent<Transform>().position;
        GameObject b = a.Next.Value;
        Vector2 bposition = b.GetComponent<Transform>().position;
        Vector2 move = new Vector2(postion.x - bposition.x, postion.y - bposition.y);
        b.GetComponent<Rigidbody2D>().AddForce(move*Time.deltaTime);
    }
    public void removeNode(LinkedListNode<GameObject> a)
    {
        if (a.Value.GetComponent<Pilot>().active)
        {
            satellites.Remove(a);
            satellites.Last.Value.GetComponent<Pilot>().active = true;
            satellites.Last.Value.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else satellites.Remove(a);
    }
}
