// Decompiled with JetBrains decompiler
// Type: AutoService_DB.Form2
// Assembly: AutoService DB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 240DB792-C889-40BE-B646-EFC1464AE5EC
// Assembly location: C:\Users\dave\AppData\Local\Apps\2.0\647YKJ4H.GHK\3AWPWZPZ.4JB\auto..tion_30d31642ebe3e3dd_0001.0000_4bc64601c13bfbf9\AutoService DB.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AutoService_DB
{
  public class Form2 : Form
  {
    private IContainer components = (IContainer) null;
    public string nume;
    public string cod;
    public string uid;
    public string output;
    public int cant;
    private Button button1;
    private Button button2;
    private NumericUpDown cantnum;
    private Button button3;
    private Label numelbl;
    private Label codlbl;

    public Form2()
    {
      this.InitializeComponent();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.output = string.Format("UPDATE `piese` set `cantitate` = {0} WHERE `uid` = '{1}'", (object) (this.cant + (int) this.cantnum.Value), (object) this.uid);
      this.Close();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      int num1 = this.cant - (int) this.cantnum.Value;
      if (num1 < 0)
      {
        int num2 = (int) MessageBox.Show("Nu sunt suficiente piese in stoc");
      }
      else if (this.cant == num1)
      {
        int num3 = (int) MessageBox.Show("Nu s-a vandut nicio piesa");
      }
      else
      {
        this.output = string.Format("UPDATE `piese` set `cantitate` = {0} WHERE `uid` = '{1}'", (object) num1, (object) this.uid);
        this.Close();
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.output = string.Format("DELETE from `piese` WHERE `uid` = '{0}'", (object) this.uid);
      this.Close();
    }

    private void Form2_Load(object sender, EventArgs e)
    {
      this.numelbl.Text = string.Format("Nume: {0}", (object) this.nume);
      this.codlbl.Text = string.Format("Cod: {0}", (object) this.cod);
      this.cantnum.Value = (Decimal) this.cant;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.button1 = new Button();
      this.button2 = new Button();
      this.cantnum = new NumericUpDown();
      this.button3 = new Button();
      this.numelbl = new Label();
      this.codlbl = new Label();
      this.cantnum.BeginInit();
      this.SuspendLayout();
      this.button1.Location = new Point(12, 132);
      this.button1.Margin = new Padding(4, 5, 4, 5);
      this.button1.Name = "button1";
      this.button1.Size = new Size(112, 35);
      this.button1.TabIndex = 1;
      this.button1.Text = "Vanzare";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.Location = new Point(132, 132);
      this.button2.Margin = new Padding(4, 5, 4, 5);
      this.button2.Name = "button2";
      this.button2.Size = new Size(95, 35);
      this.button2.TabIndex = 1;
      this.button2.Text = "Eliminare";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new EventHandler(this.button2_Click);
      this.cantnum.Font = new Font("Microsoft Sans Serif", 18f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.cantnum.Location = new Point(25, 75);
      NumericUpDown cantnum1 = this.cantnum;
      int[] bits1 = new int[4];
      bits1[0] = (int) byte.MaxValue;
      Decimal num1 = new Decimal(bits1);
      cantnum1.Maximum = num1;
      this.cantnum.Name = "cantnum";
      this.cantnum.Size = new Size(309, 35);
      this.cantnum.TabIndex = 2;
      this.cantnum.TextAlign = HorizontalAlignment.Center;
      NumericUpDown cantnum2 = this.cantnum;
      int[] bits2 = new int[4];
      bits2[0] = 1;
      Decimal num2 = new Decimal(bits2);
      cantnum2.Value = num2;
      this.button3.Location = new Point(235, 132);
      this.button3.Margin = new Padding(4, 5, 4, 5);
      this.button3.Name = "button3";
      this.button3.Size = new Size(112, 35);
      this.button3.TabIndex = 1;
      this.button3.Text = "Adaugare";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button3_Click);
      this.numelbl.AutoSize = true;
      this.numelbl.Location = new Point(21, 23);
      this.numelbl.Name = "numelbl";
      this.numelbl.Size = new Size(133, 20);
      this.numelbl.TabIndex = 3;
      this.numelbl.Text = "Nume piesa..........";
      this.codlbl.AutoSize = true;
      this.codlbl.Location = new Point(21, 43);
      this.codlbl.Name = "codlbl";
      this.codlbl.Size = new Size(120, 20);
      this.codlbl.TabIndex = 3;
      this.codlbl.Text = "Cod piesa..........";
      this.AutoScaleDimensions = new SizeF(9f, 20f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(358, 181);
      this.Controls.Add((Control) this.codlbl);
      this.Controls.Add((Control) this.numelbl);
      this.Controls.Add((Control) this.cantnum);
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button1);
      this.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Margin = new Padding(4, 5, 4, 5);
      this.Name = "Form2";
      this.Text = "Form2";
      this.Load += new EventHandler(this.Form2_Load);
      this.cantnum.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
