using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    Rigidbody rb;
    public float speed;
    public float speedMultiplier = 1.05f;

    public float scaleModifier = 1.1f;

    public float minSize = 0.28f;
    public float maxSize = 0.8f;

    public GameObject projectile;
    public GameObject projectileParent;

    public AudioClip popsound;
    public AudioClip healsound;
    public AudioClip shootsound;
    public AudioClip errorsound;

    AudioSource ads;

  
    private void Start() {
        rb = GetComponent<Rigidbody>();
        ads = Camera.main.GetComponent<AudioSource>();
    }

    void Update() {

        

        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    void FixedUpdate() {
        Move();
        RotatePlayerToMouse();
    }



    public void Shoot() {
        if (transform.localScale.x > minSize)
        {
            ads.PlayOneShot(shootsound);
        gameObject.transform.localScale /= scaleModifier;
        speed *= speedMultiplier;
        GameObject projectileobject = Instantiate(projectile, gameObject.transform.GetChild(0).transform.position, transform.rotation, projectileParent.transform);
        projectileobject.transform.localScale = new Vector3(transform.localScale.x * projectileobject.transform.localScale.x, transform.localScale.y * projectileobject.transform.localScale.y, transform.localScale.z * projectileobject.transform.localScale.z) ;
        } else
        {
            
            ads.PlayOneShot(errorsound, 0.25f);
          
        }

       
    }

    public void Move() {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal"), 0f,  Input.GetAxis("Vertical")) * speed;
    }

    public void RotatePlayerToMouse() {

        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);


        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle - 90, 0f));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    public void Heal() {
        if(gameObject.transform.localScale.x < maxSize)
        {
            speed /= scaleModifier;
            transform.localScale *= scaleModifier;
            ads.PlayOneShot(healsound);

        } else
        {
            ads.PlayOneShot(errorsound);
        }
    }

    public void KillEnemy() {
        ads.PlayOneShot(popsound);
    }

}