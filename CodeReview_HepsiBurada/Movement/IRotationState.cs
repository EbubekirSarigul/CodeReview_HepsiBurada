using CodeReview_HepsiBurada.Objects;

namespace CodeReview_HepsiBurada.Movement
{
    public interface IRotationState
    {
        void Move(Pozition currentPozition);

        void TurnLeft(Pozition pozition);

        void TurnRight(Pozition pozition);
    }
}
