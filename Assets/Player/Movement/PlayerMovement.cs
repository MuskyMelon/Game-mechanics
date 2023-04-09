using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;

    private Rigidbody rb;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
            return;

        Vector3 input = Vector3.zero;

        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        input = input.normalized;

        Vector3 velocity = input * speed;

        rb.velocity = velocity;

        if (Input.GetKeyDown(KeyCode.Space) && canDash == true)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        if (rb.velocity.x == 0 && rb.velocity.z == 0)
            yield break;

        canDash = false;
        isDashing = true;
        rb.velocity = rb.velocity.normalized * dashingPower;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        
    }
}
