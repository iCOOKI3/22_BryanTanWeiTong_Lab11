using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator PlayerAnim;
    public GameObject heathText;

    float speed = 5.0f;
    float damageRate = 25f;
    float health = 100f;
    bool death = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (death == false)
        {
            //Moving Foward
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                PlayerAnim.SetBool("isStrafe", true);

            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                PlayerAnim.SetBool("isStrafe", false);
            }

            //Moving Left
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 270, 0);
                PlayerAnim.SetBool("isStrafe", true);

            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                PlayerAnim.SetBool("isStrafe", false);
            }

            //Moving Right
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                PlayerAnim.SetBool("isStrafe", true);

            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                PlayerAnim.SetBool("isStrafe", false);
            }

            //Moving Backwards
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                PlayerAnim.SetBool("isStrafe", true);

            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                PlayerAnim.SetBool("isStrafe", false);
            }

            //Attack Input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayerAnim.SetTrigger("trigAttack");
            }
        }
    }

    //Collision with Fire 
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Fire")
        {
            health -= damageRate * Time.deltaTime;
            heathText.GetComponent<Text>().text = "Health: " + health;
        }

        if(health <= 0)
        {
            PlayerAnim.SetTrigger("trigDeath");
            heathText.GetComponent<Text>().text = "Health: 0" ;
            death = true;
        }
    }
}
