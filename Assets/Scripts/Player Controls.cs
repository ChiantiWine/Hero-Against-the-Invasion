using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
   [SerializeField] InputAction movement;
   [SerializeField] InputAction fire;
   [SerializeField] GameObject[] lasers;
    [SerializeField] float controlSpeed = 30f;
    [SerializeField] float xRange = 10f;
    [SerializeField] float yRange = 10f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -15f;
    
    float xThrow, yThrow;
     void Start()
    {
        
    }
    // 유니티의 실행 순서 Awake -> OnEnable
    void OnEnable() 
    {
        movement.Enable();
        fire.Enable();   
    }

    // 유니티 실행 순서
    void OnDisable() 
    {
       movement.Disable();
       fire.Disable();    
    }

    // Update is called once per frame
    void Update()
    {
      
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        
        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
    void ProcessTranslation()
    {
        // Old
        // xThrow = Input.GetAxis("Horizontal");
        // yThrow = Input.GetAxis("Vertical");

        // new Input System
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;


        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);


        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        // Player Rig에서 Position을 움직이게 되면 World 좌표 이동(카메라가 이동됨) -> 원하는 건  Local에서 Position 이동 -> Player Ship에 Script 컴퍼트
        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if(fire.ReadValue<float>() > 0.5)
        {
            ActiveLasers();
        }
        else
        {
            DeactiveLasers();
        }
        //  if(Input.GetButton("Fire1"))
        //  {
        //
        //  }
        //  else
        //  {
        //  
        //  }
    }

    private void ActiveLasers()
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(true);
        }
    }

    void DeactiveLasers()
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(false);
        }
    }
}
