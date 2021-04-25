using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCast_robot : MonoBehaviour
{
    Animator anim;
    public int r_atkPnt = 200;
    public int r_hpPnt = 1000;
    float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();   

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, forward, Color.green);

        if(Physics.Raycast(transform.position,forward,out hit))
        {
            Debug.Log("로봇이 드래곤을 겨냥함!");

            anim.SetBool("isHit", true);

            timeElapsed += Time.deltaTime;

            if (timeElapsed >= 3.0f)
            {
                hit.transform.GetComponent<rayCast_dragon>().d_hpPnt -= r_atkPnt;
                timeElapsed = 0f;
            }
        }
        else
        {
            anim.SetBool("isHit", false);
        }

        if(r_hpPnt <= 0)
        {
            anim.SetBool("isDead", true);
        }
        
    }
}
