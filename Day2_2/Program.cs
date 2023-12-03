using System.Text.RegularExpressions;

// Load objects up with data
var games = new List<Game>();
foreach(string gamedata in System.IO.File.ReadAllLines("input.txt"))
{
    games.Add(new Game(gamedata));
}

int power = 0;
foreach(Game game in games)
{
    power += game.MaxGreen * game.MaxRed * game.MaxBlue;
}
Console.WriteLine("Total power is: {0}", power);


public class Game
{
    public int Number { get; set; }

    public List<Draw> Draws { get; set; } = new List<Draw>();

    public int MaxRed
    {
        get { return Draws.Max(x => x.Red); }
    }
    public int MaxGreen
    {
        get { return Draws.Max(x => x.Green); }
    }
    public int MaxBlue
    {
        get { return Draws.Max(x => x.Blue); }
    }


    public Game(string values)
    {
        //Parse the game number
        this.Number = int.Parse(Regex.Match(values, @"Game (\d{1,3})").Groups[1].Value);

        //Parse draws
        foreach (string drawdata in values.Substring(values.IndexOf(":")+1).Split(";"))
        {
            this.Draws.Add(new Draw(drawdata));
        }
    }

    public override string? ToString()
    {
        return String.Format("Game {0}", Number);
    }


    public class Draw
    {
        public int Red { get; set; } = 0;
        public int Blue { get; set; } = 0;
        public int Green { get; set; } = 0;

        public Draw(string values)
        {
            //TODO: Parse the block values
            var drawdata = values.Split(",");
            foreach(string cubedata in drawdata)
            {
                var singlecubedata = cubedata.Split(" ");

                switch(singlecubedata[2])
                {
                    case "red":
                        Red = int.Parse(singlecubedata[1]);
                        break;
                    case "green":
                        Green = int.Parse(singlecubedata[1]);
                        break;
                    case "blue":
                        Blue = int.Parse(singlecubedata[1]);
                        break;
                    default: 
                        break;
                }
            }
        }
    }
}

