using A.Framework;

namespace board.Startegy2;

public class PcStrategy3(Board board) : PcStrategy(board)
{
    public override string Name { get; } = "vahid-Easy";

    public override async ValueTask PcMove(bool asStart = false)
    {
        var lst = new int?[3];
        #region  //--------------------------first check my win situation
        for (int w = 0; w < 3; w++)
        {
            lst = [Cell(w, 0), Cell(w, 1), Cell(w, 2)];
            if (lst.Count(x => x.HasValue && x.Value == (int)Turn.Pc) == 2)
            {
                for (var room = 0; room < lst.Length; room++)
                    if (!Cell(w, room).HasValue)
                    {
                        await  MyChoiceIs(w, room);
                        return;
                    }
            }
        }
        for (int w = 0; w < 3; w++)
        {
            lst = [Cell(0, w), Cell(1, w), Cell(2, w)];
            if (lst.Count(x => x.HasValue && x.Value == (int)Turn.Pc) == 2)
            {
                for (var room = 0; room < lst.Length; room++)
                    if (!Cell(room, w).HasValue)
                    {
                        await  MyChoiceIs(room, w);

                        return;
                    }
            }
        }

        lst = [Cell(0, 0), Cell(1, 1), Cell(2, 2)];
        if (lst.Count(x => x.HasValue && x.Value == (int)Turn.Pc) == 2)
        {
            for (var w = 0; w < lst.Length; w++)
                if (!Cell(w, w).HasValue)
                {
                    await  MyChoiceIs(w, w);
                    return;
                }
        }

        lst = [Cell(0, 2), Cell(1, 1), Cell(2, 0)];
        if (lst.Count(x => x.HasValue && x.Value == (int)Turn.Pc) == 2)
        {
            for (var w = 0; w < lst.Length; w++)
                if ((w == 0 && Cell(0, 2) == null) || (w == 1 && Cell(1, 1) == null) || (w == 2 && Cell(2, 0) == null))
                {
                    if (w == 0 && Cell(0, 2) == null) await MyChoiceIs(0, 2);
                    if (w == 1 && Cell(1, 1) == null) await MyChoiceIs(1, 1);
                    if (w == 2 && Cell(2, 0) == null) await MyChoiceIs(2, 0);
                    return;
                }
        }
        #endregion


        while (true)
        {
            var aa = new Random().Next(0, 9);
            var i = aa < 3 ? 0 : aa < 6 ? 1 : 2;
            var j = aa % 3;
            if (Cell(i, j) == null)
            {
                await MyChoiceIs(i, j);
                break;
            }
        }
    }
}
