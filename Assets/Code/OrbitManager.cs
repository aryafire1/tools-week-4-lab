using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] orbitObject;
    public OrbitStats orbitStats;
    public float rotationDistance; 
    public int speed;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        player = GameObject.FindGameObjectWithTag("Player");
        orbitObject = GameObject.FindGameObjectsWithTag("Orbit");
        foreach(var orbit in orbitObject)
        {
            rotationDistance = Random.Range(2,8);
            rotationSpeed = Random.Range(5,90);
            orbitStats = orbit.GetComponent<OrbitStats>();
            orbitStats.distance = rotationDistance;
            orbitStats.speed = rotationSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        foreach(var orbit in orbitObject)
        {
            orbitStats = orbit.GetComponent<OrbitStats>();
            orbit.transform.RotateAround(player.transform.position, new Vector3(0,0,1),  orbitStats.speed* Time.deltaTime);
            orbit.transform.position = Vector3.MoveTowards(orbit.transform.position, player.transform.position, -(orbitStats.distance - Vector3.Distance(orbit.transform.position, player.transform.position)));
        }
    }

    void Movement() {
        player.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * Time.deltaTime * speed);
    }


}
