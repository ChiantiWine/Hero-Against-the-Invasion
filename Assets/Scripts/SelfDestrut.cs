using UnityEngine;

public class SelfDestrut : MonoBehaviour
{
    [SerializeField] float timeTillDestroy = 3f;
    void Start()
    {
        Destroy(gameObject, timeTillDestroy);
    }

}
