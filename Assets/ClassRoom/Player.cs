using TMPro;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public bool isSecondPlayer;
    public float moveSpeed = 1;
    private Rigidbody playerRigidbody;
    private RaycastHit rayHit;
    public TextMeshProUGUI Digit;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    private string horizontal = "Horizontal";
    private string vertical = "Vertical";
    private KeyCode jumpKey = KeyCode.Space;

    protected void Start()
    {
        if (isSecondPlayer)
        {
            horizontal += "B";
            vertical += "B";
            jumpKey = KeyCode.F;
        }
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Movement inputs
        Move(moveSpeed);

    }

    public void Move(float moveSpeed)
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw(horizontal), 0, Input.GetAxisRaw(vertical));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        if (Physics.Raycast(transform.position, moveVelocity, out rayHit, 1f))
        {
            if (rayHit.collider.tag == "Wall")
            {
                return;
            }
        }
        playerRigidbody.MovePosition(playerRigidbody.position + moveVelocity * Time.fixedDeltaTime);

        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {

            playerRigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Key")
        {
            Digit.text = other.gameObject.GetComponent<Key>().value.ToString();
            //Debug.Log("Key Value = " + value);
        }
    }
    private void OnTriggerExit(Collider other)
    {
            Digit.text = "0";
    }


}

