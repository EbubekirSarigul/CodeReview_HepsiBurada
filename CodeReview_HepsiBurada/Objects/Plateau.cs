using System.Collections.Generic;

namespace CodeReview_HepsiBurada.Objects
{
    public class Plateau
    {
        public int XAxisLength { get; set; }

        public int YAxisLength { get; set; }

        private List<Rover> _rovers;

        public List<Rover> Rovers
        {
            get
            {
                return _rovers;
            }
        }

        public Plateau(int xAxisLength, int yAxisLength)
        {
            XAxisLength = xAxisLength;
            YAxisLength = yAxisLength;
            _rovers = new List<Rover>();
        }

        public void AddRover(string roverInitials, string instructions)
        {
            var aRoverInitials = roverInitials.Split(' '); // 0=>initial x, 1=>initial y, 2=>initial direction

            if (!int.TryParse(aRoverInitials[0], out int initialX))
            {
                throw new MyException($"Initial X is invalid:{aRoverInitials[0]}");
            }

            if (!int.TryParse(aRoverInitials[1], out int initialY))
            {
                throw new MyException($"Initial Y is invalid:{aRoverInitials[1]}");
            }

            if (!aRoverInitials[2].Equals("N") && !aRoverInitials[2].Equals("S") && !aRoverInitials[2].Equals("W") && !aRoverInitials[2].Equals("E"))
            {
                throw new MyException($"Invalid input! Following direction is invalid:{aRoverInitials[2]}");
            }

            var rover = new Rover(this);
            rover.Initialize(initialX, initialY, aRoverInitials[2], instructions);

            _rovers.Add(rover);
        }
    }
}
