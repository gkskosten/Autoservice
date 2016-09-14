// Decompiled with JetBrains decompiler
// Type: AutoService_DB.Form1
// Assembly: AutoService DB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 240DB792-C889-40BE-B646-EFC1464AE5EC
// Assembly location: C:\Users\dave\AppData\Local\Apps\2.0\647YKJ4H.GHK\3AWPWZPZ.4JB\auto..tion_30d31642ebe3e3dd_0001.0000_4bc64601c13bfbf9\AutoService DB.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AutoService_DB
{
  public class Form1 : Form
  {
    private Masini masini = new Masini();
    private Piese piese = new Piese();
    private IContainer components = (IContainer) null;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem meniuToolStripMenuItem;
    private ToolStripMenuItem conectareToolStripMenuItem;
    private ToolStripMenuItem iesireToolStripMenuItem;
    private ComboBox marcaBox;
    private Label label1;
    private ComboBox modelBox;
    private Label label2;
    private ComboBox anBox;
    private Label label3;
    private GroupBox gb1;
    private Panel panel1;
    private ToolStripMenuItem masiniToolStripMenuItem;
    private ToolStripMenuItem adaugareToolStripMenuItem;
    private GroupBox groupBox1;
    private Panel panel2;
    private GroupBox groupBox2;
    private ComboBox motorBox;
    private Label label5;
    private ComboBox kwBox;
    private Label label4;
    private ListView listView1;
    private ColumnHeader marcaCol;
    private ColumnHeader modelCol;
    private ColumnHeader anCol;
    private ColumnHeader kWCol;
    private ColumnHeader serieCol;
    private ColumnHeader uidCol;
    private ColumnHeader motorCol;
    private ListView listView2;
    private ColumnHeader pUidCol;
    private ColumnHeader nume_piesaCol;
    private ColumnHeader pPretCol;
    private ColumnHeader cod_piesaCol;
    private ColumnHeader cantCol;
    private ColumnHeader statCol;
    private SplitContainer splitContainer1;
    private ColumnHeader carCol;
    private ContextMenuStrip meniuMasini;
    private ToolStripMenuItem stergeToolStripMenuItem;
    private ComboBox cmcBox;
    private Label label7;
    private ComboBox comboBox2;
    private Label label8;
    private SplitContainer splitContainer2;
    private GroupBox groupBox3;
    private ComboBox comboBox3;
    private Label label9;

    public Form1()
    {
      this.InitializeComponent();
      this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      this.masini.Dispose();
    }

    private void init()
    {
      this.listView1.MultiSelect = false;
      this.listView2.MultiSelect = false;
      this.piese.categorii();
      this.listView1.Items.Clear();
      this.listView2.Items.Clear();
      this.masini.init();
      this.marcaBox.Items.Clear();
      this.modelBox.Items.Clear();
      this.anBox.Items.Clear();
      this.motorBox.Items.Clear();
      this.kwBox.Items.Clear();
      this.listView1.DoubleClick += new EventHandler(this.ListView1_DoubleClick);
      this.listView1.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.ListView1_ItemSelectionChanged);
      for (int index = 0; index < this.masini.count; ++index)
      {
        if (!this.marcaBox.Items.Contains((object) this.masini.marca[index]))
          this.marcaBox.Items.Add((object) this.masini.marca[index]);
        if (!this.modelBox.Items.Contains((object) this.masini.model[index]))
          this.modelBox.Items.Add((object) this.masini.model[index]);
        if (!this.anBox.Items.Contains((object) this.masini.an[index]))
          this.anBox.Items.Add((object) this.masini.an[index]);
        if (!this.motorBox.Items.Contains((object) this.masini.motor[index]))
          this.motorBox.Items.Add((object) this.masini.motor[index]);
        if (!this.kwBox.Items.Contains((object) this.masini.kW[index]))
          this.kwBox.Items.Add((object) this.masini.kW[index]);
        if (!this.cmcBox.Items.Contains((object) this.masini.cmc[index]))
          this.cmcBox.Items.Add((object) this.masini.cmc[index]);
        this.listView1.Items.Add(new ListViewItem(new string[7]
        {
          this.masini.marca[index],
          this.masini.model[index],
          this.masini.an[index],
          this.masini.kW[index],
          this.masini.serie[index],
          this.masini.uid[index],
          this.masini.motor[index]
        }));
      }
      this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
      this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
      this.listView1.FullRowSelect = true;
      this.listView1.Columns[5].Width = 0;
    }

    private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      if (this.listView1.SelectedItems.Count > 0)
        this.listView1.ContextMenuStrip = this.meniuMasini;
      else
        this.listView1.ContextMenuStrip = (ContextMenuStrip) null;
    }

    private void ListView1_DoubleClick(object sender, EventArgs e)
    {
      this.piese.select(((ListView) sender).SelectedItems[0].SubItems[5].Text);
      this.afisarePiese();
    }

    private void afisareMasini(List<string>[] inlist)
    {
      this.listView1.Items.Clear();
      for (int index = 0; index < ((IEnumerable<List<string>>) inlist).Count<List<string>>(); ++index)
        this.listView1.Items.Add(new ListViewItem(new string[7]
        {
          inlist[index][1],
          inlist[index][2],
          inlist[index][3],
          inlist[index][5],
          inlist[index][6],
          inlist[index][0],
          inlist[index][4]
        }));
      this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
      this.listView1.Columns[5].Width = 0;
    }

    private void afisarePiese(List<string>[] inlist)
    {
      this.listView2.Items.Clear();
      for (int index = 0; index < ((IEnumerable<List<string>>) inlist).Count<List<string>>(); ++index)
      {
        if (inlist[index] != null)
        {
          ListViewItem listViewItem = new ListViewItem(new string[7]
          {
            inlist[index][0],
            inlist[index][1],
            inlist[index][7],
            inlist[index][2],
            inlist[index][3],
            inlist[index][4],
            inlist[index][5]
          });
          listViewItem.BackColor = !(listViewItem.SubItems[5].Text == "In stoc") ? Color.FromArgb(244, 41, 65) : Color.LightGreen;
          this.listView2.Items.Add(listViewItem);
        }
      }
      this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
      this.listView2.FullRowSelect = true;
      this.listView2.Columns[0].Width = 0;
    }

    private void afisarePiese()
    {
      this.listView2.Items.Clear();
      for (int index = 0; index < this.piese.count; ++index)
      {
        ListViewItem listViewItem = new ListViewItem(new string[7]
        {
          this.piese.uid[index],
          this.piese.cod_piesa[index],
          this.piese.pret[index],
          this.piese.nume_piesa[index],
          this.piese.cantitate[index],
          this.piese.status[index],
          this.piese.muid[index]
        });
        listViewItem.BackColor = !(listViewItem.SubItems[5].Text == "In stoc") ? Color.FromArgb(244, 41, 65) : Color.LightGreen;
        this.listView2.Items.Add(listViewItem);
      }
      this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
      this.listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
      this.listView2.FullRowSelect = true;
      this.listView2.Columns[0].Width = 0;
    }

    private void afisarePiesaIndiv(object sender, EventArgs e)
    {
      Button button = (Button) sender;
      int num = (int) MessageBox.Show("piesaaaa");
      this.piese.piesa(button.Name);
    }

    private void conectareToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.init();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.init();
    }

    private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.masini.Dispose();
      Application.ExitThread();
      Application.Exit();
    }

    private void adaugareToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AddMasina addMasina = new AddMasina();
      addMasina.uid = this.masini.uid;
      addMasina.an = this.masini.an;
      addMasina.model = this.masini.model;
      addMasina.marca = this.masini.marca;
      addMasina.serie = this.masini.serie;
      addMasina.motor = this.masini.motor;
      addMasina.kW = this.masini.kW;
      addMasina.categorii = this.piese.categorii();
      int num = (int) addMasina.ShowDialog();
      if (!this.masini.insert(addMasina.output))
        return;
      this.init();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.afisareMasini(this.masini.gasite("marca", ((Control) sender).Text));
      this.modelBox.Text = "<model>";
      this.anBox.Text = "<an>";
      this.kwBox.Text = "<kW>";
      this.motorBox.Text = "<motor>";
    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.afisareMasini(this.masini.gasite("model", ((Control) sender).Text));
      this.marcaBox.Text = "<marca>";
      this.anBox.Text = "<an>";
      this.kwBox.Text = "<kW>";
      this.motorBox.Text = "<motor>";
    }

    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.afisareMasini(this.masini.gasite("an", ((Control) sender).Text));
      this.marcaBox.Text = "<marca>";
      this.modelBox.Text = "<model>";
      this.kwBox.Text = "<kW>";
      this.motorBox.Text = "<motor>";
    }

    private void motorBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.afisareMasini(this.masini.gasite("motor", ((Control) sender).Text));
      this.marcaBox.Text = "<marca>";
      this.modelBox.Text = "<model>";
      this.kwBox.Text = "<kW>";
      this.anBox.Text = "<an>";
    }

    private void kwBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.afisareMasini(this.masini.gasite("kw", ((Control) sender).Text));
      this.piese.gasite("kw", ((Control) sender).Text);
      this.marcaBox.Text = "<marca>";
      this.modelBox.Text = "<model>";
      this.anBox.Text = "<an>";
      this.motorBox.Text = "<motor>";
    }

    private void catBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.afisarePiese(this.piese.gasite("categorie", ((Control) sender).Text));
      this.marcaBox.Text = "<marca>";
      this.modelBox.Text = "<model>";
      this.anBox.Text = "<an>";
      this.motorBox.Text = "<motor>";
      this.kwBox.Text = "<kW>";
      this.comboBox2.Text = "";
    }

    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
    }

    private void cmcBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.afisareMasini(this.masini.gasite("cmc", ((Control) sender).Text));
      this.marcaBox.Text = "<marca>";
      this.modelBox.Text = "<model>";
      this.kwBox.Text = "<kW>";
      this.anBox.Text = "<an>";
    }

    private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
    {
    }

    private void comboBox2_TextChanged(object sender, EventArgs e)
    {
      this.afisarePiese(this.piese.gasite("cod", ((Control) sender).Text));
      this.marcaBox.Text = "<marca>";
      this.modelBox.Text = "<model>";
      this.anBox.Text = "<an>";
      this.motorBox.Text = "<motor>";
      this.kwBox.Text = "<kW>";
    }

    private void comboBox3_TextChanged(object sender, EventArgs e)
    {
      this.afisarePiese(this.piese.gasite("nume", ((Control) sender).Text));
      this.marcaBox.Text = "<marca>";
      this.modelBox.Text = "<model>";
      this.anBox.Text = "<an>";
      this.motorBox.Text = "<motor>";
      this.kwBox.Text = "<kW>";
    }

    private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        ListViewItem selectedItem = this.listView1.SelectedItems[0];
        if (MessageBox.Show(string.Format("Sigur vrei sa stergi masina {0} {1}?", (object) selectedItem.SubItems[0].Text, (object) selectedItem.SubItems[1].Text), "Stergere masina?", MessageBoxButtons.OKCancel) != DialogResult.OK)
          return;
        if (this.masini.delete(selectedItem.SubItems[5].Text))
        {
          int num = (int) MessageBox.Show(string.Format("{0} {1} stearsa cu succes", (object) selectedItem.SubItems[0].Text, (object) selectedItem.SubItems[1].Text));
        }
        this.init();
      }
      catch
      {
      }
    }

    private void listView2_DoubleClick(object sender, EventArgs e)
    {
      ListView listView = (ListView) sender;
      ListViewItem selectedItem = listView.SelectedItems[0];
      string text = listView.SelectedItems[0].SubItems[0].Text;
      Form2 form2 = new Form2();
      form2.cant = int.Parse(selectedItem.SubItems[4].Text);
      form2.cod = selectedItem.SubItems[1].Text;
      form2.nume = selectedItem.SubItems[3].Text;
      form2.uid = text;
      int num1 = (int) form2.ShowDialog();
      if (!this.piese.execute(form2.output))
        return;
      int num2 = (int) MessageBox.Show("Operatiune executata cu succes");
      this.init();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.menuStrip1 = new MenuStrip();
      this.meniuToolStripMenuItem = new ToolStripMenuItem();
      this.conectareToolStripMenuItem = new ToolStripMenuItem();
      this.iesireToolStripMenuItem = new ToolStripMenuItem();
      this.masiniToolStripMenuItem = new ToolStripMenuItem();
      this.adaugareToolStripMenuItem = new ToolStripMenuItem();
      this.marcaBox = new ComboBox();
      this.label1 = new Label();
      this.modelBox = new ComboBox();
      this.label2 = new Label();
      this.anBox = new ComboBox();
      this.label3 = new Label();
      this.gb1 = new GroupBox();
      this.panel1 = new Panel();
      this.listView1 = new ListView();
      this.marcaCol = new ColumnHeader();
      this.modelCol = new ColumnHeader();
      this.anCol = new ColumnHeader();
      this.kWCol = new ColumnHeader();
      this.serieCol = new ColumnHeader();
      this.uidCol = new ColumnHeader();
      this.motorCol = new ColumnHeader();
      this.meniuMasini = new ContextMenuStrip(this.components);
      this.stergeToolStripMenuItem = new ToolStripMenuItem();
      this.groupBox1 = new GroupBox();
      this.panel2 = new Panel();
      this.listView2 = new ListView();
      this.pUidCol = new ColumnHeader();
      this.cod_piesaCol = new ColumnHeader();
      this.pPretCol = new ColumnHeader();
      this.nume_piesaCol = new ColumnHeader();
      this.cantCol = new ColumnHeader();
      this.statCol = new ColumnHeader();
      this.carCol = new ColumnHeader();
      this.groupBox2 = new GroupBox();
      this.cmcBox = new ComboBox();
      this.motorBox = new ComboBox();
      this.label7 = new Label();
      this.label5 = new Label();
      this.kwBox = new ComboBox();
      this.label4 = new Label();
      this.comboBox2 = new ComboBox();
      this.label8 = new Label();
      this.splitContainer1 = new SplitContainer();
      this.splitContainer2 = new SplitContainer();
      this.groupBox3 = new GroupBox();
      this.comboBox3 = new ComboBox();
      this.label9 = new Label();
      this.menuStrip1.SuspendLayout();
      this.gb1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.meniuMasini.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.splitContainer1.BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      this.splitContainer2.BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      this.menuStrip1.Font = new Font("Segoe UI", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.menuStrip1.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.meniuToolStripMenuItem,
        (ToolStripItem) this.masiniToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new Padding(9, 3, 0, 3);
      this.menuStrip1.Size = new Size(1146, 31);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      this.meniuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.conectareToolStripMenuItem,
        (ToolStripItem) this.iesireToolStripMenuItem
      });
      this.meniuToolStripMenuItem.Name = "meniuToolStripMenuItem";
      this.meniuToolStripMenuItem.Size = new Size(66, 25);
      this.meniuToolStripMenuItem.Text = "M&eniu";
      this.conectareToolStripMenuItem.Name = "conectareToolStripMenuItem";
      this.conectareToolStripMenuItem.Size = new Size(174, 26);
      this.conectareToolStripMenuItem.Text = "&Conectare";
      this.conectareToolStripMenuItem.Click += new EventHandler(this.conectareToolStripMenuItem_Click);
      this.iesireToolStripMenuItem.Name = "iesireToolStripMenuItem";
      this.iesireToolStripMenuItem.ShortcutKeys = Keys.F4 | Keys.Alt;
      this.iesireToolStripMenuItem.Size = new Size(174, 26);
      this.iesireToolStripMenuItem.Text = "&Iesire";
      this.iesireToolStripMenuItem.Click += new EventHandler(this.iesireToolStripMenuItem_Click);
      this.masiniToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.adaugareToolStripMenuItem
      });
      this.masiniToolStripMenuItem.Name = "masiniToolStripMenuItem";
      this.masiniToolStripMenuItem.Size = new Size(68, 25);
      this.masiniToolStripMenuItem.Text = "&Masini";
      this.adaugareToolStripMenuItem.Name = "adaugareToolStripMenuItem";
      this.adaugareToolStripMenuItem.Size = new Size(147, 26);
      this.adaugareToolStripMenuItem.Text = "&Adaugare";
      this.adaugareToolStripMenuItem.Click += new EventHandler(this.adaugareToolStripMenuItem_Click);
      this.marcaBox.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.marcaBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.marcaBox.FormattingEnabled = true;
      this.marcaBox.Location = new Point(72, 29);
      this.marcaBox.Margin = new Padding(4, 5, 4, 5);
      this.marcaBox.Name = "marcaBox";
      this.marcaBox.Size = new Size(248, 28);
      this.marcaBox.TabIndex = 0;
      this.marcaBox.Text = "<marca>";
      this.marcaBox.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(8, 34);
      this.label1.Margin = new Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new Size(53, 20);
      this.label1.TabIndex = 2;
      this.label1.Text = "Marca";
      this.modelBox.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.modelBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.modelBox.FormattingEnabled = true;
      this.modelBox.Location = new Point(388, 29);
      this.modelBox.Margin = new Padding(4, 5, 4, 5);
      this.modelBox.Name = "modelBox";
      this.modelBox.Size = new Size(248, 28);
      this.modelBox.TabIndex = 1;
      this.modelBox.Text = "<model>";
      this.modelBox.SelectedIndexChanged += new EventHandler(this.comboBox2_SelectedIndexChanged);
      this.label2.AutoSize = true;
      this.label2.Location = new Point(328, 34);
      this.label2.Margin = new Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new Size(52, 20);
      this.label2.TabIndex = 2;
      this.label2.Text = "Model";
      this.anBox.AutoCompleteMode = AutoCompleteMode.Append;
      this.anBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.anBox.FormattingEnabled = true;
      this.anBox.Location = new Point(72, 60);
      this.anBox.Margin = new Padding(4, 5, 4, 5);
      this.anBox.Name = "anBox";
      this.anBox.Size = new Size(96, 28);
      this.anBox.TabIndex = 2;
      this.anBox.Text = "<an>";
      this.anBox.SelectedIndexChanged += new EventHandler(this.comboBox3_SelectedIndexChanged);
      this.label3.AutoSize = true;
      this.label3.Location = new Point(34, 65);
      this.label3.Margin = new Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new Size(29, 20);
      this.label3.TabIndex = 2;
      this.label3.Text = "An";
      this.gb1.Controls.Add((Control) this.panel1);
      this.gb1.Dock = DockStyle.Fill;
      this.gb1.Location = new Point(0, 0);
      this.gb1.Margin = new Padding(4, 5, 4, 5);
      this.gb1.Name = "gb1";
      this.gb1.Padding = new Padding(4, 5, 4, 5);
      this.gb1.Size = new Size(1146, 237);
      this.gb1.TabIndex = 3;
      this.gb1.TabStop = false;
      this.gb1.Text = "Masini";
      this.panel1.Controls.Add((Control) this.listView1);
      this.panel1.Dock = DockStyle.Fill;
      this.panel1.Location = new Point(4, 24);
      this.panel1.Margin = new Padding(4, 5, 4, 5);
      this.panel1.Name = "panel1";
      this.panel1.Size = new Size(1138, 208);
      this.panel1.TabIndex = 4;
      this.listView1.Columns.AddRange(new ColumnHeader[7]
      {
        this.marcaCol,
        this.modelCol,
        this.anCol,
        this.kWCol,
        this.serieCol,
        this.uidCol,
        this.motorCol
      });
      this.listView1.ContextMenuStrip = this.meniuMasini;
      this.listView1.Dock = DockStyle.Fill;
      this.listView1.Location = new Point(0, 0);
      this.listView1.Margin = new Padding(4, 5, 4, 5);
      this.listView1.Name = "listView1";
      this.listView1.Size = new Size(1138, 208);
      this.listView1.TabIndex = 20;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.Details;
      this.marcaCol.Text = "Marca";
      this.modelCol.Text = "Model";
      this.anCol.Text = "An";
      this.kWCol.Text = "kW";
      this.serieCol.Text = "Serie";
      this.uidCol.Text = "Cod Unic";
      this.uidCol.Width = 0;
      this.motorCol.Text = "Motor";
      this.meniuMasini.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.stergeToolStripMenuItem
      });
      this.meniuMasini.Name = "contextMenuStrip1";
      this.meniuMasini.Size = new Size(108, 26);
      this.stergeToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.stergeToolStripMenuItem.Name = "stergeToolStripMenuItem";
      this.stergeToolStripMenuItem.Size = new Size(107, 22);
      this.stergeToolStripMenuItem.Text = "Sterge";
      this.stergeToolStripMenuItem.Click += new EventHandler(this.stergeToolStripMenuItem_Click);
      this.groupBox1.Controls.Add((Control) this.panel2);
      this.groupBox1.Dock = DockStyle.Fill;
      this.groupBox1.Location = new Point(0, 0);
      this.groupBox1.Margin = new Padding(4, 5, 4, 5);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new Padding(4, 5, 4, 5);
      this.groupBox1.Size = new Size(1146, 231);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Piese";
      this.panel2.Controls.Add((Control) this.listView2);
      this.panel2.Dock = DockStyle.Fill;
      this.panel2.Location = new Point(4, 24);
      this.panel2.Margin = new Padding(4, 5, 4, 5);
      this.panel2.Name = "panel2";
      this.panel2.Size = new Size(1138, 202);
      this.panel2.TabIndex = 4;
      this.listView2.Columns.AddRange(new ColumnHeader[7]
      {
        this.pUidCol,
        this.cod_piesaCol,
        this.pPretCol,
        this.nume_piesaCol,
        this.cantCol,
        this.statCol,
        this.carCol
      });
      this.listView2.Dock = DockStyle.Fill;
      this.listView2.Location = new Point(0, 0);
      this.listView2.Margin = new Padding(4, 5, 4, 5);
      this.listView2.Name = "listView2";
      this.listView2.Size = new Size(1138, 202);
      this.listView2.TabIndex = 21;
      this.listView2.UseCompatibleStateImageBehavior = false;
      this.listView2.View = View.Details;
      this.listView2.DoubleClick += new EventHandler(this.listView2_DoubleClick);
      this.pUidCol.Text = "Id";
      this.pUidCol.Width = 0;
      this.cod_piesaCol.Text = "Cod";
      this.pPretCol.Text = "Pret";
      this.nume_piesaCol.Text = "Piesa";
      this.cantCol.Text = "Cantitate";
      this.statCol.Text = "Status";
      this.carCol.Text = "Masina";
      this.groupBox2.Controls.Add((Control) this.cmcBox);
      this.groupBox2.Controls.Add((Control) this.motorBox);
      this.groupBox2.Controls.Add((Control) this.marcaBox);
      this.groupBox2.Controls.Add((Control) this.label7);
      this.groupBox2.Controls.Add((Control) this.label5);
      this.groupBox2.Controls.Add((Control) this.kwBox);
      this.groupBox2.Controls.Add((Control) this.label1);
      this.groupBox2.Controls.Add((Control) this.modelBox);
      this.groupBox2.Controls.Add((Control) this.label4);
      this.groupBox2.Controls.Add((Control) this.label3);
      this.groupBox2.Controls.Add((Control) this.label2);
      this.groupBox2.Controls.Add((Control) this.anBox);
      this.groupBox2.Dock = DockStyle.Fill;
      this.groupBox2.Location = new Point(0, 0);
      this.groupBox2.Margin = new Padding(4, 5, 4, 5);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Padding = new Padding(4, 5, 4, 5);
      this.groupBox2.Size = new Size(719, 106);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Cautare masini:";
      this.cmcBox.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.cmcBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.cmcBox.FormattingEnabled = true;
      this.cmcBox.Location = new Point(228, 60);
      this.cmcBox.Margin = new Padding(4, 5, 4, 5);
      this.cmcBox.Name = "cmcBox";
      this.cmcBox.Size = new Size(109, 28);
      this.cmcBox.TabIndex = 3;
      this.cmcBox.Text = "<cmc>";
      this.cmcBox.SelectedIndexChanged += new EventHandler(this.cmcBox_SelectedIndexChanged);
      this.motorBox.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.motorBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.motorBox.FormattingEnabled = true;
      this.motorBox.Location = new Point(584, 62);
      this.motorBox.Margin = new Padding(4, 5, 4, 5);
      this.motorBox.Name = "motorBox";
      this.motorBox.Size = new Size((int) sbyte.MaxValue, 28);
      this.motorBox.TabIndex = 5;
      this.motorBox.Text = "<motor>";
      this.motorBox.SelectedIndexChanged += new EventHandler(this.motorBox_SelectedIndexChanged);
      this.label7.AutoSize = true;
      this.label7.Location = new Point(176, 63);
      this.label7.Margin = new Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new Size(44, 20);
      this.label7.TabIndex = 2;
      this.label7.Text = "CmC";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(485, 65);
      this.label5.Margin = new Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new Size(91, 20);
      this.label5.TabIndex = 2;
      this.label5.Text = "Combustibil";
      this.kwBox.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.kwBox.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.kwBox.FormattingEnabled = true;
      this.kwBox.Location = new Point(389, 60);
      this.kwBox.Margin = new Padding(4, 5, 4, 5);
      this.kwBox.Name = "kwBox";
      this.kwBox.Size = new Size(88, 28);
      this.kwBox.TabIndex = 4;
      this.kwBox.Text = "<kW>";
      this.kwBox.SelectedIndexChanged += new EventHandler(this.kwBox_SelectedIndexChanged);
      this.label4.AutoSize = true;
      this.label4.Location = new Point(345, 64);
      this.label4.Margin = new Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new Size(32, 20);
      this.label4.TabIndex = 2;
      this.label4.Text = "kW";
      this.comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
      this.comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
      this.comboBox2.FormattingEnabled = true;
      this.comboBox2.Location = new Point(112, 29);
      this.comboBox2.Margin = new Padding(4, 5, 4, 5);
      this.comboBox2.Name = "comboBox2";
      this.comboBox2.Size = new Size(298, 28);
      this.comboBox2.TabIndex = 6;
      this.comboBox2.SelectedIndexChanged += new EventHandler(this.comboBox2_SelectedIndexChanged_1);
      this.comboBox2.TextChanged += new EventHandler(this.comboBox2_TextChanged);
      this.label8.AutoSize = true;
      this.label8.Location = new Point(7, 34);
      this.label8.Margin = new Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new Size(97, 20);
      this.label8.TabIndex = 2;
      this.label8.Text = "Cod/Culoare";
      this.splitContainer1.Dock = DockStyle.Fill;
      this.splitContainer1.Location = new Point(0, 137);
      this.splitContainer1.Margin = new Padding(4, 5, 4, 5);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = Orientation.Horizontal;
      this.splitContainer1.Panel1.Controls.Add((Control) this.gb1);
      this.splitContainer1.Panel2.Controls.Add((Control) this.groupBox1);
      this.splitContainer1.Size = new Size(1146, 474);
      this.splitContainer1.SplitterDistance = 237;
      this.splitContainer1.SplitterWidth = 6;
      this.splitContainer1.TabIndex = 5;
      this.splitContainer2.Dock = DockStyle.Top;
      this.splitContainer2.Location = new Point(0, 31);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Panel1.Controls.Add((Control) this.groupBox2);
      this.splitContainer2.Panel2.Controls.Add((Control) this.groupBox3);
      this.splitContainer2.Size = new Size(1146, 106);
      this.splitContainer2.SplitterDistance = 719;
      this.splitContainer2.TabIndex = 8;
      this.groupBox3.Controls.Add((Control) this.comboBox3);
      this.groupBox3.Controls.Add((Control) this.label8);
      this.groupBox3.Controls.Add((Control) this.comboBox2);
      this.groupBox3.Controls.Add((Control) this.label9);
      this.groupBox3.Dock = DockStyle.Fill;
      this.groupBox3.Location = new Point(0, 0);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new Size(423, 106);
      this.groupBox3.TabIndex = 0;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Cautare piese:";
      this.comboBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.comboBox3.FormattingEnabled = true;
      this.comboBox3.Location = new Point(112, 60);
      this.comboBox3.Margin = new Padding(4, 5, 4, 5);
      this.comboBox3.Name = "comboBox3";
      this.comboBox3.Size = new Size(298, 28);
      this.comboBox3.TabIndex = 7;
      this.comboBox3.TextChanged += new EventHandler(this.comboBox3_TextChanged);
      this.label9.AutoSize = true;
      this.label9.Location = new Point(52, 63);
      this.label9.Margin = new Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new Size(51, 20);
      this.label9.TabIndex = 2;
      this.label9.Text = "Nume";
      this.AutoScaleDimensions = new SizeF(9f, 20f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1146, 611);
      this.Controls.Add((Control) this.splitContainer1);
      this.Controls.Add((Control) this.splitContainer2);
      this.Controls.Add((Control) this.menuStrip1);
      this.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new Padding(4, 5, 4, 5);
      this.Name = "Form1";
      this.Text = "Baza de date pentru service auto";
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.gb1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.meniuMasini.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      this.splitContainer1.EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.EndInit();
      this.splitContainer2.ResumeLayout(false);
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
