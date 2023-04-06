/*
 In this challenge, you have to establish which kind of Poker combination is present in a deck of five cards. Every card is a string containing the card value
(with the upper-case initial for face cards) and the lower-case initial for suits, as in the examples below:
"Ah" ➞ Ace of hearts
"Ks" ➞ King of spades
"3d" ➞ Three of diamonds
"Qc" ➞ Queen of clubs
"10c" ➞ Ten of clubs

Given an array hand containing five strings being the cards, implement a function that returns a string with the name of the highest combination obtained,
accordingly to the table above.
Examples,
PokerHandRanking({ "10h", "Jh", "Qh", "Ah", "Kh" }) ➞ "Royal Flush"
PokerHandRanking({ "3h", "5h", "Qs", "9h", "Ad" }) ➞ "High Card"
PokerHandRanking({ "10s", "10c", "8d", "10d", "10h" }) ➞ "Four of a Kind"
 
 */
namespace week_3
{
    internal class PokerCombination
    {
        // cardSet is used in -> isFullHouse, ispair
        HashSet<string> cardSet = new HashSet<string>();
        // dict is used in  -> Three of a Kind, Four of a Kind
        Dictionary<string, int> dict = new Dictionary<string, int>();
        //Royal Flush -> A, K, Q, J, 10, all with the Same Suit.
        bool IsRoyalFlush(string[] ranks)
        {
            string[] req_ranks = { "A", "K", "Q", "J", "10" };
            foreach (string rank in ranks)
            {
                if (!req_ranks.Contains(rank))
                {
                    return false;
                }
            }
            return true;
        }

        // Checking if all cards fall under same suit
        bool IsSameSuit(string[] suits)
        {
            string firstValue = suits[0];
            foreach (string suit in suits)
            {
                if (!suit.Equals(firstValue))
                {
                    return false;
                }
            }
            return true;
        }

        //Checking if cards are in sequence
        bool IsSequenced(string[] ranks)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("J", 11);
            dict.Add("Q", 12);
            dict.Add("K", 13);
            dict.Add("A", 14);
            List<int> list = new List<int>();
            for (int i = 0; i < ranks.Length; i++)
            {
                if (dict.ContainsKey(ranks[i]))
                {
                    list.Add(dict[ranks[i]]);
                }
                else
                {
                    list.Add(Convert.ToInt32(ranks[i]));
                }
            }
            list.Sort();
            for (int i = 0; i < 4; i++)
            {
                if (list[i + 1] - list[i] != 1)
                {
                    return false;
                }
            }
            return true;
        }

        //Four of a Kind -> Four cards of the same rank.
        bool IsFourOfAKind()
        {
            foreach (var kvp in dict)
            {
                if (kvp.Value == 4)
                {
                    return true;
                }
            }
            return false;
        }
        // 1 1 1 2 2 -> 2
        // 1 2 -> 2

        //Full House -> Three of a Kind with a Pair.
        bool IsFullHouse()
        {
            return cardSet.Count == 2;
        }

        //Three of a Kind -> Three cards of the same rank.
        bool IsThreeOfAKind(string[] ranks)
        {
            foreach (var kvp in dict)
            {
                if (kvp.Value == 3)
                {
                    return true;
                }
            }
            return false;
        }

        //Two Pair -> Two different Pair. (10h 10c  11h 11c 8c )
        // 10 11 8
        // 1 1 1 2 3
        // 10 - 2, 11-2 , 8 -1
        bool IsTwoPair(string[] ranks)
        {
            //Array.Sort(ranks);
            //if (ranks[0] == ranks[1] && ranks[2] == ranks[3] && ranks[3]!= ranks[4])
            //{
            //    return true;
            //}
            int count = 0;
            foreach (var kvp in dict)
            {
                if (kvp.Value == 2)
                {
                    count++;
                }
            }
            return count == 2;
        }

        //Pair -> Two cards of the same rank.
        // 1 1 2 3 4
        bool IsPair(string[] ranks)
        {
            return cardSet.Count == 4;
        }
        public static void main(string[] args)
        {
            string[] cards = { "10h", "Jh", "Qh", "Ah", "Kh" };
            // 5-4,9-1
            string[] ranks = new string[cards.Length];
            string[] suits = new string[cards.Length];

            for (int i = 0; i < cards.Length; i++)
            {
                string current_card = cards[i];
                ranks[i] = current_card.Substring(0, cards[i].Length - 1);
                suits[i] = current_card.Substring(current_card.Length - 1);
            }

            PokerCombination obj = new PokerCombination();

            // cardSet is used in -> isFullHouse, isThreeofAKind, ispair
            foreach (string rank in ranks)
            {
                obj.cardSet.Add(rank);
            }
            //adding dictionary values
            int count = 0;
            foreach (string i in ranks)
            {
                count = obj.dict.GetValueOrDefault(i, 0);
                if (obj.dict.TryGetValue(i, out int currentAmount))
                {
                    obj.dict[i] = count + 1;
                }
                else
                {
                    obj.dict.Add(i, 1);
                }
            }
            //Royal Flush -> A, K, Q, J, 10, all with the Same Suit.
            if (obj.IsRoyalFlush(ranks) && obj.IsSameSuit(suits))
            {
                Console.WriteLine("RoyalFlush");
            }

            //Straight Flush -> Five cards in sequence, all with the Same Suit.
            else if (obj.IsRoyalFlush(suits) && obj.IsSameSuit(ranks))
            {
                Console.WriteLine("Straight Flush");
            }

            //Four of a Kind -> Four cards of the same rank.
            else if (obj.IsFourOfAKind())
            {
                Console.WriteLine("Four Of A Kind");
            }

            //Full House -> Three of a Kind with a Pair.
            else if (obj.IsFullHouse())
            {
                Console.WriteLine("Full House");
            }

            //Flush -> Any five cards of the Same Suit, not in sequence.
            else if (obj.IsSameSuit(suits))
            {
                Console.WriteLine("Flush");
            }

            //Straight -> Five cards in a sequence, but not of the same suit.
            else if (obj.IsSequenced(ranks))
            {
                Console.WriteLine("Straight");
            }

            //Three of a Kind -> Three cards of the same rank.
            else if (obj.IsThreeOfAKind(ranks))
            {
                Console.WriteLine("Three Of A Kind");
            }

            //Two Pair -> Two different Pair.
            else if (obj.IsTwoPair(ranks))
            {
                Console.WriteLine("Two pair");
            }
            //Pair -> Two cards of the same rank.
            else if (obj.IsPair(ranks))
            {
                Console.WriteLine("Pair");
            }
            //High Card -> No other valid combination
            else
            {
                Console.WriteLine("High Card");
            }
        }

    }
}