using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rig;
    public GameObject bullet;

    private float timer = 0f;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (transform.position.z >= -4.15) rig.velocity = new Vector3(0, 0, -Input.GetAxis("Horizontal") * 4f);
        else rig.velocity = Vector3.forward;
        if (Input.GetButtonDown("Fire") && timer >= 0.05f)
        {
            Instantiate(bullet, transform);
            timer = 0f;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
