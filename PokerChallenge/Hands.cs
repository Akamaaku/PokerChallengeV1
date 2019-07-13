using System;
using System.Collections.Generic;
using System.Text;

namespace PokerChallenge
{
    public enum Hands
    {
        RoyalFlush = 9,
        StraightFlush = 8,
        FourOfAKind = 7,
        FullHouse = 6,
        Flush = 5,
        Straight = 4,        
        ThreeOfAKind = 3,
        TwoPair = 2,
        OnePair = 1,
        HighCard = 0
    }
}
