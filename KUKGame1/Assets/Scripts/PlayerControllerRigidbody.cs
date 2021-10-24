using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerRigidbody : MonoBehaviour
{

    public PlayGroundSceneManager manager;
    Rigidbody rb;
    public float speed = 1f;
    public float rotSpeed = 99f;
    public float jumpPower = 1.5f;
    float newRotY = 0;
    public GameObject prefabBullet;
   
    public GameObject gunPosition;
    public float gunPower = 15f;
    public float gunCooldown = 1f;
    public float gunCooldownCount = 0;
    public bool hasGun = false;
    public int bulletCount = 0;
    public int coinCount =0 ;
    public AudioSource CoinSfx;
    public AudioSource FireSfx;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(manager == null)
        {
            manager = FindObjectOfType<PlayGroundSceneManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector3(0, 0, speed),ForceMode.VelocityChange);
            newRotY = 0;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(new Vector3(0, 0, -speed), ForceMode.VelocityChange);
            newRotY = 180;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector3(speed, 0, 0), ForceMode.VelocityChange);
            newRotY = 90;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(-speed, 0, 0), ForceMode.VelocityChange);
            newRotY = -90;
        }*/

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0, jumpPower, 0, ForceMode.Impulse);
        }
        
        if (Input.GetButtonDown("Fire1") && bulletCount > 0 && (gunCooldownCount >= gunCooldown))
        {
            gunCooldownCount = 0;
            bulletCount--;
            manager.SetTextBullet(bulletCount);
            FireSfx.Play();

            GameObject bullet = Instantiate(prefabBullet,gunPosition.transform.position, gunPosition.transform.rotation);
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * gunPower, ForceMode.Impulse);
            Rigidbody bRb = bullet.GetComponent<Rigidbody>();
            bRb.AddForce(transform.forward * gunPower, ForceMode.Impulse);

            Destroy(bullet, 3f);
        }
       

        float horrizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        
        
        if(horrizontal > 0)
        {
            newRotY = 90;
        }
        else if (horrizontal < 0)
        {
            newRotY = -90;
        }
        if (vertical > 0)
        {
            newRotY = 0;
        }
        else if (vertical < 0)
        {
            newRotY = 180;
        }

        rb.AddForce(horrizontal, 0, vertical, ForceMode.VelocityChange);

        gunCooldownCount = gunCooldownCount + Time.fixedDeltaTime;


        transform.rotation = Quaternion.Lerp(
                                             Quaternion.Euler(0, newRotY, 0),
                                             transform.rotation,
                                             Time.deltaTime * rotSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Collectable")
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Collectable")
        {
            Destroy(other.gameObject);
            coinCount++;
            manager.SetTextCoin(coinCount);
            CoinSfx.Play();
        }
        if (other.gameObject.name == "GunTrigger")
        {
            hasGun = true;
            bulletCount += 10;
            Destroy(other.gameObject);
            manager.SetTextBullet(bulletCount);
        }
    }

}
