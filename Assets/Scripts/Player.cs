using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private float JumpPower = 10f;
    private bool OnGround;
    

    Rigidbody player;
    void Start()
    {
        player = GetComponent<Rigidbody>();
        OnGround = true;
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.velocity = new Vector3(0f, JumpPower, 0f);
            OnGround = false;
            thisAnimation.Play();
        }
        
            
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Obstacle(Clone)")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");

           
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");

    }
}
