using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public int damage = 100;

    public float explosionRadius = 0;

    public void Seek(Transform _target)
    {
        target = _target;
        // Debug.Log("Targrt Transform" + target);
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        // Debug.Log("Hit Object");
        Destroy(effect, 4f);

        //Debug.Log("ExplosionRadius " + explosionRadius);

        if (explosionRadius > 0f)
        {
            // Debug.Log("ExplosionRadius " + explosionRadius);
            Explode();
        }
        else
        {
            //Debug.Log(target.position.x);
            // Debug.Log("DAmage Calling ............................!");
            Damage(target);
        }
        /*Destroy(target.gameObject);*/
        Destroy(gameObject);
    }

    private void Explode()
    {
        // Debug.Log("Explode Enter ..................");
        Collider[] collliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in collliders)
        {
            // Debug.Log("Deteact emeny" + collider.name.ToString());

            if (collider.CompareTag("Enemy"))
            {
                //  Debug.Log("DAmage Calling ............................!");
                Damage(collider.transform);

                // Debug.Log("Collider.object delete " + collider.tag.ToString());
            }
        }
    }

    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponentInParent<Enemy>();

        Debug.Log("DAmage Enter ............................!" + e.health.ToString());

        if (e != null)
        {
            //Debug.Log("DAmage  Update in data ............................!");
            e.TakeDamage(damage);
        }

        // Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
