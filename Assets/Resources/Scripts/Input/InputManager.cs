using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour
{
    private enum InputChanged
    {
        None,
        Pressed,
        Released,
        ValueChanged
    }

    [SerializeField] private InputActionAsset m_inputActions;

    [SerializeField] private string m_movementActionName;

    [SerializeField] private string m_spaceActionName;

    private InputAction m_movement;

    private InputAction m_space;



    public Vector2 m_movementInput;

    private bool m_spaceInput;


    private Vector2 m_lastMovementInput;

    private bool m_lastSpaceInput;


    private InputChanged m_movementChanged;

    private InputChanged m_spaceChanged;

    private bool m_isMoving;

    private InputAction MovementAction
    {
        get
        {
            if (m_movement == null)
            {
                if (m_movement == null) m_movement = m_inputActions[m_movementActionName];
                return m_movement;
            }
            return m_movement;
        }
    }

    private InputAction SpaceAction
    {
        get
        {
            if (m_space == null)
            {
                if (m_space == null) m_space = m_inputActions[m_spaceActionName];
                return m_space;
            }
            return m_space;
        }
    }



    // MOVEMENT

    public Vector2 Movement => m_movementInput;

    public bool IsMoving => m_isMoving;

    public bool MovementPressed => m_movementChanged == InputChanged.Pressed;

    public bool MovementReleased => m_movementChanged == InputChanged.Released;

    public bool MovementChanged => m_movementChanged == InputChanged.ValueChanged;


    // Space
    public bool spacePress => m_spaceInput;

    public bool spacePressed => m_spaceChanged == InputChanged.Pressed;

    public bool spaceReleased => m_spaceChanged == InputChanged.Released;

    private void OnEnable()
    {
        MovementAction.Enable();
        SpaceAction.Enable();
    }

    private void OnDisable()
    {
        MovementAction.Disable();
        SpaceAction.Disable();
    }

    private void Update()
    {
        ReadInputs();
        UpdateProperties();
        UpdateLastInputs();
    }

    /// <summary>
    /// Read the current user inputs for this frame.
    /// </summary>
    private void ReadInputs()
    {
        m_spaceInput = ReadButtonInput(SpaceAction);

        m_movementInput = ReadVectorInput(MovementAction);
    }

    /// <summary>
    /// Update the publicly accessible properties, used by other classes to work with player input.
    /// </summary>
    private void UpdateProperties()
    {
        m_spaceChanged = HasBoolChanged(m_spaceInput, m_lastSpaceInput);

        var wasMoving = m_isMoving;
        m_isMoving = m_movementInput != Vector2.zero;

        m_movementChanged = HasBoolChanged(m_isMoving, wasMoving);
        if (m_movementChanged == InputChanged.None && m_movementInput != m_lastMovementInput)
        {
            m_movementChanged = InputChanged.ValueChanged;
        }
    }

    /// <summary>
    /// Update the "last frame" variables for next frame's inputs.
    /// </summary>
    private void UpdateLastInputs()
    {
        m_lastMovementInput = m_movementInput;
        m_lastSpaceInput = m_spaceInput;
    }


    private static bool ReadButtonInput(InputAction _inputButton)
        => _inputButton.ReadValue<float>() > 0.0f;


    private static Vector2 ReadVectorInput(InputAction _inputVector)
        => _inputVector.ReadValue<Vector2>();


    private static InputChanged HasBoolChanged(bool _value, bool _lastValue)
    {
        if (_value && !_lastValue)
        {
            return InputChanged.Pressed;
        }
        else if (!_value && _lastValue)
        {
            return InputChanged.Released;
        }

        return InputChanged.None;
    }
}
