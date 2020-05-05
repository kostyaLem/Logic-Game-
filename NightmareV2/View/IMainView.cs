using NightmareV2.Model;
using System;
using System.Collections.Generic;

namespace NightmareV2.View
{
    public interface IMainView
    {
        event EventHandler SetIconsInButton;
        event EventHandler Button_Click;
        event EventHandler RestartButton_Click;

        void ResetBorderColor();

        void ReplaceIcoButtons(Tuple<int, int, int> btn1, Tuple<int, int, int> btn2);

        void SetBackGreenColor(IEnumerable<Tuple<int, int, int>> btn);

        void SetKeyImages(IEnumerable<ChipType> chips);
        void SetChipImages(IEnumerable<IEnumerable<Chip>> chips);
        void ShowMessage(string v);
        void ChahgeEnabledBtn();
    }
}
