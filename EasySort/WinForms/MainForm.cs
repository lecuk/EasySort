using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EasySort.Classes;

namespace EasySort.WinForms
{
    public partial class MainForm : Form
    {
        SortingArray currentArray;
        Controller controller;
        Graphics graph;

        Timer sortStateCheckTimer;
        bool isSortAllowed = false;
        bool areControlsLocked = false;

        object controlLocker = new object();
        object sortLocker = new object();

        const int defaultArraySize = 100;
        readonly double[] delayPresets = { 0, 0.05, 0.1, 0.15, 0.2, 0.3, 0.4, 0.5, 1, 2, 3, 4, 5, 10, 15, 20, 30, 40, 50, 100, 150, 200, 300, 400, 500, 1000 };
        const int defaultTimerInterval = 100;

        readonly List<MenuItem> styleButtons = new List<MenuItem>();
        
        #region Init 

        public MainForm()
        {
            InitializeComponent();

            InitCollections();
            InitObjects();
            InitEvents();
            InitUpdateTimer();
            InitUI();
        }

        void InitCollections()
        {
            foreach (GeneratorAlgorithm generator in GeneratorCollection.All)
            {
                GeneratorCollectionListbox.Items.Add(generator.info.name);
            }

            foreach (SortingAlgorithm sort in SortCollection.All)
            {
                SortCollectionListbox.Items.Add(sort.info.name);
            }
        }

        void InitEvents()
        {
            controller.worker.Finished += UnlockControls;
        }

        void InitUpdateTimer()
        {
            sortStateCheckTimer = new Timer();
            sortStateCheckTimer.Tick += TimerUpdate;
            sortStateCheckTimer.Interval = 100;
            sortStateCheckTimer.Start();
        }

        void InitObjects()
        {
            DrawingStyler.style = DrawingStyle.Default;
            currentArray = new SortingArray(defaultArraySize);
            graph = DisplayBox.CreateGraphics();
            controller = new Controller(graph, currentArray, GetTrackbarDelay());
        }

        void InitUI()
        {
            ArrayLengthNumeric.Value = defaultArraySize;
            SortDelayTrackbar_Scroll(null, null);

            ToolTip SortButtonTooltip = new ToolTip();
            SortButtonTooltip.SetToolTip(GenerateButton, "Generate array with given algorithm, to be allowed to sort.");

            styleButtons.Add(SetDefaultStyleButton);
            styleButtons.Add(SetRainbowStyleButton);
            styleButtons.Add(SetDistanceBasedStyleButton);
            styleButtons.Add(SetMonochromeStyleButton);
            styleButtons.Add(SetCustomStyleButton);

            SetDefaultStyleButton.Checked = true;

            UpdateSortInfo();
        }

        #endregion

        #region Functions

        void TimerUpdate(object sender, EventArgs e)
        {
            UpdateLock();
            UpdateInfoLabel();
        }

        void UpdateLock()
        {
            GenerateOptionsPanel.Enabled = !areControlsLocked;
            StopButton.Enabled = areControlsLocked;

            SortOptionsPanel.Enabled = (isSortAllowed && !areControlsLocked);
        }

        void LockControls()
        {
            lock (controlLocker)
            {
                areControlsLocked = true;
            }
        }

        void UnlockControls()
        {
            lock (controlLocker)
            {
                areControlsLocked = false;
            }
        }

        void ChangeStyle(DrawingStyle newStyle)
        {
            DrawingStyler.style = newStyle;
            controller.UpdateStyleNextFrame(newStyle);

            UpdateGraphNowOrNextFrame();

            foreach (MenuItem button in styleButtons)
            {
                button.Checked = false;
            }
        }

        void ShowSortedMessage()
        {
            MessageBox.Show("Sorted!");
        }
        
        void AllowSort()
        {
            lock (sortLocker)
            {
                isSortAllowed = true;
            }
        }

        void DenySort()
        {
            lock (sortLocker)
            {
                isSortAllowed = false;
            }
        }

        GeneratorAlgorithm CurrentGenerator
        {
            get
            {
                if (GeneratorCollectionListbox.SelectedIndex != -1)
                    return GeneratorCollection.All[GeneratorCollectionListbox.SelectedIndex];
                else
                    return GeneratorCollection.Default;
            }
        }

        SortingAlgorithm CurrentSortType
        {
            get
            {
                if (SortCollectionListbox.SelectedIndex != -1)
                    return SortCollection.All[SortCollectionListbox.SelectedIndex];
                else
                    return SortCollection.Default;
            }
        }

        string CurrentStyleName
        {
            get
            {
                switch(DrawingStyler.style)
                {
                    case DrawingStyle.Default:
                        return "Default";
                    case DrawingStyle.Rainbow:
                        return "Rainbow";
                    case DrawingStyle.DistanceBased:
                        return "Distance-based";
                    case DrawingStyle.Monochrome:
                        return "Monochrome";
                    case DrawingStyle.Custom:
                        return "Custom";
                    default:
                        return "Unknown";
                }
            }
        }

