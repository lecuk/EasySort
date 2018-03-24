using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasySort.WinForms
{
    public partial class HelpForm : Form
    {
        const string GetStartedInfo = "This program visualises an array of integer numbers as a collection of lines. " +
            "Each line has its place in array, and its height determines its value. But not always those lines stay " +
            "on 'right' place. Sorting algorithms solve this problem and put all lines into correct places. Each " +
            "algorithm works differently, and it influences the effiency of algorithm. You can see how sorting works, " +
            "and compare them." +
            "\n\nWhy do I need this program?\n" +
            "All data needs to be on its proper place. A lot of computer programs use sorting algorithms. But in different " +
            "situation you need different algorithms. So you can compare them and see which is better.";

        const string HowToUseInfo = "Firstly, you should create your array (generate it). You have some different " +
            "presets of generators. Just input size of an array (by default, it will be 100), choose generator algorithm, " +
            "and press 'Generate'. \n\n" +
            "You can actually see in real-time how array is generating. If it is working too slow, or too fast, " +
            "just change delay between updates in the array. Those updates are defined in each algorithm in proper places. " +
            "Or you can stop the process of generating or sorting. But after that, you should re-generate array, because " +
            "working process have been aborted, and array can be in any state. Then you are again allowed to sort.";

        const string SortingAlgorithmsInfo = "In this program sorting algorithms can do these things: " +
            "\n-Compare two pieces of array" +
            "\n-Swap two pieces of array" +
            "\n-Modify directly any piece of array" +
            "\n\nSometimes there are updates occuring. When they are is determined in algorithm itself (almost always " +
            "after some swaps and comparisions). During update changed pieces are redrawn and system pauses for a delay time." +
            "\n\nAll algorithms have minimum and maximum work time. What does it mean? " +
            "An algorithm not always works perfectly on different arrays, and there are best and worst cases for an " +
            "algorithm. For example, 'n log n' min time for merge sort means that if array size is N, time consumed will " +
            "be around 'N log N' units of time.";

        public HelpForm()
        {
            InitializeComponent();
            SetInfoTo_GetStarted();
        }

        void SetInfoTo_GetStarted()
        {
            HelpMainLabel.Text = GetStartedInfo;
        }

        void SetInfoTo_HowToUse()
        {
            HelpMainLabel.Text = HowToUseInfo;
        }

        void SetInfoTo_SortingAlgorithms()
        {
            HelpMainLabel.Text = SortingAlgorithmsInfo;
        }

        private void HelpButton_GetStarted_Click(object sender, EventArgs e)
        {
            SetInfoTo_GetStarted();
        }

        private void HelpButton_HowToUse_Click(object sender, EventArgs e)
        {
            SetInfoTo_HowToUse();
        }

        private void HelpButton_SortingAlgorithms_Click(object sender, EventArgs e)
        {
            SetInfoTo_SortingAlgorithms();
        }
    }
}
