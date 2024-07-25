using DG.Tweening;
using UnityEngine;

namespace Scripts.Runner.Player.PlayerStates
{
    public class DeadState : PlayerState
    {
        private const float DeathAnimationTime = 0.5f;
        private const float FallAngle = 80f;

        private Vector3 _fallDirection;

        public DeadState(PlayerMovement playerMovement, Animator animator, Vector3 fallDirection) : base(playerMovement, animator)
        {
            _fallDirection = fallDirection;
        }

        public override void Enter()
        {
            Fall();

            Animator.SetTrigger(Constants.Triggers.DeathTrigger);
        }

        public override void Exit()
        {
            PlayerMovement.transform.rotation = Quaternion.Euler(
                0,
                PlayerMovement.transform.rotation.y,
                PlayerMovement.transform.rotation.z);

            Animator.SetTrigger(Constants.Triggers.RespawnTrigger);
        }

        private void Fall()
        {
            var newRotation = _fallDirection * FallAngle + PlayerMovement.transform.rotation.eulerAngles;
            PlayerMovement.transform.DORotate(newRotation, DeathAnimationTime);
        }
    }
}
