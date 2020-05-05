using System;

namespace NightmareV2.Model
{
    public class Chip
    {
        public Tuple<int, int> Position { get; set; }
        public ChipType ChipType { get; }

        public Chip(int x, int y, ChipType chipType)
        {
            Position = new Tuple<int, int>(x, y);
            ChipType = chipType;
        }
    }
}
