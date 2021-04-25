using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCast_dragon : MonoBehaviour
{
    Animator anim;
    public int d_atkPnt = 200;
    public int d_hpPnt = 1000;
    float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    public void Eyes()    {    }


    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, forward, out hit))
        {
            Debug.Log("드래곤이 로봇을 겨냥함!");
            anim.SetBool("isHit", true);

            timeElapsed += Time.deltaTime;

            if (timeElapsed >= 3.0f)
            {  
                hit.transform.GetComponent<rayCast_robot>().r_hpPnt -= d_atkPnt;
                timeElapsed = 0f;
            }
        }
        else
        {
            anim.SetBool("isHit", false);
        }

        if (d_hpPnt <= 0)
        {
            anim.SetBool("isDead", true);
        }

    }
}
