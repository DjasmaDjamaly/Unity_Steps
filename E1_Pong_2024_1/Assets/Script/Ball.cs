using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float speed = 10;
    public TMP_Text pointsLeft;
    public TMP_Text pointsRight;
    public Camera mainCam;
    public GameObject power;


    int PlayerA_points=0;
    int PlayerB_points=0;
    // Start is called before the first frame update
    void Start()
    {
       if ((PlayerA_points>=3)||(PlayerB_points>=3))
       {
           SceneManager.LoadScene(2);
       }
       float x = Random.Range(0,2)  == 0 ? -1:1;
       /*
       float x = Random.Range(0,2);
       if(x == 0)
       {
        x = -1;
        }else
        {
            x = 1;
        }   
       */
       float y = Random.Range(0,2) == 0?-1:1;
       GetComponent<Rigidbody>().velocity = new Vector2(speed*x,speed*y);
       pointsLeft.SetText(PlayerA_points.ToString());
       pointsRight.SetText(PlayerB_points.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
        
    void OnCollisionEnter(Collision hit)
    {
        GetComponent<AudioSource>().Play();
       
        if(hit.gameObject.name== "Left")
        {
            transform.position = new Vector3(0,3,0);
            PlayerB_points++;
            Start();
        } else if(hit.gameObject.name== "Right")
        {
            transform.position = new Vector3(0,3,0);
            PlayerA_points++;
            Start();
        } else if(hit.gameObject.name== "PowerUp")
        {
            mainCam.fieldOfView = 147;
            Destroy(power);
        }

    }
    void OnTriggerEnter(Collider touch)
    {
        if(touch.gameObject.name=="PowerUp2")
        {
            mainCam.fieldOfView = 60;
            Destroy(touch.gameObject);
        }
    }
}
