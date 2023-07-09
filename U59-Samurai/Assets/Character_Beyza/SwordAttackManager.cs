using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackManager : MonoBehaviour
{
    private Animator anim;
    private int noOfClicks;
    private bool isClickable;

    public float cooldownTime =  2f;
    private float nextFireTime = 0f;
    float lastClickedTime = 0;
    float maxComboDelay = 1;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        // noOfClicks = 0;
        // isClickable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack1")){
            anim.SetBool("Attack1", false);
        }
        if(anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack2")){
            anim.SetBool("Attack2", false);
        }
        if(anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack3")){
            anim.SetBool("Attack3", false);
            noOfClicks = 0;
        }

        if(Time.time - lastClickedTime > maxComboDelay){
            noOfClicks = 0;
        }

        if(Time.time > nextFireTime){
            if(Input.GetMouseButtonDown(0)){
                //  StartCoroutine(Attack());
                OnClick();
             }
        }
    }

    // private IEnumerator Attack(){
        
    //     anim.SetLayerWeight(anim.GetLayerIndex("AttackLayer"), 1);
    //     if(isClickable){
    //         noOfClicks++;
    //     }
    //     if(noOfClicks == 1){
    //         Debug.Log("Hello");
    //         anim.SetInteger("attack", 1);
    //     }

    //     yield return new WaitForSeconds(0.9f);
    //     CheckIsClickable();
    //     anim.SetLayerWeight(anim.GetLayerIndex("AttackLayer"), 0);
        
    //     }

    // public void CheckIsClickable(){
    //     Debug.Log("giriş");
    //     isClickable = false;

    //     if(anim.GetCurrentAnimatorStateInfo(1).IsName("Attack1") && noOfClicks == 1){
    //         Debug.Log("Attack1 den 0 a");
    //         anim.SetInteger("attack", 0);
    //         isClickable = true;
    //         noOfClicks = 0;
    //     }
    //     else if(anim.GetCurrentAnimatorStateInfo(1).IsName("Attack1") && noOfClicks == 2){
    //         Debug.Log("Attack1 den 2 ye");
    //         anim.SetInteger("attack", 2);
    //         isClickable = true;
    //     }
    //     else if(anim.GetCurrentAnimatorStateInfo(1).IsName("Attack2") && noOfClicks == 2){
    //         Debug.Log("Attack2 den 0 a");
    //         anim.SetInteger("attack", 0);
    //         isClickable = true;
    //         noOfClicks = 0;
    //     }
    //     else if(anim.GetCurrentAnimatorStateInfo(1).IsName("Attack2") && noOfClicks == 3){
    //         Debug.Log("Attack2 den 3e");
    //         anim.SetInteger("attack", 3);
    //         isClickable = true;
    //     }
    //     else if(anim.GetCurrentAnimatorStateInfo(1).IsName("Attack3")){
    //         Debug.Log("attack3 - 0 a");
    //         anim.SetInteger("attack", 0);
    //         isClickable = true;
    //         noOfClicks = 0;
    //     }
    // }

    void OnClick(){
        lastClickedTime = Time.time;
        noOfClicks += 1;
        if(noOfClicks == 1){
            anim.SetBool("Attack1", true);
            
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if(noOfClicks >= 2 && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack1")){
            anim.SetBool("Attack1", false);
            anim.SetBool("Attack2", true);
        }

        if(noOfClicks >= 3 && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.7f && anim.GetCurrentAnimatorStateInfo(1).IsName("Attack2")){
            anim.SetBool("Attack2", false);
            anim.SetBool("Attack3", true);
        }
    }
}
