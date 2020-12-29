using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpaceShip : MonoBehaviour
{
    bool boostAvailavle=true;


    [SerializeField]UIManager uIManager;    
    [SerializeField]GameManager gameManager;    
    public Vector2 Direction;
    internal Rigidbody rb;
    [SerializeField]Camera cam;
    [SerializeField]ParticleSystem fire;
    [SerializeField]ParticleSystem boost;
    float horizontal;
    float vertical;
    internal bool isGrounded;
    [SerializeField] float liftPower, RotationMultiplayer,boostTimer;
    [SerializeField] LayerMask Ground;
    public Transform bottom;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();   
           
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Direction = new Vector2(horizontal, vertical);
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
        if (vertical > 0)
        {
            fire.Play();
        }
        else
        {
           
            fire.Stop();
        }
        UiController();


        rb.AddRelativeForce(0,vertical*liftPower, 0);
        rb.AddRelativeTorque(0,0, -horizontal*RotationMultiplayer);

        if (boostAvailavle && Input.GetKeyDown(KeyCode.Space))
        {
            boostAvailavle = false;
            StartCoroutine(AirBoost());
        }
        if (NearGroundcheck())
        {
            rb.drag = 3;
        }
        else rb.drag = 1;

        Debug.Log("!!!" + isGrounded);
    }
    IEnumerator AirBoost()
    {
        rb.AddRelativeForce(0, vertical * liftPower, 0, ForceMode.Impulse);
        boost.Play();
        yield return new WaitForSeconds(boostTimer);
        boostAvailavle = true;
    }
    public void UiController()
    {
        if (horizontal < 0)
        {
            uIManager.ButtonDown(0);
        }else uIManager.ButtonUp(0);


        if (horizontal > 0)
        {
            uIManager.ButtonDown(1);
        }else uIManager.ButtonUp(1);


        if (vertical > 0)
        {
            uIManager.ButtonDown(2);
        }else uIManager.ButtonUp(2);

        if (vertical < 0)
        {
            uIManager.ButtonDown(3);
        }else uIManager.ButtonUp(3);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log(rb.velocity.y);
            if (gameManager.crushCheck(rb.velocity.y))
            {
                gameManager.Lose();
                Debug.Log("crush");
            }
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public bool NearGroundcheck()
    {
        
        return Physics.Raycast(transform.position, Vector3.down, 2f, Ground);
    }
    public bool Groundcheck()
    {
       RaycastHit hitInfo;

        Physics.Raycast(bottom.position, Vector3.down, out hitInfo, 1, Ground);
        
        return hitInfo.distance <= 0;
    }







    // Start is called before the first frame update

}
