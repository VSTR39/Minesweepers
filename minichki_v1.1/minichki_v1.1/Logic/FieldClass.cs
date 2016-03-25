using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using minichki_v1._1.View;
using minichki_v1._1.Logic;
using minichki_v1._1.Properties;

namespace minichki_v1._1.Logic
{
   

    class FieldClass
    {
        public  const int  MAXSQUER = 16; 

        protected Button[,] fields = new Button[15, 15];
        protected int[,] fieldsArr = new int[15, 15];
        public int countDownWin = 0;
        protected Panel panel;
        public int mines;
        Label l;
        public FieldClass(Panel _panel,Label lbl)
        {
            l = lbl;
            panel = _panel;
            panel.Enabled = true;
            mines = 14;
            countDownWin = 0;
            Graphics board = panel.CreateGraphics();
            board.Clear(SystemColors.Control);
            
            SolidBrush brush = new SolidBrush(Color.Black);
            Pen pen = new Pen(brush);
            int i = 0, j = 0, x = 0, y = 0;
            for (i = 0; i < 450; i = i + 30)
            {
                for (j = 0; j < 450; j = j + 30)
                {
                    x = i / 30;
                    y = j / 30;
                    board.DrawRectangle(pen, i, j, 30, 30);
                    fieldsArr[x, y] = 0;
                    Button btn = new Button();
                    btn.Location = new System.Drawing.Point(i, j);
                    btn.Name = x.ToString() + y.ToString();
                    btn.Size = new System.Drawing.Size(29, 29);
                    btn.Text = "";
                    btn.UseVisualStyleBackColor = true;
                    btn.Enabled = true;
                    btn.Click += new EventHandler(Click);
                    btn.MouseDown += new MouseEventHandler(Disarm);
                    fields[x, y] = btn;
                    // fields[x, y].Enabled = true;
                    panel.Controls.Add(fields[x, y]);

                }


            }
            fieldsArr = placeMines(fieldsArr);

        }

        private int[,] placeMines(int[,] array)
        {
            Random rand = new Random();
            int[,] arr = array;
            int countMines = 0, x, y;
            while (countMines < 15)
            {
                x = rand.Next(0, 13);
                y = rand.Next(0, 13);

                if (arr[x, y] != -1)
                {
                    arr[x, y] = -1;
                    if (x == 0 && y == 0)
                    {
                        if (arr[x, y + 1] != -1) arr[x, y + 1]++;
                        if (arr[x + 1, y + 1] != -1) arr[x + 1, y + 1]++;
                        if (arr[x + 1, y] != -1) arr[x + 1, y]++;
                    }

                    else if (x == 0 && y != 0)
                    {
                        if (arr[x + 1, y + 1] != -1) arr[x + 1, y + 1]++;
                        if (arr[x, y + 1] != -1) arr[x, y + 1]++;
                        if (arr[x + 1, y] != -1) arr[x + 1, y]++;
                        if (arr[x, y - 1] != -1) arr[x, y - 1]++;
                        if (arr[x + 1, y - 1] != -1) arr[x + 1, y - 1]++;
                    }
                    else if (x != 0 && y == 0)
                    {
                        if (arr[x - 1, y] != -1) arr[x - 1, y]++;
                        if (arr[x + 1, y] != -1) arr[x + 1, y]++;
                        if (arr[x - 1, y + 1] != -1) arr[x - 1, y + 1]++;
                        if (arr[x + 1, y + 1] != -1) arr[x + 1, y + 1]++;
                        if (arr[x, y + 1] != -1) arr[x, y + 1]++;
                    }
                    else if (x != 0 && y != 0)
                    {
                        if (arr[x + 1, y + 1] != -1) arr[x + 1, y + 1]++;
                        if (arr[x, y + 1] != -1) arr[x, y + 1]++;
                        if (arr[x + 1, y] != -1) arr[x + 1, y]++;
                        if (arr[x, y - 1] != -1) arr[x, y - 1]++;
                        if (arr[x + 1, y - 1] != -1) arr[x + 1, y - 1]++;
                        if (arr[x - 1, y] != -1) arr[x - 1, y]++;
                        if (arr[x + 1, y] != -1) arr[x + 1, y]++;
                        if (arr[x - 1, y + 1] != -1) arr[x - 1, y + 1]++;
                    }
                }
                countMines++;

            }
            verifyMines(array);
            return arr;

        }

