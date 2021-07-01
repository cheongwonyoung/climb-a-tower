using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class block_prefabs : MonoBehaviour
{
    public GameObject prefab_cube; // 발판
    private int numberOfObjects = 80; //발판 수
    public float radius = 5f;
    private float top_length = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "stage_1")
        {
            numberOfObjects = 30;
            top_length = 20.0f;
        }
        if (SceneManager.GetActiveScene().name == "stage_2")
        {
            numberOfObjects = 50;
            top_length = 40.0f;
        }
        if (SceneManager.GetActiveScene().name == "stage_3")
        {
            numberOfObjects = 80;
            top_length = 60.0f;
        }
        if (SceneManager.GetActiveScene().name == "last_stage")
        {
            numberOfObjects = 130;
            top_length = 100.0f;
        }
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            float temp_x = (Mathf.Cos(angle) * radius) + 4;
            float temp_y = Random.Range(2.0f, top_length);
            float temp_z = (Mathf.Sin(angle) * radius) + 4;
            Vector3 pos = new Vector3(temp_x, temp_y, temp_z);
            GameObject go = Instantiate(prefab_cube, pos, Quaternion.identity) as GameObject;
            go.transform.parent = GameObject.Find("top").transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
