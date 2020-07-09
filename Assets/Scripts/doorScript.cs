using UnityEngine;

public class doorScript : MonoBehaviour
{
    public float hp = 100f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            hp -= other.gameObject.GetComponent<BulletScript>().damage;
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if (hp <= 0f)
        {
            GameManager.GM.score += 200;
            Destroy(gameObject);
        }
    }
}