        private void verifyMines(int[,] array) {
            int[,] arr = array;
            int x = 0, y = 0;
            int mines=0; 
            for (x = 0; x < 13; x++)
            {
                for (y = 0; y < 13; y++)
                {
                    if (x > 0 && y > 0)
                    {
                        if (arr[x + 1, y + 1] == -1) mines++;
                        if (arr[x, y + 1] == -1) mines++;
                        if (arr[x + 1, y] == -1) mines++;
                        if (arr[x, y - 1] == -1) mines++;
                        if (arr[x + 1, y - 1] == -1) mines++;
                        if (arr[x - 1, y] == -1) mines++;
                        if (arr[x + 1, y] == -1) mines++;
                        if (arr[x - 1, y + 1] == -1) mines++;
                        if (!(arr[x, y] == mines) && arr[x,y]!=-1)arr[x, y] = mines;
                        
                    }
                    mines = 0;
                }
            }
        }
       public void  FieldsColor (int x, int y ){
                        if (fieldsArr[x, y] == 0)
                                    {
                                        fields[x, y].BackColor = SystemColors.ControlLight;
                                        fields[x, y].FlatStyle = FlatStyle.Flat;
                                        fields[x, y].Enabled = false;

                                    }
                                    else
                                    {
                                        switchColors(x, y);
                                    } 
        }
        private void Click(object sender, System.EventArgs e) // da se mahnat povtoreniqta v otdelen funkciq koqto da se izpolzva vseki pyt
        {
            Button btn = (Button)sender;
            Point pt = btn.Location;
            int x = pt.X / 30, y = pt.Y / 30;

            if (fieldsArr[x, y] == 0)
            {
                x = pt.X / 30;
                y = pt.Y / 30;


                while (fieldsArr[x, y] != -1 && x < MAXSQUER && y < MAXSQUER)
                {

                    FieldsColor(x, y);
                    x++;
                    if (x == 15 || y == 15) break;

                }

                x = pt.X / 30;
                y = pt.Y / 30;
                while (fieldsArr[x, y] != -1 && x < MAXSQUER && y < MAXSQUER)
                {
                    FieldsColor(x, y);
                    x++;
                    y++;
                    if (x == 15 || y == 15) break;
                }
                x = pt.X / 30;
                y = pt.Y / 30;


                while (fieldsArr[x, y] != -1 && x < MAXSQUER && y < MAXSQUER) // consts
                {
                    FieldsColor(x, y);
                    y++;
                    if (x == 15 || y == 15) break;
                }
                x = pt.X / 30;
                y = pt.Y / 30;
                while (fieldsArr[x, y] != -1 && x > 0 && y > 0)
                {
                    FieldsColor(x, y);
                    x--;
                    if (x < 0 || y < 0) break;

                }

                x = pt.X / 30;
                y = pt.Y / 30;
                while (fieldsArr[x, y] != -1 && x > 0 && y > 0)
                {
                    FieldsColor(x, y);
                    x--;
                    y--;
                    if (x < 0 || y < 0) break;
                }


                x = pt.X / 30;
                y = pt.Y / 30;
                while (fieldsArr[x, y] != -1 && x > 0 && y > 0)
                {
                    FieldsColor(x, y);
                    y--;
                    if (x < 0 || y < 0) break;
                }

            }
            else if (fieldsArr[x, y] == -1)
            {
                MessageBox.Show("You Lose!!", "Game Over");
                panel.Enabled = false;

            }
            else
            {
                switchColors(x, y);

            }


           

        }
        private void switchColors(int x, int y)
        {
            switch (fieldsArr[x, y])
            {
                case 1:
                    fields[x, y].Text = fieldsArr[x, y].ToString();
                    fields[x, y].ForeColor = Color.Blue;
                    break;
                case 2:
                    fields[x, y].Text = fieldsArr[x, y].ToString();
                    fields[x, y].ForeColor = Color.Green;
                    break;
                case 3:
                    fields[x, y].Text = fieldsArr[x, y].ToString();
                    fields[x, y].ForeColor = Color.Red;
                    break;
                case 4:
                    fields[x, y].Text = fieldsArr[x, y].ToString();
                    fields[x, y].ForeColor = Color.DarkBlue;
                    break;
                case 5:
                    fields[x, y].Text = fieldsArr[x, y].ToString();
                    fields[x, y].ForeColor = Color.DarkRed;
                    break;
                case 6:
                    fields[x, y].Text = fieldsArr[x, y].ToString();
                    fields[x, y].ForeColor = Color.LightBlue;
                    break;
                case 7:
                    fields[x, y].Text = fieldsArr[x, y].ToString();
                    fields[x, y].ForeColor = Color.Orange;
                    break;
                case 8:
                    fields[x, y].Text = fieldsArr[x, y].ToString();
                    fields[x, y].ForeColor = Color.Ivory;
                    break;
            }
        }
        private void Disarm(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            
            Point pt = btn.Location;
            int x = pt.X / 30, y = pt.Y / 30;
            checkVictory(countDownWin);
            if (fieldsArr[x, y] == -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
            {   

                countDownWin++;
                fields[x, y].BackColor = Color.Orange;
                mines--;
            }
            else
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right && fields[x, y].BackColor != Color.Orange) { fields[x, y].BackColor = Color.Orange; mines--; }
                else
                {
                    fields[x, y].BackColor = SystemColors.Control; mines++;
                }
            }

            l.Text = mines.ToString();
        }
        public void checkVictory(int x)
        {
            if (x == 14) MessageBox.Show("You WInn!!", "Victory");
           // panel.Enabled = false;

        }

    }
}
