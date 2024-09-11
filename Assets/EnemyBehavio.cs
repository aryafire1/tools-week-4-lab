using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavio : MonoBehaviour
{

    public GameObject player;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
    speed = speed * 10;

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(player.transform.position, Vector3.up, speed * Time.deltaTime);
    }


}
