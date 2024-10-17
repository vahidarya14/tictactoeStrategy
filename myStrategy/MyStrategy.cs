
using A.Framework;

namespace myStrategy;

public class MyStrategy(Board board) : PcStrategy(board)
{
    public override string Name => "my Strategy name";

    public override async ValueTask PcMove(bool asStart = false)
    {
        //1-this is how you have a property witch is [ground), to access all cells
        var topLeft = Cell(Position.topLeft);         //equals Cell(0,0)
        var topMidle = Cell(Position.topMidle);       //equals Cell(0,1)
        var topright = Cell(Position.topright);       //equals Cell(0,2)
        var midleLeft = Cell(Position.midleLeft);     //equals Cell(1,0)
        var midlle = Cell(Position.midlle);           //equals Cell(1,1)
        var midleright = Cell(Position.midleright);   //equals Cell(1,2)
        var bottomLeft = Cell(Position.bottomLeft);   //equals Cell(2,0)
        var bottomMidle = Cell(Position.bottomMidle); //equals Cell(2,1)
        var bottomRight = Cell(Position.bottomRight); //equals Cell(2,2)


        if (topLeft == (int)Turn.Pc) ;     //<== meas PC have mark cell topLeft (buy using your  algorithm)
        if (topLeft == (int)Turn.Player) ; //<== meas your competitor have mark cell topLeft



        //2-this is howto put you mark in selected cell use one of these 
        await MyChoiceIs(0, 2);
        //or
        await MyChoiceIs(Position.midleLeft);


        //3-sample 
        //write our  algorithm here. something like this
        if (topLeft == (int)Turn.Pc && topright == (int)Turn.Pc)
        {
            await MyChoiceIs(Position.topMidle);
        }

    }
}
