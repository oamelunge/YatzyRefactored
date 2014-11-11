using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;

public class Yatzy
{

    protected int[] dice;
    public Yatzy(int d1, int d2, int d3, int d4, int _5)
    {
        dice = new int[5];
        dice[0] = d1;
        dice[1] = d2;
        dice[2] = d3;
        dice[3] = d4;
        dice[4] = _5;
    }

    public int Chance()
    {
        return dice.Sum(x => x);
    }

    public int yatzy()
    {
        return dice.GroupBy(x => x).Select(@group => @group.Count()).FirstOrDefault().Equals(5) ? 50 : 0;
    }

    public int CalculateSumForFacesFromTheSameNumer(int number)
    {
        return dice.Where(x => x == number).Select(x => x).Sum();
    }

    public int ScorePair()
    {
        var scorePair = dice.GroupBy(x => x).Where(g => g.Count() == 2);       
        if (scorePair.Any())
           return scorePair.Max(g => g.Key)*2 ;
        return 0;
    }

    public int CalculateForThreeAndFourOfKind(int numberOfAKind)
    {
        return dice.GroupBy(x => x).Where(g => g.Count() >= numberOfAKind)
             .Select(number => number.Key)
             .FirstOrDefault() * numberOfAKind;
    }

    public int CalculateStraights(int straihtResult)
    {
        return dice.GroupBy(x => x).Select(x => x.Key)
                .Sum() == straihtResult ? straihtResult : 0;
    }

    public int TwoPair()
    {
        return dice.GroupBy(x => x).Where(g => g.Count() >= 2).Sum(x => x.Key)*2;                    
    }

    public  int FullHouse()
    {
        return ScorePair() + CalculateForThreeAndFourOfKind(3);

    }

}


