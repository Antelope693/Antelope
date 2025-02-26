using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
 
namespace homeWork1._2
{

   

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string Trans(string exp)         // 将中缀表达式转换为后缀表达式
        {
            string postexp = "";
            Stack<char> opor = new Stack<char>(); // 运算符栈
            int i = 0;
            char ch, e;

            while (i < exp.Length)
            {
                ch = exp[i];
                if (ch == '(')
                {
                    opor.Push(ch);
                }
                else if (ch == ')')
                {
                    while (opor.Count > 0 && opor.Peek() != '(')
                    {
                        e = opor.Pop();
                        postexp += e;
                    }
                    opor.Pop(); // 弹出'('
                }
                else if (ch == '+' || ch == '-')
                {
                    while (opor.Count > 0 && opor.Peek() != '(')
                    {
                        e = opor.Pop();
                        postexp += e;
                    }
                    opor.Push(ch);
                }
                else if (ch == '*' || ch == '/')
                {
                    while (opor.Count > 0 && opor.Peek() != '(' &&
                          (opor.Peek() == '*' || opor.Peek() == '/'))
                    {
                        e = opor.Pop();
                        postexp += e;
                    }
                    opor.Push(ch);
                }
                else if (ch == ' ')
                {
                    // 忽略空格
                }
                else if (ch == '=')
                {
                    break; // 遇到等号结束处理
                }
                else // 处理数字
                {
                    string d = "";
                    while (ch >= '0' && ch <= '9')
                    {
                        d += ch;
                        i++;
                        if (i < exp.Length)
                            ch = exp[i];
                        else
                            break;
                    }
                    i--; // 回退一个字符
                    postexp += d + "#"; // 添加数字和分隔符
                }
                i++;
            }

            // 将栈中剩余运算符弹出
            while (opor.Count > 0)
            {
                e = opor.Pop();
                postexp += e;
            }
            return postexp;
        }
        int GetValue(string postexp)       // 计算后缀表达式的值
        {
            Stack<int> opand = new Stack<int>(); // 运算数栈
            int a, b, c, d;
            char ch;
            int i = 0;

            while (i < postexp.Length)
            {
                ch = postexp[i];
                switch (ch)
                {
                    case '+':
                        a = opand.Pop();
                        b = opand.Pop();
                        c = b + a;
                        opand.Push(c);
                        break;
                    case '-':
                        a = opand.Pop();
                        b = opand.Pop();
                        c = b - a;
                        opand.Push(c);
                        break;
                    case '*':
                        a = opand.Pop();
                        b = opand.Pop();
                        c = b * a;
                        opand.Push(c);
                        break;
                    case '/':
                        a = opand.Pop();
                        b = opand.Pop();
                        c = b / a;
                        opand.Push(c);
                        break;
                    default: // 处理数字
                        d = 0;
                        while (ch >= '0' && ch <= '9')
                        {
                            d = 10 * d + (ch - '0');
                            i++;
                            if (i < postexp.Length)
                                ch = postexp[i];
                            else
                                break;
                        }
                        opand.Push(d);
                        break;
                }
                i++;
            }
            return opand.Pop();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            this.textBox1.Text+=("/");
        }

        private void buttonEqual_Click(object sender, EventArgs e)
        {
            string exp= Trans(this.textBox1.Text);
            int result = GetValue(exp);
            this.textBox1.Text=result.ToString();
        }

        private void button0_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("0");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("+");
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("-");
        }

        private void buttonAC_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void buttonCancle_Click(object sender, EventArgs e)
        {
            int lenth = this.textBox1.Text.Length;
            this.textBox1.Text = this.textBox1.Text.Remove(lenth - 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("9");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("8");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("7");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("6");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("5");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("4");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("3");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("1");
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += ("*");
        }
    }
}
