using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private float JumpPower = 10f;
    Rigidbody player;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.velocity = new Vector3(0f, JumpPower, 0f);
            thisAnimation.Play();
        }
        
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Obstacle")
        {
            
            SceneManager.LoadScene("GameOver");
            if(Input.GetKey(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