        void UpdateInfoLabel()
        {
            InfoUILabel.Text = $"Array length: {currentArray.Length}   " +
                $"Generator: {CurrentGenerator.info.name}   " +
                $"Sorting algorithm: {CurrentSortType.info.name}   " +
                $"Comparisions: {controller.Comparisions}, Swaps: {controller.Swaps}, Modifies: {controller.Modifies}   " +
                $"Style: {CurrentStyleName}";
        }

        double GetTrackbarDelay()
        {
            return delayPresets[SortDelayTrackbar.Value];
        }

        void AppendArray()
        {
            int size = (int)ArrayLengthNumeric.Value;
            
            if (currentArray == null)
                currentArray = new SortingArray(size);
            else
                currentArray.Recreate(size);
        }

        void StopWorkImmediately()
        {
            controller.worker.StopImmediately();
            UnlockControls();
            DenySort();
        }

        void UpdateGraphNowOrNextFrame()
        {
            if (controller.worker.IsWorking)
            {
                controller.UpdateDrawerDisplaysNextFrame(graph);
            }
            else
            {
                UpdateGraphNow();
            }
        }

        void UpdateGraphNow()
        {
            controller.drawer.UpdateGraphicsNextFrame(graph, DisplayBox.ClientRectangle);
            controller.drawer.Update();
        }

        Color SelectColor()
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.Color;
            else
                return Color.White;
        }

        void UpdateSortInfo()
        {
            SortNameLabel.Text = CurrentSortType.info.name;
            SortURLLabel.Text = CurrentSortType.info.sortInfoURL;
            SortDescriptionLabel.Text = CurrentSortType.info.description +
            $"\n    Minimum time:  { CurrentSortType.info.minTime}" +
            $"\n    Maximum time:  { CurrentSortType.info.maxTime}" ;
        }

        #endregion

        #region Events

        private void DisplayBox_SizeChanged(object sender, EventArgs e)
        {
            graph = DisplayBox.CreateGraphics();
            UpdateGraphNowOrNextFrame();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            AppendArray();
            AllowSort();
            controller.ResetCounters();
            controller.Work(currentArray, CurrentGenerator);
            LockControls();
            UpdateLock();
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            controller.ResetCounters();
            controller.Work(currentArray, CurrentSortType);
            LockControls();
            UpdateLock();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopWorkImmediately();
        }

        private void SortDelayTrackbar_Scroll(object sender, EventArgs e)
        {
            double value = GetTrackbarDelay();
            controller.SetNewDelayNextUpdate(value);
            SortDelayLabel.Text = $"Delay between updates: {value}ms";
        }

        private void SortCollectionListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSortInfo();
        }

        private void GeneratorCollectionListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SortURLLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(SortURLLabel.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopWorkImmediately();
        }

        private void SetDefaultStyleButton_Click(object sender, EventArgs e)
        {
            ChangeStyle(DrawingStyle.Default);
            SetDefaultStyleButton.Checked = true;
        }

        private void SetRainbowStyleButton_Click(object sender, EventArgs e)
        {
            ChangeStyle(DrawingStyle.Rainbow);
            SetRainbowStyleButton.Checked = true;
        }

        private void SetDistanceBasedStyleButton_Click(object sender, EventArgs e)
        {
            ChangeStyle(DrawingStyle.DistanceBased);
            SetDistanceBasedStyleButton.Checked = true;
        }

        private void SetMonochromeStyleButton_Click(object sender, EventArgs e)
        {
            ChangeStyle(DrawingStyle.Monochrome);
            SetMonochromeStyleButton.Checked = true;
        }

        private void SetCustomStyleButton_Click(object sender, EventArgs e)
        {
            ChangeStyle(DrawingStyle.Custom);
            SetCustomStyleButton.Checked = true;
        }

        private void SetCustomDefaultColorButton_Click(object sender, EventArgs e)
        {
            DrawingStyler.CustomDefaultColor = SelectColor();
        }

        private void SetCustomComparedColorButton_Click(object sender, EventArgs e)
        {
            DrawingStyler.CustomSelectedColor = SelectColor();
        }

        private void SetCustomSwappedColorButton_Click(object sender, EventArgs e)
        {
            DrawingStyler.CustomSwappedColor = SelectColor();
        }

        private void SetCustomSpecialColorButton_Click(object sender, EventArgs e)
        {
            DrawingStyler.CustomSpecialColor = SelectColor();
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            HelpForm form = new HelpForm();
            form.Show();
        }

        private void AppInfoButton_Click(object sender, EventArgs e)
        {
            AppInfoForm form = new AppInfoForm();
            form.Show();
        }

        #endregion

    }
}
