using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] Animator animator; //Cylinder or base
    [SerializeField] string tagCheck;
    [SerializeField] string animTrigger;
    [SerializeField] string animBool;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tagCheck) && !animator.GetBool(animBool))
        { 
            //is specified object
            animator.SetTrigger(animTrigger);
            animator.SetBool(animBool, true);
        }
    }
}
