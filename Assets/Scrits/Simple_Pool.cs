using UnityEngine;

public class Simple_Pool : MonoBehaviour
{
    private Transform pool_parent;
    private int current_pool_element_ID = 0;
    public GameObject prefab;
    public int pool_count = 10;
    public Transform cam;
    private GameObject[] pool_AR;
    private RaycastHit hit;
    private void Start()
    {
        pool_parent = transform;

        pool_AR = new GameObject[pool_count];
        for (int i = 0; i < pool_count; i++)
        {
            pool_AR[i] = Instantiate(prefab, transform.position, transform.rotation, pool_parent);
            pool_AR[i].SetActive(false);
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, 200))
            {
                GameObject obj = pool_parent.GetChild(current_pool_element_ID).gameObject;
                obj.SetActive(true);
                obj.transform.position = hit.point + hit.normal * 0.01f;
                obj.transform.rotation = Quaternion.Euler(-90, 0, 0);
                obj.transform.rotation = Quaternion.FromToRotation(obj.transform.up, hit.normal);
                current_pool_element_ID++;
                if (current_pool_element_ID > pool_parent.childCount - 1) current_pool_element_ID = 0;
            }
        }
    }
}
