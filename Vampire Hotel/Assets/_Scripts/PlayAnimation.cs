using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public bool isPlayerWalkAnim = true;
    public bool isFall_Flat = false;
    public bool isZombie_Neck_bite = false;

    public GameManager gm;

    public void SetWalking(bool onOff)
    {
        animator.SetBool("PlayerWalkAnim", onOff);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {            
            isPlayerWalkAnim = false;
            isZombie_Neck_bite = true;
           
            StartCoroutine(ResetPlayerWalkAnim());
        }
    }

    IEnumerator ResetPlayerWalkAnim()
    {       
        yield return new WaitForSeconds(1f);

        isZombie_Neck_bite = false;
        isPlayerWalkAnim = true;        
    }

    public void Fall_Flat()
    {
        if (gm.health <= 0)
        {
            isFall_Flat = true;
            Application.Quit();
        }
    }

    private void Update()
    {        
        
    }
}




