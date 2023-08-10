using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwerveJoystick : MonoBehaviour
{

    private float lastPosX;
    private float moveDelta;
    public float MoveDelta => moveDelta;

    [SerializeField] private float horizontalMoveSpeed = 0.5f;
    [SerializeField] private float forwardMoveSpeed;
    [SerializeField] private float clampMin;
    [SerializeField] private float clampMax;
    public AudioSource song;
    public AudioSource kick;
    Animator animator;

    public GameObject kickcube;
    public List<Transform> transforms = new List<Transform>();
    public GameObject kickcubeparent;
    public Material skybox2;
    public Transform walls;

    private void Start()
    {

        
        animator = GetComponentInChildren<Animator>();
        //for (int i = 0; i < transforms.Count; i++) {

        //  GameObject go =  Instantiate(kickcube, transforms[i].position, Quaternion.identity);
        //    go.transform.SetParent(kickcubeparent.transform);
        //      go.transform.GetChild(0).rotation =   Quaternion.Euler(go.transform.rotation.x, go.transform.rotation.y, UnityEngine.Random.Range(-25, 25));
        //    go.transform.position =new Vector3(go.transform.position.x, 1f, go.transform.position.z);

        //   // UnityEngine.Random.Range(-25, 25)  

        //}
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(kickcube,this.transform.position,Quaternion.identity);
        }

        transform.Translate(transform.forward * (forwardMoveSpeed * Time.smoothDeltaTime), Space.World);
        if (Input.GetMouseButtonDown(0))
        {
            lastPosX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveDelta = Input.mousePosition.x - lastPosX;
            lastPosX = Input.mousePosition.x;
          //  Debug.Log(lastPosX + " " + moveDelta);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveDelta = 0f;
        }
              
          float swerveAmount = Time.smoothDeltaTime * horizontalMoveSpeed * MoveDelta;
      
               
         //   transform.Translate(swerveAmount, 0, 0);
       
          //  transform.position = new Vector3(Mathf.Clamp(transform.position.x,
         //   clampMin, clampMax), transform.position.y, transform.position.z);
           
        transform.Rotate(0,0,swerveAmount);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kick"))
        {
         

            animator.SetBool("Attack", true);
            kick.Play();
           // other.gameObject.SetActive(false);
           other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            for (int i = 0; i < other.transform.childCount; i++)
            {
                Rigidbody rb = other.transform.GetChild(i).GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.useGravity = true;
                rb.AddExplosionForce(500, other.transform.GetChild(i).position, 1, 3.0F);


            }
            Destroy(other.gameObject.transform.parent.parent.gameObject,1f);  
            Invoke("atack", 0.2f);
        }

        if (other.gameObject.CompareTag("First"))
        {
            song.Play();
            
        }

        if (other.gameObject.CompareTag("SkyBox"))
        {
           
            

        }

    }

    private void atack()
    {
        animator.SetBool("Attack", false);
    }

}