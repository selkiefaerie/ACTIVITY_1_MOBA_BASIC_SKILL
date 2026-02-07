using UnityEngine;

public class ExplosiveCharge : MonoBehaviour
{
    public float timer = 4f;
    public float explosionRadius = 5f;
    
    [Header("Visual Settings")]
    public float startScale = 0.3f;
    public float endScale = 1.0f;
    public float yOffset = 0.8f;
    public float floatSpeed = 3.0f;
    public float floatStrength = 0.15f;
    
    private float totalDuration;

    void Start()
    {
        totalDuration = timer; 
        transform.localScale = Vector3.one * startScale;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        float progress = 1f - (timer / totalDuration);
        float currentScale = Mathf.Lerp(startScale, endScale, progress);
        float bob = Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        
        transform.localPosition = new Vector3(0, yOffset + bob, 0);

        float pulse = Mathf.Sin(Time.time * (progress * 15f)) * (progress * 0.05f);
        transform.localScale = Vector3.one * (currentScale + pulse);

        if (timer <= 0)
        {
            Explode();
        }
    }

    void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var hit in hitColliders)
        {
            if (hit.CompareTag("Enemy"))
            {
                Destroy(hit.gameObject);
            }
        }
        Destroy(gameObject); 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, explosionRadius);
    }
}