using UnityEngine;

namespace PlayerSpace
{
    public class Player : MonoBehaviour
    {
        public bool IsAlive = true;
        public float MaxRunSpeed;
        public float HorizontalSpeed;
        public float JumpForce;
        public LayerMask GroundMask;
        
        private Rigidbody _rigidBody;
        private float _horizontalInput;
        private Collider _collider;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
        }

        private void FixedUpdate()
        {
            if (IsAlive)
            {
                Vector3 forwardMovement = transform.forward * (MaxRunSpeed * Time.fixedDeltaTime);
                Vector3 horizontalMovement = transform.right * (HorizontalSpeed * _horizontalInput * Time.fixedDeltaTime);
                
                _rigidBody.MovePosition(_rigidBody.position + forwardMovement + horizontalMovement);
            }
        }

        private void Update()
        {
            _horizontalInput = Input.GetAxisRaw("Horizontal");
            
            float playerHeight = _collider.bounds.size.y;
            bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (playerHeight / 2) + 0.1f, GroundMask);

            if (isGrounded && IsAlive && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        private void Jump()
        {
            _rigidBody.AddForce(Vector3.up * JumpForce);
        }
    }
}

