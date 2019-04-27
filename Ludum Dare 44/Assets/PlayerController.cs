using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    Rigidbody rb;
    public float speed;

    public GameObject projectile;
    public GameObject projectileParent;

  
    private void Start() {
        rb = GetComponent<Rigidbody>();
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
        Debug.Log("shot");
        Instantiate(projectile, gameObject.transform.GetChild(0).transform.position, transform.rotation, projectileParent.transform);

       
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

}