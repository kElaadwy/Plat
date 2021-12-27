using UnityEngine;


public class Follow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;



    void Update()
    {
        transform.position = new Vector3(target.position.x + offset.x,
            target.position.y + offset.y, target.position.z + offset.z);
    }
}
