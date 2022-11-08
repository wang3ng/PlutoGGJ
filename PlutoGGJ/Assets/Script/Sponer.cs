using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponer : MonoBehaviour
{
    public GameObject satellites;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 location;
        for (int i = 0; i<= 100; i++)
        {
            location = new Vector2(Random.Range(-10, 11), Random.Range(-10, 11));
            Instantiate(satellites, location, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
