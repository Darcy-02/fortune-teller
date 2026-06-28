using System;
using System.Collections.Generic;

namespace FortuneCookies
{
    /// <summary>Cracks open a fortune cookie and returns literary quotes and colours by lucky number.</summary>
    public class FortuneCookie
    {
        private static readonly Dictionary<int, string[]> Fortunes = new Dictionary<int, string[]>
        {
            { 1,  new[] { "Camus",       "In the midst of winter, I found there was, within me, an invincible summer." } },
            { 2,  new[] { "Dostoevsky",  "Pain and suffering are always inevitable for a large intelligence and a deep heart." } },
            { 3,  new[] { "Nietzsche",   "He who has a why to live can bear almost any how." } },
            { 4,  new[] { "Baldwin",     "Not everything that is faced can be changed, but nothing can be changed until it is faced." } },
            { 5,  new[] { "Camus",       "You will never be happy if you continue to search for what happiness consists of." } },
            { 6,  new[] { "Dostoevsky",  "The soul is healed by being with children." } },
            { 7,  new[] { "Nietzsche",   "Without music, life would be a mistake." } },
            { 8,  new[] { "Baldwin",     "I imagine one of the reasons people cling to their hates so stubbornly is because they sense, once hate is gone, they will be forced to deal with pain." } },
            { 9,  new[] { "Camus",       "The only way to deal with an unfree world is to become so absolutely free that your very existence is an act of rebellion." } },
            { 10, new[] { "Dostoevsky",  "To love someone means to see them as God intended them." } },
            { 11, new[] { "Nietzsche",   "That which does not kill us makes us stronger." } },
            { 12, new[] { "Baldwin",     "Children have never been very good at listening to their elders, but they have never failed to imitate them." } },
            { 13, new[] { "Camus",       "The absurd is the essential concept and the first truth." } },
            { 14, new[] { "Dostoevsky",  "Much unhappiness has come into the world because of bewilderment and things left unsaid." } },
            { 15, new[] { "Nietzsche",   "The higher we soar, the smaller we appear to those who cannot fly." } },
            { 16, new[] { "Baldwin",     "Love takes off the masks that we fear we cannot live without and know we cannot live within." } },
            { 17, new[] { "Camus",       "Man is the only creature who refuses to be what he is." } },
            { 18, new[] { "Dostoevsky",  "To live without Hope is to Cease to live." } },
            { 19, new[] { "Nietzsche",   "One must still have chaos in oneself to be able to give birth to a dancing star." } },
            { 20, new[] { "Baldwin",     "The most dangerous creation of any society is the man who has nothing to lose." } },
        };

        private static readonly Dictionary<int, string> Colors = new Dictionary<int, string>
        {
            { 1, "Red" }, { 2, "Orange" }, { 3, "Yellow" }, { 4, "Green" },
            { 5, "Teal" }, { 6, "Cyan" },  { 7, "Blue" },  { 8, "Indigo" },
            { 9, "Violet" }, { 10, "Gold" }
        };

        /// <summary>Returns a literary quote for the given lucky number.</summary>
        public string GetFortune(int luckyNumber)
        {
            return Fortunes[NormaliseFortuneKey(luckyNumber)][1];
        }

        /// <summary>Returns the author of the quote for the given lucky number.</summary>
        public string GetAuthor(int luckyNumber)
        {
            return Fortunes[NormaliseFortuneKey(luckyNumber)][0];
        }

        /// <summary>Returns a lucky colour for the given lucky number.</summary>
        public string GetLuckyColor(int luckyNumber)
        {
            return Colors[NormaliseColorKey(luckyNumber)];
        }

        /// <summary>Cracks open the full fortune cookie and returns all fields.</summary>
        public string CrackOpen(int luckyNumber)
        {
            return
                "============================\n" +
                "Quote:\n" +
                "\"" + GetFortune(luckyNumber) + "\"\n" +
                "  — " + GetAuthor(luckyNumber) + "\n" +
                "Lucky Number:\n" +
                luckyNumber + "\n" +
                "Lucky Color:\n" +
                GetLuckyColor(luckyNumber) + "\n" +
                "----------------------------";
        }

        private static int NormaliseFortuneKey(int luckyNumber)
        {
            if (luckyNumber <= 0)
                throw new ArgumentOutOfRangeException("luckyNumber", "Lucky number must be positive.");
            return ((luckyNumber - 1) % 20) + 1;
        }

        private static int NormaliseColorKey(int luckyNumber)
        {
            if (luckyNumber <= 0)
                throw new ArgumentOutOfRangeException("luckyNumber", "Lucky number must be positive.");
            return ((luckyNumber - 1) % 10) + 1;
        }
    }
}