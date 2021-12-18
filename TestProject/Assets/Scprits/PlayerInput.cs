using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    
    public float HorizontalAxis { get; private set; }
    public float VerticlAxis { get; private set; }
    
    public float HorizontalAxisRaw { get; private set;}
    
    public bool SpacePressed { get; private set;}
    
    void Update()
    {
        HorizontalAxis = joystick.Horizontal;
        HorizontalAxisRaw = joystick.Horizontal;

        VerticlAxis = joystick.Vertical;

        SpacePressed = Input.GetKeyDown(KeyCode.Space);
    }
}
