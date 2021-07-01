using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_ctr : MonoBehaviour
{
    private GameObject player = null;
    private Vector3 position_offset = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        position_offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 new_position = transform.position;
        new_position.y = player.transform.position.y + position_offset.y;
        transform.position = new_position;
    }
}
