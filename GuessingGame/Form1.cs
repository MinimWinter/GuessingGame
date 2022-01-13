using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BuildGrid();
        }

        private const int BLOCK_WIDTH = 100;
        private const int BLOCK_HEIGHT = 100;
        private List<Label> labels = new List<Label>();
        private Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void BuildGrid()
        {
            int labelIndex = 1;
            for(int i = 0; i < this.Height; i += BLOCK_HEIGHT)
            {
                for (int j = 0; j < this.Width; j += BLOCK_WIDTH)
                {
                    Label lbl = new Label();
                    lbl.Location = new Point(j, i);
                    lbl.AutoSize = false;
                    lbl.Size = new Size(BLOCK_WIDTH, BLOCK_HEIGHT);
                    lbl.Text = labelIndex.ToString();
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Click += lbl_Click;
                    labelIndex++;
                    this.Controls.Add(lbl);
                    this.labels.Add(lbl);
                }
            }
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            if ((sender is Label) == false)
            {
                throw new ArgumentException("Unexpected type of sender");
            }
            Label lbl = (Label)sender;
            lbl.Visible = false;
        }

        private void tmrLabelHide_Tick(object sender, EventArgs e)
        {
            int index = random.Next(0, this.labels.Count);
            Label lbl = this.labels[index];
            lbl.Visible = false;
            this.labels.RemoveAt(index);
            //this.labels.Remove(lbl);
            if (this.labels.Count == 0) this.tmrLabelHide.Enabled = false;
        }
    }
}
