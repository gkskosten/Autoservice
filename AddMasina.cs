// Decompiled with JetBrains decompiler
// Type: AutoService_DB.AddMasina
// Assembly: AutoService DB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 240DB792-C889-40BE-B646-EFC1464AE5EC
// Assembly location: C:\Users\dave\AppData\Local\Apps\2.0\647YKJ4H.GHK\3AWPWZPZ.4JB\auto..tion_30d31642ebe3e3dd_0001.0000_4bc64601c13bfbf9\AutoService DB.exe

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AutoService_DB
{
  public class AddMasina : Form
  {
    public string output = "";
    private IContainer components = (IContainer) null;
    public string[] uid;
    public string[] an;
    public string[] marca;
    public string[] model;
    public string[] serie;
    public string[] motor;
    public string[] kW;
    public string[] categorii;
    private string muid;
    private GroupBox groupBox2;
    private ComboBox serBox;
    private ComboBox motorBox;
    private ComboBox marcaBox;
    private Label label5;
    private ComboBox kwBox;
    private Label label1;
    private ComboBox modelBox;
    private Label label6;
    private Label label4;
    private Label label3;
    private Label label2;
    private ComboBox anBox;
    private Button doneBtn;
    private Button button1;
    private DataGridView dataGridView1;
    private DataGridViewTextBoxColumn p_cod_piesa;
    private DataGridViewTextBoxColumn p_nume_piesa;
    private DataGridViewTextBoxColumn p_pret;
    private DataGridViewTextBoxColumn p_cantitate;
    private DataGridViewComboBoxColumn p_cuid;
    private Label label7;
    private ComboBox comboBox1;
    private Label label8;
    private TextBox textBox1;

    public AddMasina()
    {
      this.InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
    }

    private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
      DataGridView dataGridView = (DataGridView) sender;
      DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell) dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["p_cuid"];
      foreach (string str in this.categorii)
        cell.Items.Add((object) str);
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }

    private void init()
    {
      this.marcaBox.Items.Clear();
      this.modelBox.Items.Clear();
      this.anBox.Items.Clear();
      this.motorBox.Items.Clear();
      this.kwBox.Items.Clear();
      for (int index = 0; index < ((IEnumerable<string>) this.uid).Count<string>(); ++index)
      {
        if (!this.marcaBox.Items.Contains((object) this.marca[index]))
          this.marcaBox.Items.Add((object) this.marca[index]);
        if (!this.modelBox.Items.Contains((object) this.model[index]))
          this.modelBox.Items.Add((object) this.model[index]);
        if (!this.anBox.Items.Contains((object) this.an[index]))
          this.anBox.Items.Add((object) this.an[index]);
        if (!this.motorBox.Items.Contains((object) this.motor[index]))
          this.motorBox.Items.Add((object) this.motor[index]);
        if (!this.kwBox.Items.Contains((object) this.kW[index]))
          this.kwBox.Items.Add((object) this.kW[index]);
        if (!this.serBox.Items.Contains((object) this.serie[index]))
          this.serBox.Items.Add((object) this.serie[index]);
      }
    }

    private void AddMasina_Load(object sender, EventArgs e)
    {
      this.init();
    }

    private void doneBtn_Click(object sender, EventArgs e)
    {
      this.muid = AddMasina.str_rand(32);
      this.output = "INSERT INTO `masina` (`uid`, `marca`, `model`, `an`, `motor`, `kW`, `serie`, `sters`, `cmc`)  VALUES ('" + this.muid + "', '" + this.marcaBox.Text + "', '" + this.modelBox.Text + "', '" + this.anBox.Text + "', '" + this.motorBox.Text + "', '" + this.kwBox.Text + "', '" + this.serBox.Text + "', '0', " + this.comboBox1.Text + "); ";
      if (this.dataGridView1.Rows.Count > 0)
      {
        foreach (DataGridViewRow row in (IEnumerable) this.dataGridView1.Rows)
        {
          string str1 = AddMasina.str_rand(32);
          Thread.Sleep(10);
          string str2 = "";
          if (row.Cells[0].Value == null)
            str2 = " ";
          if (row.Cells[1].Value != null)
            this.output = this.output + string.Format(" INSERT INTO `piese` (`uid`, `pret`, `cod_piesa`, `nume_piesa`, `cantitate`, `status`, `muid`, `cuid`) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'); ", (object) str1, row.Cells[2].Value, (object) str2, row.Cells[1].Value, row.Cells[3].Value, (object) "1", (object) this.muid, row.Cells[4].Value);
        }
      }
      this.Close();
    }

    private static string str_rand(int length)
    {
      Random random = new Random();
      return new string(Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", length).Select<string, char>((Func<string, char>) (s => s[random.Next(s.Length)])).ToArray<char>());
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.groupBox2 = new GroupBox();
      this.dataGridView1 = new DataGridView();
      this.p_cod_piesa = new DataGridViewTextBoxColumn();
      this.p_nume_piesa = new DataGridViewTextBoxColumn();
      this.p_pret = new DataGridViewTextBoxColumn();
      this.p_cantitate = new DataGridViewTextBoxColumn();
      this.p_cuid = new DataGridViewComboBoxColumn();
      this.button1 = new Button();
      this.doneBtn = new Button();
      this.serBox = new ComboBox();
      this.motorBox = new ComboBox();
      this.label8 = new Label();
      this.marcaBox = new ComboBox();
      this.label5 = new Label();
      this.kwBox = new ComboBox();
      this.label1 = new Label();
      this.modelBox = new ComboBox();
      this.label6 = new Label();
      this.label4 = new Label();
      this.label7 = new Label();
      this.label3 = new Label();
      this.comboBox1 = new ComboBox();
      this.label2 = new Label();
      this.anBox = new ComboBox();
      this.textBox1 = new TextBox();
      this.groupBox2.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.groupBox2.Controls.Add((Control) this.textBox1);
      this.groupBox2.Controls.Add((Control) this.dataGridView1);
      this.groupBox2.Controls.Add((Control) this.button1);
      this.groupBox2.Controls.Add((Control) this.doneBtn);
      this.groupBox2.Controls.Add((Control) this.serBox);
      this.groupBox2.Controls.Add((Control) this.motorBox);
      this.groupBox2.Controls.Add((Control) this.label8);
      this.groupBox2.Controls.Add((Control) this.marcaBox);
      this.groupBox2.Controls.Add((Control) this.label5);
      this.groupBox2.Controls.Add((Control) this.kwBox);
      this.groupBox2.Controls.Add((Control) this.label1);
      this.groupBox2.Controls.Add((Control) this.modelBox);
      this.groupBox2.Controls.Add((Control) this.label6);
      this.groupBox2.Controls.Add((Control) this.label4);
      this.groupBox2.Controls.Add((Control) this.label7);
      this.groupBox2.Controls.Add((Control) this.label3);
      this.groupBox2.Controls.Add((Control) this.comboBox1);
      this.groupBox2.Controls.Add((Control) this.label2);
      this.groupBox2.Controls.Add((Control) this.anBox);
      this.groupBox2.Dock = DockStyle.Fill;
      this.groupBox2.Location = new Point(0, 0);
      this.groupBox2.Margin = new Padding(6, 8, 6, 8);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new Padding(6, 8, 6, 8);
      this.groupBox2.Size = new Size(954, 506);
      this.groupBox2.TabIndex = 5;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Cautare dupa:";
      this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.p_cod_piesa, (DataGridViewColumn) this.p_nume_piesa, (DataGridViewColumn) this.p_pret, (DataGridViewColumn) this.p_cantitate, (DataGridViewColumn) this.p_cuid);
      this.dataGridView1.Location = new Point(12, 135);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new Size(930, 319);
      this.dataGridView1.TabIndex = 8;
      this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
      this.dataGridView1.RowEnter += new DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
      this.dataGridView1.RowsAdded += new DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
      this.p_cod_piesa.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.p_cod_piesa.HeaderText = "Cod / Culoare Piesa";
      this.p_cod_piesa.Name = "p_cod_piesa";
      this.p_cod_piesa.Width = 158;
      this.p_nume_piesa.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.p_nume_piesa.HeaderText = "Nume Piesa";
      this.p_nume_piesa.Name = "p_nume_piesa";
      this.p_nume_piesa.Width = 109;
      this.p_pret.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.p_pret.HeaderText = "Pret";
      this.p_pret.Name = "p_pret";
      this.p_pret.Width = 63;
      this.p_cantitate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.p_cantitate.HeaderText = "Cantitate";
      this.p_cantitate.Name = "p_cantitate";
      this.p_cantitate.Width = 99;
      this.p_cuid.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
      this.p_cuid.HeaderText = "Categorie";
      this.p_cuid.Name = "p_cuid";
      this.p_cuid.Width = 84;
      this.button1.Location = new Point(676, 460);
      this.button1.Name = "button1";
      this.button1.Size = new Size(129, 34);
      this.button1.TabIndex = 10;
      this.button1.Text = "Anulare";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.doneBtn.Location = new Point(811, 460);
      this.doneBtn.Name = "doneBtn";
      this.doneBtn.Size = new Size(134, 34);
      this.doneBtn.TabIndex = 11;
      this.doneBtn.Text = "Salvare";
      this.doneBtn.UseVisualStyleBackColor = true;
      this.doneBtn.Click += new EventHandler(this.doneBtn_Click);
      this.serBox.FormattingEnabled = true;
      this.serBox.Location = new Point(72, 65);
      this.serBox.Margin = new Padding(6, 8, 6, 8);
      this.serBox.Name = "serBox";
      this.serBox.Size = new Size(370, 28);
      this.serBox.TabIndex = 2;
      this.motorBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.motorBox.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.motorBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.motorBox.FormattingEnabled = true;
      this.motorBox.Location = new Point(558, 96);
      this.motorBox.Margin = new Padding(6, 8, 6, 8);
      this.motorBox.Name = "motorBox";
      this.motorBox.Size = new Size(170, 28);
      this.motorBox.TabIndex = 6;
      this.label8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label8.AutoSize = true;
      this.label8.Location = new Point(731, 99);
      this.label8.Margin = new Padding(6, 0, 6, 0);
      this.label8.Name = "label8";
      this.label8.Size = new Size(64, 20);
      this.label8.TabIndex = 2;
      this.label8.Text = "Culoare";
      this.marcaBox.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.marcaBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.marcaBox.FormattingEnabled = true;
      this.marcaBox.Location = new Point(72, 35);
      this.marcaBox.Margin = new Padding(6, 8, 6, 8);
      this.marcaBox.Name = "marcaBox";
      this.marcaBox.Size = new Size(370, 28);
      this.marcaBox.TabIndex = 0;
      this.label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label5.AutoSize = true;
      this.label5.Location = new Point(455, 99);
      this.label5.Margin = new Padding(6, 0, 6, 0);
      this.label5.Name = "label5";
      this.label5.Size = new Size(91, 20);
      this.label5.TabIndex = 2;
      this.label5.Text = "Combustibil";
      this.kwBox.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.kwBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.kwBox.FormattingEnabled = true;
      this.kwBox.Location = new Point(72, 96);
      this.kwBox.Margin = new Padding(6, 8, 6, 8);
      this.kwBox.Name = "kwBox";
      this.kwBox.Size = new Size(370, 28);
      this.kwBox.TabIndex = 5;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(7, 43);
      this.label1.Margin = new Padding(6, 0, 6, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(53, 20);
      this.label1.TabIndex = 2;
      this.label1.Text = "Marca";
      this.modelBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.modelBox.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.modelBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.modelBox.FormattingEnabled = true;
      this.modelBox.Location = new Point(558, 35);
      this.modelBox.Margin = new Padding(6, 8, 6, 8);
      this.modelBox.Name = "modelBox";
      this.modelBox.Size = new Size(370, 28);
      this.modelBox.TabIndex = 1;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(14, 68);
      this.label6.Margin = new Padding(6, 0, 6, 0);
      this.label6.Name = "label6";
      this.label6.Size = new Size(46, 20);
      this.label6.TabIndex = 2;
      this.label6.Text = "Serie";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(28, 102);
      this.label4.Margin = new Padding(6, 0, 6, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(32, 20);
      this.label4.TabIndex = 2;
      this.label4.Text = "kW";
      this.label7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(751, 68);
      this.label7.Margin = new Padding(6, 0, 6, 0);
      this.label7.Name = "label7";
      this.label7.Size = new Size(44, 20);
      this.label7.TabIndex = 2;
      this.label7.Text = "CmC";
      this.label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label3.AutoSize = true;
      this.label3.Location = new Point(517, 68);
      this.label3.Margin = new Padding(6, 0, 6, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(29, 20);
      this.label3.TabIndex = 2;
      this.label3.Text = "An";
      this.comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.comboBox1.AutoCompleteMode = AutoCompleteMode.Append;
      this.comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Location = new Point(798, 65);
      this.comboBox1.Margin = new Padding(6, 8, 6, 8);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new Size(130, 28);
      this.comboBox1.TabIndex = 4;
      this.label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.label2.AutoSize = true;
      this.label2.Location = new Point(494, 41);
      this.label2.Margin = new Padding(6, 0, 6, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(52, 20);
      this.label2.TabIndex = 2;
      this.label2.Text = "Model";
      this.anBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.anBox.AutoCompleteMode = AutoCompleteMode.Append;
      this.anBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.anBox.FormattingEnabled = true;
      this.anBox.Location = new Point(558, 65);
      this.anBox.Margin = new Padding(6, 8, 6, 8);
      this.anBox.Name = "anBox";
      this.anBox.Size = new Size(181, 28);
      this.anBox.TabIndex = 3;
      this.textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.textBox1.Location = new Point(798, 96);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new Size(130, 26);
      this.textBox1.TabIndex = 12;
      this.AutoScaleDimensions = new SizeF(9f, 20f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(954, 506);
      this.Controls.Add((Control) this.groupBox2);
      this.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Margin = new Padding(4, 5, 4, 5);
      this.Name = "AddMasina";
      this.Text = "Adaugare masina";
      this.Load += new EventHandler(this.AddMasina_Load);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
