using UnityEngine;

namespace _Advanced
{
    public class PlayerInput : MonoBehaviour
    {
        #region INITIALIZE INPUT

        //private InputActions _inputActions;
        private InputTest _inputActions;
        private void Awake() => _inputActions = new InputTest();
        private void OnEnable() => _inputActions.Enable();
        private void OnDisable() => _inputActions.Disable();

        #endregion

        #region INPUT VARIABLES

        public Vector2 MoveDirection { get; private set; }
        public Vector2 LookDirection { get; private set; }

        public float JumpValue { get; private set; }
        public bool JumpHeld { get; private set; }
        public bool JumpReleased { get; private set; }
        public bool JumpPressed { get; private set; }

        public float InteractValue { get; private set; }
        public bool Interact { get; private set; }

        #endregion

        private void Update()
        {
            MoveDirection = _inputActions.Player.Move.ReadValue<Vector2>();
            LookDirection = _inputActions.Player.Look.ReadValue<Vector2>();

            JumpValue = _inputActions.Player.Jump.ReadValue<float>();
            JumpHeld = _inputActions.Player.Jump.inProgress;
            JumpPressed = _inputActions.Player.Jump.triggered;
            JumpReleased = _inputActions.Player.Jump.WasReleasedThisFrame();

            InteractValue = _inputActions.Player.Interact.ReadValue<float>();
            Interact = _inputActions.Player.Interact.triggered;
        }
    }
}