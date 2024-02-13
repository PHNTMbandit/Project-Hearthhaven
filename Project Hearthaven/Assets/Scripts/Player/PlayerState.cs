namespace ProjectHearthaven.Player
{
    public class PlayerState
    {
        protected PlayerStateController stateController;
        protected string stateAnimationName;

        public PlayerState(PlayerStateController stateController, string stateAnimationName)
        {
            this.stateController = stateController;
            this.stateAnimationName = stateAnimationName;
        }

        public virtual void OnEnter()
        {
            for (int i = 0; i < stateController.Animators.Length; i++)
            {
                stateController.Animators[i].SetBool(stateAnimationName, true);
            }
        }

        public virtual void OnExit()
        {
            for (int i = 0; i < stateController.Animators.Length; i++)
            {
                stateController.Animators[i].SetBool(stateAnimationName, false);
            }
        }

        public virtual void OnUpdate() { }

        public virtual void OnFixedUpdate() { }
    }
}
