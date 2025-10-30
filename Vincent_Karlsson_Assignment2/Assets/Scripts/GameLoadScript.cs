using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoadScript : MonoBehaviour
{
    public string sceneOne;
    public bool player1Ready1;
    public bool player2Ready1;

    private ObjectivesScripts objScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Vines")
        {
            SceneManager.LoadScene(sceneOne);
        }

        if (collision.gameObject.tag == "OOB")
        {
            SceneManager.LoadScene(sceneOne);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            player1Ready1 = true;
            //redundant at the moment, but here to visualize for potential later use
            if (player1Ready1 && player2Ready1 /*&& objScript.objCollect1 && objScript.objCollect2*/)
            {
                SceneManager.LoadScene(sceneOne);
            }
        }

        if (collision.CompareTag("Player2"))
        {
            player2Ready1 = true;

            if (player1Ready1 && player2Ready1 /*&& objScript.objCollect1 && objScript.objCollect2*/)
            {
                SceneManager.LoadScene(sceneOne);
            }
        }
    }
}
