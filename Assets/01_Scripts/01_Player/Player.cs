using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject DeadPrefab;
    [SerializeField] private Transform resetPoint;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            Die();
        }
    }
    [ContextMenu("Á×À½ Å×½ºÆ®")]
    private void Die()
    {
        Instantiate(DeadPrefab, transform.position, Quaternion.identity);
        Respawn();
    }

    private void Respawn()
    {
        transform.position = resetPoint.position;
    }
}
