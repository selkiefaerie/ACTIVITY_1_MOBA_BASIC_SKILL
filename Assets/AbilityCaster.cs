using UnityEngine;

public class AbilityCaster : MonoBehaviour
{
    public GameObject bombPrefab;
    public float castRange = 15f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryCastAbility();
        }
    }

    void TryCastAbility()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                if (hit.transform.GetComponentInChildren<ExplosiveCharge>() != null)
                {
                    Debug.Log("Target already has a bomb!");
                    return;
                }

                float distance = Vector3.Distance(transform.position, hit.transform.position);
                if (distance <= castRange)
                {
                    PlantBomb(hit.transform);
                }
            }
        }
    }

    void PlantBomb(Transform target)
    {
        GameObject newBomb = Instantiate(bombPrefab, target.position, Quaternion.identity);
        newBomb.transform.SetParent(target);
    }
}