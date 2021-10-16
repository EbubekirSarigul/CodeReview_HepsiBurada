using CodeReview_HepsiBurada.Objects;
using System;
using System.IO;
using System.Text;

namespace CodeReview_HepsiBurada
{
    /// <summary>
    /// Input format assumed as below.
    /// 
    /// xlength ylength
    /// initialX initialY initialDirection
    /// instructions
    /// initialX initialY initialDirection
    /// instructions
    /// initialX initialY initialDirection
    /// instructions
    /// ...
    /// 
    /// </summary>
    public class Exploration
    {
        public string Explore(string input)
        {
            try
            {
                if (string.IsNullOrEmpty(input))
                {
                    return input;
                }

                StringBuilder resultBuilder = new StringBuilder();

                Plateau plateau;
                using (var reader = new StringReader(input))
                {
                    var firstLine = reader.ReadLine();
                    var lengths = firstLine.Split(' ');

                    if (!int.TryParse(lengths[0], out int xLength))
                    {
                        throw new MyException($"Length of the x axis is invalid:{lengths[0]}");
                    }

                    if (!int.TryParse(lengths[1], out int yLength))
                    {
                        throw new MyException($"Length of the y axis is invalid:{lengths[1]}");
                    }

                    plateau = new Plateau(xLength, yLength);

                    while (true)
                    {
                        var roverInitials = reader.ReadLine();
                        var instructions = reader.ReadLine();

                        if (string.IsNullOrEmpty(roverInitials) || string.IsNullOrEmpty(instructions))
                        {
                            break;
                        }

                        plateau.AddRover(roverInitials, instructions);
                    }
                }

                foreach (var rover in plateau.Rovers)
                {
                    rover.Explore();
                    resultBuilder.AppendLine(rover.Pozition.ToString());
                }

                var result = resultBuilder.ToString();

                return result.Trim();
            }
            catch (MyException myException)
            {
                return $"::ErrorOccured::{myException.ErrorMessage}";
            }
            catch (Exception exception)
            {
                return $"::ErrorOccured::{exception.Message}";
            }
        }
    }
}
