using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_control : MonoBehaviour
{
    public float jump_speed = 200.0f;
    int jump_count = 0;
    float jump_time = 0.0f;
    float current_time = 0.0f;
    top_rotation tp = new top_rotation();
    private AudioSource audio_source_1;
    public AudioClip apper_sound_1;
    private AudioSource audio_source_2;
    public AudioClip apper_sound_2;
    private AudioSource audio_source_3;
    public AudioClip apper_sound_3;
 
    // Start is called before the first frame update
    void Start()
    {
        audio_source_1 = gameObject.AddComponent<AudioSource>();
        audio_source_1.clip = apper_sound_1;
        audio_source_1.loop = false;
        audio_source_2 = gameObject.AddComponent<AudioSource>();
        audio_source_2.clip = apper_sound_2;
        audio_source_2.loop = false;
        audio_source_3 = gameObject.AddComponent<AudioSource>();
        audio_source_3.clip = apper_sound_3;
        audio_source_3.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 launch_direction = new Vector3(0, 1, 0);
        jump_time += Time.deltaTime;
        current_time += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && jump_count != 3)
        {
            audio_source_1.Play();
            this.GetComponent<Rigidbody>().AddForce(launch_direction * jump_speed);
            jump_count++;
            jump_time = 0.0f;
        }
        if (jump_time > 2)
        {
            jump_count = 0;
            jump_time = 0.0f;
        }
        



        }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "jump_item")
        {
            audio_source_2.Play();
            Destroy(coll.gameObject);
            jump_speed += 5;
        }
        if (coll.gameObject.tag == "rotation_item")
        {
            audio_source_2.Play();
            Destroy(coll.gameObject);
            tp.rot_speed += 3;
        }
        

    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "goal")
        {
            audio_source_3.Play();
            Destroy(coll.gameObject);
            StartCoroutine("SceneDelay");
        }
    }
    IEnumerator SceneDelay()
    {
        yield return new WaitForSeconds(0.3f);
        if (SceneManager.GetActiveScene().name == "stage_1")
        {
            SceneManager.LoadScene("stage_2", LoadSceneMode.Single);
        }
        if (SceneManager.GetActiveScene().name == "stage_2")
        {
            SceneManager.LoadScene("stage_3", LoadSceneMode.Single);
        }
        if (SceneManager.GetActiveScene().name == "stage_3")
        {
            SceneManager.LoadScene("last_stage", LoadSceneMode.Single);
        }
        if (SceneManager.GetActiveScene().name == "last_stage")
        {
            SceneManager.LoadScene("end_page", LoadSceneMode.Single);
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(0, 320, 120, 100), "시간 = " + current_time.ToString());
        GUI.Label(new Rect(0, 305, 120, 100), "점프력 = " + jump_speed.ToString());
        GUI.Label(new Rect(0, 290, 120, 100), "타워 회전속도 = " + tp.rot_speed.ToString());
    }

    public void Reset()
    {
        if (SceneManager.GetActiveScene().name == "stage_1")
        {
            SceneManager.LoadScene("stage_1", LoadSceneMode.Single);
        }
        if (SceneManager.GetActiveScene().name == "stage_2")
        {
            SceneManager.LoadScene("stage_2", LoadSceneMode.Single);
        }
        if (SceneManager.GetActiveScene().name == "stage_3")
        {
            SceneManager.LoadScene("stage_3", LoadSceneMode.Single);
        }
        if (SceneManager.GetActiveScene().name == "last_stage")
        {
            SceneManager.LoadScene("last_stage", LoadSceneMode.Single);
        }
    }

   
}
