using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    private Animator anim;
    public float cooldownTime =  2f;
    private float nextFireTime = 0f;
    public static int noOfClicks = 0;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1")){
            anim.SetBool("Attack1", false);
        }
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2")){
            anim.SetBool("Attack2", false);
        }
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack3")){
            anim.SetBool("Attack3", false);
            noOfClicks = 0;
        }

        if(Time.time - lastClickedTime > maxComboDelay){
            noOfClicks = 0;
        }

        if(Time.time > nextFireTime){
            if(Input.GetMouseButtonDown(0)){
                OnClick();
            }
        }
    }

    void OnClick(){
        lastClickedTime = Time.time;
        noOfClicks += 1;
        if(noOfClicks == 1){
            anim.SetBool("Attack1", true);
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if(noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1")){
            anim.SetBool("Attack1", false);
            anim.SetBool("Attack2", true);
        }

        if(noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2")){
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack3", true);
        }

    }
}