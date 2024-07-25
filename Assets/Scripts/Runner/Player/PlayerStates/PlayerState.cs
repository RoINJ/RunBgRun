using UnityEngine;

namespace Scripts.Runner.Player.PlayerStates
{
    public abstract class PlayerState
    {
        protected PlayerMovement PlayerMovement { get; }
        protected Animator Animator { get; }

        protected PlayerState(PlayerMovement playerMovement)
        {
            PlayerMovement = playerMovement;
            Animator = playerMovement.GetComponentInChildren<Animator>();
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
