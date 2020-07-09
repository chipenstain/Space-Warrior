using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody rig;

    public float damage = 3f;
    private float timer = 0f;
    public bool isEnemy = false;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (!isEnemy) rig.velocity = Vector3.right * 60f;
        else rig.velocity = Vector3.left * 60f;

        if (timer >= 5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemie" && !isEnemy || other.gameObject.layer == 8)
        {
            Destroy(gameObject, 0.02f);
        }
    }
}
