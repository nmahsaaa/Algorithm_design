using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoProject1
{
    public partial class Form2 : Form
    {
        PictureBox[ , ] pbs;
        List<int[]> anses = new List<int[]>();
        List<int[]> types = new List<int[]>();
        int n;
        int current = 0;
        public Form2(int n,int ks , int qs)
        {
            InitializeComponent();
            this.n = n;
            this.Size = new Size(60 * n, 60 * n);
            pbs=new PictureBox[n,n];
            int[] board = new int[n];
            int[] type = new int[n];
            setPieces(board, type, n, qs, ks, 0);
            for(int i=0 ; i<n; i++)
            {
                for(int j=0 ; j<n ; j++)
                {
                    pbs[i, j] = new PictureBox();
                    pbs[i, j].Size = new Size(60, 60);
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            pbs[i, j].BackColor = Color.White;
                        else
                            pbs[i, j].BackColor = Color.Gray;
                    }
                    else
                    {
                        if (j % 2 == 0)
                            pbs[i, j].BackColor = Color.Gray;
                        else
                            pbs[i, j].BackColor = Color.White;
                    }
                    pbs[i, j].Location = new Point(i * 60, j * 60);
                    pbs[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    this.Controls.Add(pbs[i, j]);
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (types[0][i] == 0)
                {
                    int j = anses[0][i];
                    pbs[j, i].Image = Properties.Resources.black_queen_512;
                }
                else
                {
                    int j = anses[0][i];
                    pbs[j, i].Image = Properties.Resources._24034_200;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(pbs[n - 1, n - 1].Right, pbs[n - 1, n - 1].Bottom);
        }
        public void setPieces(int[] board,int [] type, int n, int qCount, int kCount,int i)
        {
            if (i == n)
            {
                int[] ans = new int[n];
                for (int k = 0; k < n; k++)
                    ans[k] = board[k];
                int[] ansT = new int[n];
                for (int k = 0; k < n; k++)
                    ansT[k] = type[k];
                anses.Add(ans);
                types.Add(ansT);
                return;
            }
            if (qCount != 0)
            {
                for(int j=0 ; j<n ; j++)
                {
                    if (promissing(j, i, board, type,0))
                    {
                        board[i] = j;
                        type[i] = 0;
                        setPieces(board, type, n, qCount-1, kCount, i+1);
                    }
                }
            }
            if(kCount!=0)
            {
                for (int j = 0; j < n; j++)
                {
                    if (promissing(j, i, board, type,1))
                    {
                        board[i] = j;
                        type[i] = 1;
                        setPieces(board, type, n, qCount, kCount-1, i + 1);
                    }
                }
            }
        }
        public bool promissing(int j,int i, int[] board,int[] type,int newType)
        {
            for (int k = 0; k < i; k++)
            {
                if (type[k] == 0)
                {
                    if (j == board[k])
                        return false;
                    if (Math.Abs(j - board[k]) == Math.Abs(i - k))
                        return false;
                }
                else
                {
                    int[] moves = { -1, 2, -1, -2, 1, 2, 1, -2, -2, 1, -2, -1, 2, 1, 2, -1 };
                    for (int k2 = 0; k2 < moves.Length; k2 = k2 + 2)
                    {
                        if (k == i + moves[k2] && board[k] == j + moves[k2 + 1])
                            return false;
                    }
                }
                if (newType == 0)
                {
                    if (j == board[k])
                        return false;
                    if (Math.Abs(j - board[k]) == Math.Abs(i - k))
                        return false;
                }
                else if (newType == 1)
                {
                    int[] moves = { -1, 2, -1, -2, 1, 2, 1, -2, -2, 1, -2, -1, 2, 1, 2, -1 };
                    for (int k2 = 0; k2 < moves.Length; k2 = k2 + 2)
                    {
                        if (k == i + moves[k2] && board[k] == j + moves[k2 + 1])
                            return false;
                    }
                }
            }
            return true;
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                current++;
                if (current == anses.Count)
                    current--;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        pbs[i, j].Image = null;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (types[current][i] == 0)
                    {
                        int j = anses[current][i];
                        pbs[j, i].Image = Properties.Resources.black_queen_512;
                    }
                    else
                    {
                        int j = anses[current][i];
                        pbs[j, i].Image = Properties.Resources._24034_200;
                    }
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                current--;
                if (current == -1)
                    current++;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        pbs[i, j].Image = null;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    if (types[current][i] == 0)
                    {
                        int j = anses[current][i];
                        pbs[j, i].Image = Properties.Resources.black_queen_512;
                    }
                    else
                    {
                        int j = anses[current][i];
                        pbs[j, i].Image = Properties.Resources._24034_200;
                    }
                }
            }
        }
    }
}
