

namespace Katas_TDD.MarsRoverKata
{
    public class MarsRoverKata
    {
        private readonly string _startingPoistion;
        private readonly string[] _obstacles;


         public MarsRoverKata(string startingPoistion, string[] obs)
         {
            _startingPoistion = startingPoistion;
            _obstacles = obs;
         }


        public (string newPosition, string obstacleMessage) Move(string interaction, string obsMessage)
        {
            interaction = ValidateInteraction(interaction);
            string newPos = ValidatePosition(_startingPoistion);
            obsMessage = "Obs at : ";

            for (int i = 0; i < interaction.Length; i++)
            {
                if (interaction[i] == 'F')
                {

                    newPos = MoveForward(ref newPos, newPos[2], _obstacles, ref obsMessage);
                }

                if (interaction[i] == 'L')
                {
                    newPos = MoveLeft(ref newPos);
                }

                if (interaction[i] == 'R')
                {
                    newPos = MoveRight(ref newPos);
                }
            }

            return (newPos, obsMessage);
        }




        private string MoveForward(ref string oldPosition, char direction, string[] obs, ref string obstacleMessage)
        {

            switch (direction)
            {

                case 'E':
                    oldPosition = MoveForwardEast(oldPosition, obs, ref obstacleMessage);
                    break;
                case 'S':
                    oldPosition = MoveForwardSouth(oldPosition, obs, ref obstacleMessage);
                    break;
                case 'W':
                    oldPosition = MoveForwardWest(oldPosition, obs, ref obstacleMessage);
                    break;
                case 'N':
                    oldPosition = MoveForwardNorth(oldPosition, obs, ref obstacleMessage);
                    break;
                default:
                    break;
            }



            return oldPosition;

        }


        private string MoveForwardEast(string oldPosition, string[] obs, ref string obstacleMessage)
        {
            string newPos = "";

            var Y = int.Parse(oldPosition[1].ToString());

            Y++;

            Y = FixEdges(Y);

            newPos += oldPosition.Substring(0, 1) + $"{Y}" + oldPosition.Substring(2);

            if (obs.Contains(newPos.Substring(0, 2)))
            {
                obstacleMessage += $"{newPos.Substring(0, 2)} ";
                return oldPosition;
            }


            return newPos;
        }

        private string MoveForwardSouth(string oldPosition, string[] obs, ref string obstacleMessage)
        {
            string newPos = "";

            var Y = int.Parse(oldPosition[0].ToString());

            Y++;

            Y = FixEdges(Y);

            newPos += $"{Y}" + oldPosition.Substring(1, 2);


            if (obs.Contains(newPos.Substring(0, 2)))
            {
                obstacleMessage += $" {newPos.Substring(0, 2)} ";
                return oldPosition;
            }

            return newPos;
        }

        private string MoveForwardWest(string oldPosition, string[] obs, ref string obstacleMessage)
        {
            string newPos = "";

            var Y = int.Parse(oldPosition[1].ToString());

            Y--;

            Y = FixEdges(Y);

            newPos += oldPosition.Substring(0, 1) + $"{Y}" + oldPosition.Substring(2);

            if (obs.Contains(newPos.Substring(0, 2)))
            {
                obstacleMessage += $"{newPos.Substring(0, 2)} ";
                return oldPosition;
            }
            return newPos;
        }

        private string MoveForwardNorth(string oldPosition, string[] obs, ref string obstacleMessage)
        {
            string newPos = "";

            var Y = int.Parse(oldPosition[0].ToString());

            Y--;

            Y = FixEdges(Y);

            newPos += $"{Y}" + oldPosition.Substring(1, 2);

            if (obs.Contains(newPos.Substring(0, 2)))
            {
                obstacleMessage += $"{newPos.Substring(0, 2)}";
                return oldPosition;
            }

            return newPos;

        }



        private string MoveLeft(ref string oldPosition)
        {

            switch (oldPosition[2])
            {

                case 'N':
                    oldPosition = oldPosition.Substring(0, 2) + "W";
                    break;
                case 'W':
                    oldPosition = oldPosition.Substring(0, 2) + "S";
                    break;
                case 'S':
                    oldPosition = oldPosition.Substring(0, 2) + "W";
                    break;
                case 'E':
                    oldPosition = oldPosition.Substring(0, 2) + "N";
                    break;
                default:
                    break;
            }



            return oldPosition;


        }
        private string MoveRight(ref string oldPosition)
        {

            switch (oldPosition[2])
            {

                case 'N':
                    oldPosition = oldPosition.Substring(0, 2) + "E";
                    break;
                case 'S':
                    oldPosition = oldPosition.Substring(0, 2) + "E";
                    break;
                case 'W':
                    oldPosition = oldPosition.Substring(0, 2) + "N";
                    break;
                case 'E':
                    oldPosition = oldPosition.Substring(0, 2) + "S";
                    break;
                default:
                    break;
            }



            return oldPosition;


        }

        private int FixEdges(int X)
        {


            return (X >= 1 && X <= 5) ? X : (X == 0) ? 5 : 1;

        }

        private string ValidatePosition(string startPosition)
        {

            int i;
            bool isNumeric = int.TryParse(startPosition.Substring(0, 2), out i);
            bool IsValidDerictin = startPosition[2] == 'S' || startPosition[2] == 'N' || startPosition[2] == 'E' || startPosition[2] == 'W';
            bool IsValid = (startPosition.Length == 3) && (isNumeric == true) && IsValidDerictin;

            if (!IsValid)
            {
                throw new ArgumentException("Enter a valid Position");
            }



            return startPosition;
        }

        private string ValidateInteraction(string interaction)
        {
            var ValidIntercations = new List<char>()
                    {
                        'F',
                        'L',
                        'R'
                    };

            for (int i = 0; i < interaction.Length; i++)
            {
                if (!ValidIntercations.Contains(interaction[i]))
                {
                    throw new ArgumentException("Enter a valid Interaction");
                }
            }


            return interaction;
        }
    }
}
