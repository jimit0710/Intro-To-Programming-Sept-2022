namespace CSharpSyntaxStuff;

public class ClassesAndRecords
{
    [Fact]
    public void DoThings()
    {
        var myName = "Jimit";
        myName = myName.ToUpper();
        Assert.Equal("JIMIT", myName);
    }

    [Fact]
    public void BowlingForImmutableTypes()
    {
        var game = new BowlingGame();
        // add a bunch of games

        var winner = game.GetWinner();
        // Assert.Equal("Jimit", winner.Name);
        // Assert.Equal(198, winner.Score);

        var expectedWinner = new Bowler("Jimit", 198);
        Assert.Equal(expectedWinner, winner);
        Assert.Equal("Jimit", winner.Name);
    }
}

public record struct Point(int x, int y);

public class BowlingGame
{
    public Bowler GetWinner()
    {
        return new Bowler("Jimit", 198);
    }
}

public record Bowler (string Name, int Score);

//public record Bowler
//{
//    public Bowler(string name, int score)
//    {
//        Name = name;
//        Score = score;
//    }
//    public string Name { get; private set; }
//    public int Score { get; private set; }
//}

