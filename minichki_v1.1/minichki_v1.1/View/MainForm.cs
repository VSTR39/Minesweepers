using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using minichki_v1._1.Logic;

namespace minichki_v1._1.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Text == "Start")
            {
                panel.Controls.Clear();
                FieldClass field = new FieldClass(panel,mines_count);
                
            }

        }

    }
}
