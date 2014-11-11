using NUnit.Framework;

[TestFixture]
public class UntitledTest
{
    [Test]
    public void Chance_scores_sum_of_all_dice()
    {
        Assert.AreEqual(15, new Yatzy(2,3,4,5,1).Chance());
        Assert.AreEqual(16, new Yatzy(3,3,4,5,1).Chance());
    }

    [Test]
    public void Yatzy_scores_50() 
    {
        Assert.AreEqual(50, new Yatzy(4,4,4,4,4).yatzy());
        Assert.AreEqual(50, new Yatzy(6,6,6,6,6).yatzy());
        Assert.AreEqual(0, new Yatzy(6,6,6,6,3).yatzy());
    }

    [Test]
    public void Test_1s()
    {
        var number = 1;
        Assert.IsTrue(new Yatzy(1, 2, 3, 4, 5).CalculateSumForFacesFromTheSameNumer(number) == 1);
        Assert.AreEqual(2, new Yatzy(1, 2, 1, 4, 5).CalculateSumForFacesFromTheSameNumer(number));
        Assert.AreEqual(0, new Yatzy(6, 2, 2, 4, 5).CalculateSumForFacesFromTheSameNumer(number));
        Assert.AreEqual(4, new Yatzy(1, 2, 1, 1, 1).CalculateSumForFacesFromTheSameNumer(number));
    }

    
    public void testForSameNumber(int spectecNumber, int[] dice, int numberToCalculate)
    {
        Assert.AreEqual(spectecNumber, new Yatzy(dice[0],dice[1],dice[2],dice[3],dice[4]).CalculateSumForFacesFromTheSameNumer(numberToCalculate));
    }

    [Test]
    public void test_2s() 
    {
        testForSameNumber(4,new int[] {1, 2, 3, 2, 6},2);
        testForSameNumber(10, new int[] { 2, 2, 2, 2, 2 }, 2);    
    }

    [Test]
    public void test_3s() 
    {
        Assert.AreEqual(6, new Yatzy(1, 2, 3, 2, 3).CalculateSumForFacesFromTheSameNumer(3));
        Assert.AreEqual(12, new Yatzy(2, 3, 3, 3, 3).CalculateSumForFacesFromTheSameNumer(3));
    }

    [Test]
    public void test_4s() 
    {
        Assert.AreEqual(12, new Yatzy(4, 4, 4, 5, 5).CalculateSumForFacesFromTheSameNumer(4));
        Assert.AreEqual(8, new Yatzy(4, 4, 5, 5, 5).CalculateSumForFacesFromTheSameNumer(4));
        Assert.AreEqual(4, new Yatzy(4, 5, 5, 5, 5).CalculateSumForFacesFromTheSameNumer(4));
    }

    [Test]
    public void test_5s()
    {
        Assert.AreEqual(10, new Yatzy(4, 4, 4, 5, 5).CalculateSumForFacesFromTheSameNumer(5));
        Assert.AreEqual(15, new Yatzy(4, 4, 5, 5, 5).CalculateSumForFacesFromTheSameNumer(5));
        Assert.AreEqual(20, new Yatzy(4, 5, 5, 5, 5).CalculateSumForFacesFromTheSameNumer(5));
    }

    [Test]
    public void test_6s() 
    {
        Assert.AreEqual(0, new Yatzy(4, 4, 4, 5, 5).CalculateSumForFacesFromTheSameNumer(6));
        Assert.AreEqual(6, new Yatzy(4, 4, 6, 5, 5).CalculateSumForFacesFromTheSameNumer(6));
        Assert.AreEqual(18, new Yatzy(6, 5, 6, 6, 5).CalculateSumForFacesFromTheSameNumer(6));
    }

    [Test]
    public void one_pair() 
    {
        Assert.AreEqual(6, new Yatzy(3, 4, 3, 5, 6).ScorePair());
        Assert.AreEqual(10, new Yatzy(5, 3, 3, 3, 5).ScorePair());
        Assert.AreEqual(12, new Yatzy(5, 3, 6, 6, 5).ScorePair());
    }

    [Test]
    public void two_Pair() 
    {
        Assert.AreEqual(16, new Yatzy(3,3,5,4,5).TwoPair());
        Assert.AreEqual(16, new Yatzy(3,3,5,5,5).TwoPair());
    }

    [Test]
    public void three_of_a_kind() 
    {
        Assert.AreEqual(9, new Yatzy(3, 3, 3, 4, 5).CalculateForThreeAndFourOfKind(3));
        Assert.AreEqual(15, new Yatzy(5, 3, 5, 4, 5).CalculateForThreeAndFourOfKind(3));
        Assert.AreEqual(9, new Yatzy(3, 3, 3, 3, 5).CalculateForThreeAndFourOfKind(3));
    }

    [Test]
    public void four_of_a_knd() 
    {
        Assert.AreEqual(12, new Yatzy(3, 3, 3, 3, 5).CalculateForThreeAndFourOfKind(4));
        Assert.AreEqual(20, new Yatzy(5, 5, 5, 4, 5).CalculateForThreeAndFourOfKind(4));
        Assert.AreEqual(12, new Yatzy(3, 3, 3, 3, 3).CalculateForThreeAndFourOfKind(4));
    }

    [Test]
    public void smallStraight() 
    {
        Assert.AreEqual(15, new Yatzy(1, 2, 3, 4, 5).CalculateStraights(15));
        Assert.AreEqual(15, new Yatzy(2, 3, 4, 5, 1).CalculateStraights(15));
        Assert.AreEqual(0, new Yatzy(1, 2, 2, 4, 5).CalculateStraights(15));
    }

    [Test]
    public void largeStraight() 
    {
        Assert.AreEqual(20, new Yatzy(6, 2, 3, 4, 5).CalculateStraights(20));
        Assert.AreEqual(20, new Yatzy(2, 3, 4, 5, 6).CalculateStraights(20));
        Assert.AreEqual(0, new Yatzy(1, 2, 2, 4, 5).CalculateStraights(20));
    }

    [Test]
    public void fullHouse() 
    {
        Assert.AreEqual(0, new Yatzy(2,3,4,5,6).FullHouse());
        Assert.AreEqual(18, new Yatzy(6,2,2,2,6).FullHouse());
        Assert.AreEqual(8, new Yatzy(1,1,2,2,2).FullHouse());
        
    }
}
