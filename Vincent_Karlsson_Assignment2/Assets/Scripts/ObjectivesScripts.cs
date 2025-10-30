using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesScripts : MonoBehaviour
{
    public GameObject load1;
    public GameObject load2;
    public GameObject load3;
    public GameObject load4;

    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    public GameObject obj4;
    public GameObject obj5;
    public GameObject obj6;

    public GameObject vines;
    public GameObject vines2;

    //public bool objCollect1;
    //public bool objCollect2;

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
        if (collision.gameObject.name == "Objective1")
        {
            load1.SetActive(true);
            obj1.SetActive(false);
        }

        if (collision.gameObject.name == "Objective2")
        {
            load2.SetActive(true);
            obj2.SetActive(false);
        }

        if (collision.gameObject.name == "Objective3")
        {
            vines.SetActive(false);
            obj3.SetActive(false);
        }

        if (collision.gameObject.name == "Objective4")
        {
            load3.SetActive(true);
            obj4.SetActive(false);
        }

        if (collision.gameObject.name == "Objective5")
        {
            load4.SetActive(true);
            obj5.SetActive(false);
        }

        if (collision.gameObject.name == "Objective6")
        {
            vines2.SetActive(false);
            obj6.SetActive(false);
        }
    }
}
