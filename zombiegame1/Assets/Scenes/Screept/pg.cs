
using UnityEngine;

public class pg : MonoBehaviour
{
    public float spead = 20f;
    private Rigidbody2D rb;
    public float speed =10;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

   
    void Update()
    {
        float moveY = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + Vector2.up *moveY * speed * Time.deltaTime);
        
    }
}
