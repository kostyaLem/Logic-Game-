using NightmareV2.Model;
using NightmareV2.Properties;
using NightmareV2.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NightmareV2.Presenter
{
    public class MainPresenter
    {
        private static Random myRnd = new Random();
        private static TimeSpan time;

        private readonly IMainView _view;

        ChipType[] _keyColumns = new ChipType[3];
        Chip[,] _chipArr = new Chip[Settings.Default.countRow, Settings.Default.countRow];
        int[] _chipCount = { 5, 5, 5 };

        List<Tuple<int, int, int>> availableCells = new List<Tuple<int, int, int>>();
        Tuple<int, int, int> currentBtn;

        public MainPresenter(IMainView mainView)
        {
            _view = mainView ?? throw new ArgumentNullException(nameof(mainView));

            _chipArr.Initialize();

            _view.SetIconsInButton += SetTypesButtons;
            _view.Button_Click += view_Button_Click;
            _view.RestartButton_Click += SetTypesButtons;
        }

        // is too large Method :D
        private void view_Button_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if (time == TimeSpan.Zero) time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                var btnTag = btn.Tag.ToString().Split(' ');
                int x = int.Parse(btnTag[0]); // row
                int y = int.Parse(btnTag[1]); // column
                ChipType chipType = (ChipType)Enum.Parse(typeof(ChipType), btnTag[2]);

                var btns = new List<Tuple<int, int, int>>();
                btns.Add(new Tuple<int, int, int>(x, y, (int)chipType));

                if (currentBtn == null && chipType != ChipType.EmptyBlock)
                    currentBtn = btns.First();
                else if (currentBtn != null && chipType != ChipType.EmptyBlock)
                    currentBtn = btns.First();

                if (!availableCells.Contains(btns.First(), new TupleComparer()) && chipType != ChipType.EmptyBlock)
                {
                    availableCells.Clear();
                    _view.ResetBorderColor();
                    // check other positions
                    if (y - 1 >= 0)
                        if (_chipArr[x, y - 1].ChipType == ChipType.EmptyBlock)
                            btns.Add(new Tuple<int, int, int>(x, y - 1, (int)_chipArr[x, y - 1].ChipType));

                    if (y + 1 <= _chipArr.GetUpperBound(1))
                        if (_chipArr[x, y + 1].ChipType == ChipType.EmptyBlock)
                            btns.Add(new Tuple<int, int, int>(x, y + 1, (int)_chipArr[x, y + 1].ChipType));

                    if (x - 1 >= 0)
                        if (_chipArr[x - 1, y].ChipType == ChipType.EmptyBlock)
                            btns.Add(new Tuple<int, int, int>(x - 1, y, (int)_chipArr[x - 1, y].ChipType));

                    if (x + 1 <= _chipArr.GetUpperBound(0))
                        if (_chipArr[x + 1, y].ChipType == ChipType.EmptyBlock)
                            btns.Add(new Tuple<int, int, int>(x + 1, y, (int)_chipArr[x + 1, y].ChipType));

                    availableCells.AddRange(btns);
                    if (btns.Count == 1)
                        currentBtn = btns.First();

                    _view.SetBackGreenColor(btns);
                }
                else if (availableCells.Contains(btns.First(), new TupleComparer()) && chipType == ChipType.EmptyBlock)
                {
                    availableCells.Clear();
                    ChangePosition(btns.First());

                    _view.ReplaceIcoButtons(currentBtn, btns.First());
                    _view.ResetBorderColor();

                    if (IsFinished())
                    {
                        var interval = (new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) - time);
                        var t = string.Format("{0:D2}:{1:D2}:{2:D2}", interval.Hours, interval.Minutes, interval.Seconds);
                        _view.ShowMessage("Игра пройдена за " + t + "." + Environment.NewLine + "\tУРА!");
                        time = TimeSpan.Zero;
                        _view.ChahgeEnabledBtn();
                    }

                    currentBtn = null;
                }
            }
        }

        private void ChangePosition(Tuple<int, int, int> btn)
        {
            var temp = currentBtn;
            var btn1 = currentBtn;
            var btn2 = btn;

            _chipArr[btn1.Item1, btn1.Item2] = new Chip(btn2.Item1, btn2.Item2, (ChipType)btn2.Item3);
            _chipArr[btn2.Item1, btn2.Item2] = new Chip(temp.Item1, temp.Item2, (ChipType)temp.Item3);
        }

        private bool IsFinished()
        {
            for (int i = 0; i < _keyColumns.Length; i++)
            {
                for (int j = 0; j <= _chipArr.GetUpperBound(0); j++)
                {
                    if (_keyColumns[i] != _chipArr[j, i * 2].ChipType)
                        return false;
                }
            }
            return true;
        }

        private void SetTypesButtons(object sender, EventArgs e)
        {
            var chips = new List<List<Chip>>();
            SetKeyChips();

            for (int i = 0; i <= _chipArr.GetUpperBound(0); i++)
            {
                chips.Add(new List<Chip>());

                for (int j = 0; j <= _chipArr.GetUpperBound(1); j += 2)
                {
                    // block or empty block
                    if (i % 2 == 0 && ((j - 1) == 1 || (j - 1) == 3))
                    {
                        _chipArr[i, j - 1] = new Chip(i, j - 1, ChipType.Block);
                        chips[i].Add(_chipArr[i, j - 1]);
                    }
                    else if (i % 2 != 0 && ((j - 1) == 1 || (j - 1) == 3))
                    {
                        _chipArr[i, j - 1] = new Chip(i, j - 1, ChipType.EmptyBlock);
                        chips[i].Add(_chipArr[i, j - 1]);
                    }

                    // is good chips
                    while (true)
                    {
                        var numChip = myRnd.Next((int)ChipType.Invisibility, (int)ChipType.Speed + 1);
                        if (_chipCount[numChip - 1] > 0)
                        {
                            _chipArr[i, j] = new Chip(i, j, (ChipType)Enum.ToObject(typeof(ChipType), numChip));
                            chips[i].Add(_chipArr[i, j]);

                            _chipCount[numChip - 1]--;
                            break;
                        }
                        else
                            continue;
                    }
                }
            }

            _view.SetKeyImages(_keyColumns);
            _view.SetChipImages(chips.AsEnumerable());
        }

        private void SetKeyChips()
        {
            Array.Clear(_keyColumns, 0, _keyColumns.Length);
            _chipCount = new int[3] { 5, 5, 5 };
            Enumerable.Range(0, 3).Select(x =>
            {
                do
                {
                    var randomType = (ChipType)myRnd.Next((int)ChipType.Invisibility, (int)ChipType.Speed + 1);
                    if (_keyColumns.Contains(randomType))
                        continue;
                    else
                    {
                        _keyColumns[x] = randomType;
                        break;
                    }
                } while (true);
                return _keyColumns[x];
            }).ToList();
        }

        internal IMainView View()
        {
            return _view;
        }
    }
}