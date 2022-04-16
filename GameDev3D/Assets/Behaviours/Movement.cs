using UnityEngine;

namespace Behaviours
{
    public class Movement : MonoBehaviour
    {
        public CharacterController controller;
    
        public float speed = 10f;
        public float jumpHeight = 10f;
        public float gravity = -9.8f;

        private Vector3 move;

        private void Update()
        {
            if (ReduceLight.Finished && !ReduceLight.Won) return;

            if (controller.isGrounded && move.y < 0)
            {
                move.y = 0f;
            }

            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            var transformRef = transform;
            move = transformRef.right * x + transformRef.forward * z;

            if (Input.GetButtonDown("Jump") && controller.isGrounded)
            {
                move.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            }
            move.y += gravity * Time.deltaTime;

            controller.Move(move * speed * Time.deltaTime);
        }
    }
}
