using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    Vector2 direction;
    bool facingright = true;
    public Rigidbody player;
    public Animator playeranim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        direction.x = horz * speed;
        direction.y = vert * speed;

        if (facingright && horz < 0)
        {
            flip();
        }
        if (!facingright && horz > 0)
        {
            flip();
        }

        playeranim.SetFloat("speed", Mathf.Abs(horz) + Mathf.Abs(vert));
    }

    void fixedUpdate() {
        player.linearVelocity = direction;
    }
    void flip()
    {
        Vector3 curr = transform.localScale;
        curr.x *= - -1;
        transform.localScale = curr;
        facingright = false;
    }
}
