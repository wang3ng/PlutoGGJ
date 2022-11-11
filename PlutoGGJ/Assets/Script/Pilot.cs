using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : MonoBehaviour
{
    public bool active=false;
    public Vector2 test;
    private Rigidbody2D rd;
    private void Start()
    {
        rd= GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            
            Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButton(0))
            {
                Vector2 move = new Vector2(mouse.x-transform.position.x, mouse.y-transform.position.y);
                test = move;
                rd.AddForce(move*100*Time.deltaTime);
            }
        }
        
    }
}
