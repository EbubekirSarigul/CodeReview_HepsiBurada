using CodeReview_HepsiBurada.Objects;

namespace CodeReview_HepsiBurada.Movement
{
    public class SouthRotationState : RotationState
    {
        public SouthRotationState(Rover rover) : base(rover)
        {

        }

        public override void Move(Pozition currentPozition)
        {
            currentPozition.Y--;
        }

        public override void TurnLeft(Pozition pozition)
        {
            pozition.Direction = Enums.Directions.East;
            _rover.ChangeRotationState(new EastRotationState(_rover));
        }

        public override void TurnRight(Pozition pozition)
        {
            pozition.Direction = Enums.Directions.West;
            _rover.ChangeRotationState(new WestRotationState(_rover));
        }
    }
}
