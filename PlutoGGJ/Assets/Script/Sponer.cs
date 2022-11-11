using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponer : MonoBehaviour
{
    public GameObject satellites;
    private Vector3 cameraPosition;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        satellites.GetComponent<Satellite>().Camera = this.gameObject;
        for (int i = 0; i<= 50; i++)
        {
            startGenerateSatellites();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-10);
    }
    private void startGenerateSatellites()
    {
        cameraPosition = transform.position;
        Vector2 location;
        location = new Vector2(Random.Range(cameraPosition.x - 10, cameraPosition.x + 11),
             Random.Range(cameraPosition.y - 10, cameraPosition.y + 11));
        Instantiate(satellites, location, Quaternion.identity);
        satellites.GetComponent<Satellite>().Camera = this.gameObject;
    }

    public void generateSatellites()
    {
        cameraPosition = transform.position;
        Vector2 location;
        float a = Random.value;
        if(a < 0.25) location = new Vector2(Random.Range(cameraPosition.x + 8, cameraPosition.x + 11), 
            Random.Range(cameraPosition.y-10, cameraPosition.y+11));
        else if(a<0.5) location = new Vector2(Random.Range(cameraPosition.x - 10, cameraPosition.x + 11),
            Random.Range(cameraPosition.y - 10, cameraPosition.y - 7));
        else if (a < 0.75) location = new Vector2(Random.Range(cameraPosition.x - 10, cameraPosition.x + 11),
               Random.Range(cameraPosition.y + 6, cameraPosition.y + 11));
        else location = new Vector2(Random.Range(cameraPosition.x - 11, cameraPosition.x - 8),
               Random.Range(cameraPosition.y - 10, cameraPosition.y + 11));
        Instantiate(satellites, location, Quaternion.identity);
    }
}
