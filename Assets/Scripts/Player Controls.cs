using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
     void Start()
    {
        
    }
    // 유니티의 실행 순서 Awake -> OnEnable
    void OnEnable() 
    {
        movement.Enable();    
    }

    // 유니티 실행 순서
    void OnDisable() 
    {
        movement.Disable();    
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = movement.ReadValue<Vector2>().x;
        float verticalThrow = movement.ReadValue<Vector2>().y;
        // float horizontalThrow = Input.GetAxis("Horizontal");
        // float verticalThrow = Input.GetAxis("Vertical");
    }
}
