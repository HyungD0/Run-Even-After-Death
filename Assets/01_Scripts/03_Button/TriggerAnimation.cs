using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{

    [Header("재생할 애니메이션")]
    [SerializeField]
    private Animator animator;

    [SerializeField] private GameObject _initWall;


    private void OnCollisionEnter2D(Collision2D collision)
    {
            if (animator == null) return;
            animator.SetTrigger("OnBtn");
            _initWall.SetActive(false);
    }
    
}
