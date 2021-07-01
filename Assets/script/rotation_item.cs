using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class rotation_item : MonoBehaviour
{
    public GameObject prefab_jump_item; // 아이템
    private int numberOfItem = 10; //아이템 수
    public float radius = 5.0f;
    private float top_length = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "stage_1")
        {
            numberOfItem = 10;
            top_length = 20.0f;
        }
        if (SceneManager.GetActiveScene().name == "stage_2")
        {
            numberOfItem = 10;
            top_length = 40.0f;
        }
        if (SceneManager.GetActiveScene().name == "stage_3")
        {
            numberOfItem = 10;
            top_length = 60.0f;
        }
        if (SceneManager.GetActiveScene().name == "last_stage")
        {
            numberOfItem = 5;
            top_length = 100.0f;
        }
        for (int i = 0; i < numberOfItem; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfItem;
            float temp_x = (Mathf.Cos(angle) * radius) + 4;
            float temp_y = Random.Range(2.0f, top_length);
            float temp_z = (Mathf.Sin(angle) * radius) + 4;
            Vector3 pos = new Vector3(temp_x, temp_y, temp_z);
            GameObject go = Instantiate(prefab_jump_item, pos, Quaternion.identity) as GameObject;
            go.transform.parent = GameObject.Find("top").transform;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
