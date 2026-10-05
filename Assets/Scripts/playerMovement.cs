using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public float speed = 2.0f;
    Vector2 direction;
    bool facingright = true;
    public Rigidbody2D player;
    public Animator playeranim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Keyboard kb = Keyboard.current;
        if(kb == null) return;

        float horz = 0f;
        float vert = 0f;

        if(kb.dKey.isPressed) horz += 1f;
        if(kb.aKey.isPressed) horz -= 1f;
        if(kb.wKey.isPressed) vert += 1f;
        if(kb.sKey.isPressed) vert -= 1f;

        direction = new Vector2(horz, vert).normalized * speed;

        if (vert == 0) {
            if (facingright && horz < 0)  flip();
            if (!facingright && horz > 0) flip();
        }

        if (horz != 0 || vert != 0) {
            if (vert != 0) {
                playeranim.SetFloat("MoveX", 0f);
                playeranim.SetFloat("MoveY", vert);
            } else {
                playeranim.SetFloat("MoveX", 1f);
                playeranim.SetFloat("MoveY", 0f);
            }
        }

        playeranim.SetFloat("Speed", Mathf.Abs(horz) + Mathf.Abs(vert));
    }

    void FixedUpdate() {
        player.linearVelocity = direction;
    }

    void flip() {
        Vector3 curr = transform.localScale;
        curr.x *= -1;
        transform.localScale = curr;
        facingright = !facingright;
    }
}
