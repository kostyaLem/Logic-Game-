using NightmareV2.Model;
using NightmareV2.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NightmareV2.View
{
    public partial class MainForm : Form, IMainView
    {
        #region IView
        public event EventHandler SetIconsInButton;
        public event EventHandler Button_Click;
        public event EventHandler RestartButton_Click;
        #endregion

        public MainForm()
        {
            InitializeComponent();

            tlsMenu.MouseDown += MouseBtn_Click;
            btnRestart.Click += (p1, p2) => { RestartButton_Click?.Invoke(this, new EventArgs()); GC.Collect(1); };
            btnInfo.Click += BtnInfo_Click;
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Правила: имеется по 5 рун каждого цвета. Необходимо расположить руны вертикально " +
                "в один ряд в соответствии с ключом, заданным в верхней части окна.\n" + Environment.NewLine +
                "Разработчик: Лемдянов К.Ю." + Environment.NewLine +
                "Копия игры Nightmare Realm" + Environment.NewLine +
                "vk.com/netsharp" + Environment.NewLine +
                "github.com/kostyaLem" + Environment.NewLine +
                "kostyaLem@yandex.ru", "Инофрмация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowMessage(string stroke)
        {
            MessageBox.Show(stroke, "Инофрмация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ChahgeEnabledBtn()
        {
            foreach (var control in flowPanel.Controls)
            {
                if (control is Button btn)
                {
                    btn.Enabled = false;
                }
            }
        }

        public void ResetBorderColor()
        {
            foreach (var control in flowPanel.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatAppearance.BorderSize = 0;
                }
            }
        }

        public void ReplaceIcoButtons(Tuple<int, int, int> btn1, Tuple<int, int, int> btn2)
        {
            var button1 = FindButton(btn1);
            var button2 = FindButton(btn2);

            if (button1 != null && button2 != null)
            {
                var tag1 = button1.Tag.ToString().Split(' ');
                var tag2 = button2.Tag.ToString().Split(' ');

                var imgType1 = (ChipType)Enum.Parse(typeof(ChipType), tag1[2]);
                var imgType2 = (ChipType)Enum.Parse(typeof(ChipType), tag2[2]);

                var image1 = (Image)Resources.ResourceManager.GetObject(Enum.GetName(typeof(ChipType), imgType1));
                var image2 = (Image)Resources.ResourceManager.GetObject(Enum.GetName(typeof(ChipType), imgType2));

                button1.BackgroundImage = image2;
                button2.BackgroundImage = image1;

                var tempTag = tag1;
                button1.Tag = tag1[0] + " " + tag1[1] + " " + tag2[2];
                button2.Tag = tag2[0] + " " + tag2[1] + " " + tag1[2];
            }
        }

        Button FindButton(Tuple<int, int, int> button)
        {
            foreach (var control in flowPanel.Controls)
            {
                if (control is Button btn)
                {
                    var btnTag = btn.Tag.ToString().Split(' ');
                    if (int.Parse(btnTag[0]) == button.Item1 && int.Parse(btnTag[1]) == button.Item2)
                        return btn;
                }
            }
            return null;
        }

        public void SetBackGreenColor(IEnumerable<Tuple<int, int, int>> btns)
        {
            if (btns.Count() != 0)
            {
                foreach (var control in flowPanel.Controls)
                {
                    if (control is Button btn)
                    {
                        var tuple = Tuple.Create(
                            int.Parse(btn.Tag.ToString().Split(' ')[0]),
                            int.Parse(btn.Tag.ToString().Split(' ')[1]),
                            int.Parse(btn.Tag.ToString().Split(' ')[2])
                        );

                        if (btns.Contains(tuple, new TupleComparer()))
                        {
                            btn.FlatAppearance.BorderSize = 3;
                            btn.FlatAppearance.BorderColor = Color.DarkSeaGreen;
                        }
                    }
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            Button_Click?.Invoke(sender, e);
        }

        public void SetKeyImages(IEnumerable<ChipType> chips)
        {
            var keyImages = chips.ToList();
            btnKey1.BackgroundImage = (Image)Resources.ResourceManager.GetObject(Enum.GetName(typeof(ChipType), keyImages[0]));
            btnKey2.BackgroundImage = (Image)Resources.ResourceManager.GetObject(Enum.GetName(typeof(ChipType), keyImages[1]));
            btnKey3.BackgroundImage = (Image)Resources.ResourceManager.GetObject(Enum.GetName(typeof(ChipType), keyImages[2]));
        }

        public void SetChipImages(IEnumerable<IEnumerable<Chip>> chips)
        {
            if (chips != null && chips.Count() != 0)
            {
                flowPanel.Controls.Clear();
                foreach (var row in chips)
                {
                    foreach (var chip in row)
                    {
                        var btn = new Button();
                        btn.Width = btn.Height = 100;
                        btn.BackgroundImage = (Image)Resources.ResourceManager.GetObject(Enum.GetName(typeof(ChipType), chip.ChipType));
                        btn.BackgroundImageLayout = ImageLayout.Stretch;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;

                        btn.Tag = chip.Position.Item1 + " " + chip.Position.Item2 + " " + (int)chip.ChipType;
                        if (chip.ChipType == ChipType.Block)
                            btn.Enabled = false;

                        btn.Click += OnButtonClick;
                        flowPanel.Controls.Add(btn);
                    }
                }
            }
        }

        #region ToolStripLogic
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;


        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MouseBtn_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSkipForm_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetIconsInButton?.Invoke(this, new EventArgs());
        }
    }
}