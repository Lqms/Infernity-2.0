using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _blockKey = KeyCode.Space;
    [SerializeField] private KeyCode _interactKey = KeyCode.E;
    [SerializeField] private KeyCode _castSpellKey = KeyCode.R;

    public static event UnityAction RightMouseButtonClicked;
    public static event UnityAction LeftMouseButtonClicked;
    public static event UnityAction InteractKeyPressed;
    public static event UnityAction CastSpellKeyPressed;
    public static event UnityAction<KeyCode> BlockKeyPressed;

    private void Update()
    {
        if (Input.GetMouseButton(0))
            LeftMouseButtonClicked?.Invoke();

        if (Input.GetMouseButton(1))
            RightMouseButtonClicked?.Invoke();

        if (Input.GetKeyDown(_blockKey))
            BlockKeyPressed?.Invoke(_blockKey);

        if (Input.GetKeyDown(_interactKey))
            InteractKeyPressed?.Invoke();

        if (Input.GetKeyDown(_castSpellKey))
            CastSpellKeyPressed?.Invoke();
    }
}
