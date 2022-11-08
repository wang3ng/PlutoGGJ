using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 StartPostion;
    public float PlayerSpeed;
    private float MoveX;
    private Rigidbody2D rd;
    // Use this for initialization
    void Start()
    {
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
}
