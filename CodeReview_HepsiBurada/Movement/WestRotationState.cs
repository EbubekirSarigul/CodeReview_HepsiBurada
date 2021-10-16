using CodeReview_HepsiBurada.Objects;

namespace CodeReview_HepsiBurada.Movement
{
    public class WestRotationState : RotationState
    {
        public WestRotationState(Rover rover) : base(rover)
        {

        }

        public override void Move(Pozition currentPozition)
        {
            currentPozition.X--;
        }

        public override void TurnLeft(Pozition pozition)
        {
            pozition.Direction = Enums.Directions.South;
            _rover.ChangeRotationState(new SouthRotationState(_rover));
        }

        public override void TurnRight(Pozition pozition)
        {
            pozition.Direction = Enums.Directions.North;
            _rover.ChangeRotationState(new NorthRotationState(_rover));
        }
    }
}
