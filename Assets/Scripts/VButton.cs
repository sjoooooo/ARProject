using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VButton : MonoBehaviour
{
    public GameObject vbBtnObj;
    public GameObject Dragon;
    // Start is called before the first frame update
    void Start()
    {
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Dragon.GetComponent<Animator>().SetBool("isAttack", true);
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Dragon.GetComponent<Animator>().SetBool("isAttack", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
