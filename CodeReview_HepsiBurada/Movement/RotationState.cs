using CodeReview_HepsiBurada.Objects;

namespace CodeReview_HepsiBurada.Movement
{
    public abstract class RotationState : IRotationState
    {
        protected readonly Rover _rover;

        public RotationState(Rover rover)
        {
            _rover = rover;
        }

        public abstract void Move(Pozition currentPozition);

        public abstract void TurnLeft(Pozition pozition);

        public abstract void TurnRight(Pozition pozition);
    }
}
