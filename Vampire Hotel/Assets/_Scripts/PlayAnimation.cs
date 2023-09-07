using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public bool isPlayerWalkAnim = false;
    public bool isFall_Flat = false;
    public bool isZombie_Neck_bite = false;

    public GameManager gm;

    public void SetWalking(bool onOff)
    {
        animator.SetBool("PlayerWalkAnim", onOff);
    }
    public void SetBiting()
    {
        animator.SetTrigger("BiteMyAss"); ;
    } 
    public void SetFallFlat()
    {
        animator.SetTrigger("IDieded");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {            
            //isPlayerWalkAnim = false;
            //isZombie_Neck_bite = true;
            //SetWalking();
            SetBiting();
            Debug.Log(isZombie_Neck_bite);
           
            StartCoroutine(ResetPlayerWalkAnim());
        }
    }

    IEnumerator ResetPlayerWalkAnim()
    {       
        yield return new WaitForSeconds(1f);

        //isZombie_Neck_bite = false;
       // isPlayerWalkAnim = true;
        //SetBiting();
        //SetWalking(true);
    }

    public void Fall_Flat()
    {
        if (gm.health <= 0)
        {
            SetFallFlat();
            Application.Quit();
        }
    }

    private void Update()
    {        
        
    }
}




