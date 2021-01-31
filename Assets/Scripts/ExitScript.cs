using UnityEngine;

public class ExitScript : MonoBehaviour
{
    private EscInput escInput;

    private void OnEnable()
    {
        escInput.Enable(); 
    }

    private void OnDisable()
    {
        escInput.Disable();
    }

    private void Awake()
    {
        escInput = new EscInput();
    }
    // Start is called before the first frame update
    void Start()
    {
        escInput.Esc.Newaction.performed += Newaction_performed;
    }

    private void Newaction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Application.Quit();
    }

}
