using CodeReview_HepsiBurada.Movement;

namespace CodeReview_HepsiBurada.Objects
{
    /// <summary>
    /// State pattern is used here for Rover's movements.
    /// </summary>
    public class Rover
    {
        private readonly Plateau _plateau;
        private Pozition _pozition;
        private IRotationState _rotationState;
        private string _instructions;

        public Pozition Pozition
        {
            get
            {
                return _pozition;
            }
        }

        public Rover(Plateau plateau)
        {
            _plateau = plateau;
        }

        public void ChangeRotationState(IRotationState rotationState)
        {
            _rotationState = rotationState;
        }

        public void Initialize(int initialX, int initialY, string initialDirection, string instructions)
        {
            Enums.Directions direction = default(Enums.Directions);

            if (initialDirection.Equals("N"))
            {
                direction = Enums.Directions.North;
                _rotationState = new NorthRotationState(this);
            }
            else if (initialDirection.Equals("E"))
            {
                direction = Enums.Directions.East;
                _rotationState = new EastRotationState(this);
            }
            else if (initialDirection.Equals("S"))
            {
                direction = Enums.Directions.South;
                _rotationState = new SouthRotationState(this);
            }
            else if (initialDirection.Equals("W"))
            {
                direction = Enums.Directions.West;
                _rotationState = new WestRotationState(this);
            }
            else
            {
                throw new MyException($"Invalid input! Following direction is invalid:{initialDirection}");
            }

            _pozition = new Pozition
            {
                X = initialX,
                Y = initialY,
                Direction = direction
            };

            _instructions = instructions;
        }

        public void Explore()
        {
            foreach (var command in _instructions)
            {
                if (command.Equals('L'))
                {
                    _rotationState.TurnLeft(_pozition);
                }
                else if (command.Equals('R'))
                {
                    _rotationState.TurnRight(_pozition);
                }
                else if (command.Equals('M'))
                {
                    _rotationState.Move(_pozition);
                    if (_pozition.X > _plateau.XAxisLength || _pozition.Y > _plateau.YAxisLength
                        || _pozition.X < 0 || _pozition.Y < 0)
                    {
                        throw new MyException($"Invalid movement! Rover went out of the plateau.");
                    }
                }
                else
                {
                    throw new MyException($"Invalid command in instructions:{command}");
                }
            }
        }
    }
}
