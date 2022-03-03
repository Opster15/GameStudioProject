using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Minigames
{
    public class MG_Platformer_Movement : MonoBehaviour
    {
        public InputManager inputManager;

        public float jumpForce = 12;

        public float movementSpeed = 6;
        public bool isWalking;
        public bool isFalling;

        public bool isGrounded;
        public Transform GCPosition;
        public float GCRadius;
        public LayerMask whatIsGround;

        private bool wasGrounded;

        private float jumpTimeCounter;
        public float jumpTime;
        public bool isJumping;

        public float jumpTimer = 1.0f;
        private float jumpCounter;

        public Rigidbody2D rb;
        public float yVelocity, fallingForce, yVelocityThreshhold;

        private float timeMoving;
        public float movementWarmupTime;
        private bool wasMoving;

        public float velocity;
        public float velocityFalloff;

        public int windEffectors;

        public float maxVelocityMagnitude;
        public float velocityClampSmoothTime;
        private Vector2 currentVelocity;


        void Start()
        {
            inputManager = FindObjectOfType<InputManager>();

            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {

            if (jumpCounter > 0)
            {
                jumpCounter -= Time.deltaTime;
            }

            #region Jump
            if (inputManager.spacePressed && jumpCounter <= 0 && isGrounded)
            {
                Jump();
            }

            if (inputManager.spaceReleased)
            {
                isJumping = false;
            }
            #endregion
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            CheckGrounded();
            CheckMovement();

            yVelocity = rb.velocity.y;

            if (!wasGrounded && isGrounded) { jumpCounter = 0; }
            wasGrounded = isGrounded;
        }



        public void CheckMovement()
        {

            isWalking = Mathf.Abs(inputManager.m_movementInput.x) > 0.001;

            if (isWalking)
            {
                timeMoving += Time.fixedDeltaTime;
                var currentSpeed = movementWarmupTime > 0 ? Mathf.Clamp(movementSpeed * timeMoving / movementWarmupTime, 0, movementSpeed) : movementSpeed;
                rb.velocity = new Vector2(currentSpeed * inputManager.m_movementInput.x + velocity, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(velocity, rb.velocity.y);
                timeMoving = Mathf.Clamp(timeMoving - Time.fixedDeltaTime / 2, 0, movementWarmupTime);
            }

            velocity *= velocityFalloff;

            if (!isGrounded)
            {
                rb.AddForce(Vector2.down * fallingForce, ForceMode2D.Force);
            }

            rb.velocity = Vector2.SmoothDamp(rb.velocity, Vector2.ClampMagnitude(rb.velocity, maxVelocityMagnitude), ref currentVelocity, velocityClampSmoothTime);

            wasMoving = isWalking;
            

        }


        #region Jump 

        public void CheckGrounded()
        {
            isGrounded = Physics2D.OverlapCircle(GCPosition.position, GCRadius, whatIsGround);
        }

        public void Jump()
        {
            var jumpImpulse = Vector2.up * jumpForce;

            jumpCounter = jumpTimer;

            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.AddForce(jumpImpulse, ForceMode2D.Impulse);
        }

        #endregion

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(GCPosition.position, GCRadius);
        }
    }
}
