// Decompiled with JetBrains decompiler
// Type: AutoService_DB.Piese
// Assembly: AutoService DB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 240DB792-C889-40BE-B646-EFC1464AE5EC
// Assembly location: C:\Users\dave\AppData\Local\Apps\2.0\647YKJ4H.GHK\3AWPWZPZ.4JB\auto..tion_30d31642ebe3e3dd_0001.0000_4bc64601c13bfbf9\AutoService DB.exe

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AutoService_DB
{
  public class Piese
  {
    private MySqlConnection dbConn = new MySqlConnection("Persist Security Info=False;server=localhost;database=autoservice;uid=root;password=");
    public string[] uid;
    public string[] cod_piesa;
    public string[] nume_piesa;
    public string[] cantitate;
    public string[] status;
    public string[] muid;
    public string[] cuid;
    public string[] pret;
    public int count;
    private MySqlCommand cmd;
    private MySqlDataReader reader;

    public string[] categorii()
    {
      this.cmd = this.dbConn.CreateCommand();
      try
      {
        this.dbConn.Open();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Erro" + (object) ex);
      }
      this.cmd.CommandText = "SELECT count(`uid`) from `piese_categorii`";
      this.reader = this.cmd.ExecuteReader();
      this.reader.Read();
      int length = int.Parse(this.reader[0].ToString());
      this.cmd.CommandText = string.Format("SELECT * from piese_categorii");
      this.reader.Close();
      this.reader = this.cmd.ExecuteReader();
      string[] strArray = new string[length];
      int index = 0;
      while (this.reader.Read())
      {
        strArray[index] = this.reader["nume"].ToString();
        ++index;
      }
      this.reader.Close();
      this.dbConn.Close();
      return strArray;
    }

    public void select(string nmuid)
    {
      this.cmd = this.dbConn.CreateCommand();
      try
      {
        this.dbConn.Open();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Erro" + (object) ex);
      }
      this.cmd.CommandText = string.Format("SELECT count(`piese`.pret) FROM `piese` INNER JOIN `masina` on `masina`.`uid` = `piese`.`muid` WHERE `masina`.`uid` = '{0}' and `sters` = 0;", (object) nmuid);
      this.reader = this.cmd.ExecuteReader();
      this.reader.Read();
      this.count = int.Parse(this.reader[0].ToString());
      this.uid = new string[this.count];
      this.cod_piesa = new string[this.count];
      this.nume_piesa = new string[this.count];
      this.cantitate = new string[this.count];
      this.status = new string[this.count];
      this.muid = new string[this.count];
      this.cuid = new string[this.count];
      this.pret = new string[this.count];
      this.cmd.CommandText = string.Format("SELECT `piese`.uid, `piese`.pret as Pret, piese.cod_piesa as `Cod`, nume_piesa as `Nume`, cantitate as `Cant`, status as `Disponibil`, CONCAT(`masina`.`marca`,' ',`masina`.`model`,' - ',`masina`.`an`,' - ',`masina`.`serie`) as `Masina`, `masina`.`motor` AS `Motor Masina` FROM `piese` INNER JOIN `masina` on `masina`.`uid` = `piese`.`muid` WHERE `masina`.`uid` = '{0}' and `sters` = 0;", (object) nmuid);
      this.reader.Close();
      this.reader = this.cmd.ExecuteReader();
      int index = 0;
      while (this.reader.Read())
      {
        this.uid[index] = this.reader["uid"].ToString();
        this.cod_piesa[index] = this.reader["Cod"].ToString();
        this.nume_piesa[index] = this.reader["Nume"].ToString();
        this.cantitate[index] = this.reader["Cant"].ToString();
        this.status[index] = !(this.reader["Cant"].ToString() == "0") ? "In stoc" : "Indisponibil";
        this.muid[index] = this.reader["Masina"].ToString();
        this.pret[index] = this.reader["Pret"].ToString();
        ++index;
      }
      this.reader.Close();
      this.dbConn.Close();
    }

    public string[] piesa(string id)
    {
      if (id == null || id == "" || id.Length < 32 || id.Length != 32)
        return (string[]) null;
      try
      {
        this.dbConn.Open();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Erro" + (object) ex);
      }
      this.cmd.CommandText = string.Format("SELECT * from `piese` where uid = '{0}'", (object) id);
      this.reader = this.cmd.ExecuteReader();
      this.reader.Read();
      string[] strArray = new string[7]
      {
        this.reader[0].ToString(),
        this.reader[1].ToString(),
        this.reader[2].ToString(),
        this.reader[3].ToString(),
        this.reader[4].ToString(),
        this.reader[5].ToString(),
        this.reader[6].ToString()
      };
      this.dbConn.Close();
      this.reader.Close();
      return strArray;
    }

    public bool execute(string input)
    {
      try
      {
        if (input.Contains("<") && input.Contains(">") || input == "" || input == null)
          return false;
        try
        {
          this.dbConn.Open();
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Error" + (object) ex);
          return false;
        }
        this.cmd.CommandText = string.Format(input);
        this.cmd.ExecuteNonQuery();
        this.dbConn.Close();
      }
      catch
      {
        return false;
      }
      return true;
    }

    public List<string>[] gasite(string type, string input)
    {
      try
      {
        this.dbConn.Open();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Erro" + (object) ex);
      }
      this.dbConn.CreateCommand();
      string lower = type.ToLower();
      if (!(lower == "categorie"))
      {
        if (!(lower == "cod"))
        {
          if (lower == "nume")
            this.cmd.CommandText = string.Format("SELECT `piese`.`cuid`, `piese`.uid, `piese`.pret as Pret, piese.cod_piesa as `Cod`, nume_piesa as `Nume`, cantitate as `Cant`, status as `Disponibil`, CONCAT(`masina`.`marca`,' ',`masina`.`model`,' - ',`masina`.`an`,' - ',`masina`.`serie`) as `Masina`, `masina`.`motor` AS `Motor Masina` FROM `piese` INNER JOIN `masina` on `masina`.`uid` = `piese`.`muid` WHERE `piese`.`nume_piesa` LIKE '%{0}%' and `sters` = 0;", (object) input);
        }
        else
          this.cmd.CommandText = string.Format("SELECT `piese`.`cuid`, `piese`.uid, `piese`.pret as Pret, piese.cod_piesa as `Cod`, nume_piesa as `Nume`, cantitate as `Cant`, status as `Disponibil`, CONCAT(`masina`.`marca`,' ',`masina`.`model`,' - ',`masina`.`an`,' - ',`masina`.`serie`) as `Masina`, `masina`.`motor` AS `Motor Masina` FROM `piese` INNER JOIN `masina` on `masina`.`uid` = `piese`.`muid` WHERE `piese`.`cod_piesa` LIKE '%{0}%' and `sters` = 0;", (object) input);
      }
      else
        this.cmd.CommandText = string.Format("SELECT `piese`.`cuid`, `piese`.uid, `piese`.pret as Pret, piese.cod_piesa as `Cod`, nume_piesa as `Nume`, cantitate as `Cant`, status as `Disponibil`, CONCAT(`masina`.`marca`,' ',`masina`.`model`,' - ',`masina`.`an`,' - ',`masina`.`serie`) as `Masina`, `masina`.`motor` AS `Motor Masina` FROM `piese` INNER JOIN `masina` on `masina`.`uid` = `piese`.`muid` WHERE `piese`.`cuid` = '{0}' and `sters` = 0;", (object) input);
      this.reader = this.cmd.ExecuteReader();
      List<string>[] stringListArray = new List<string>[500];
      int index = 0;
      while (this.reader.Read())
      {
        List<string> stringList = new List<string>();
        stringList.Add(this.reader["uid"].ToString());
        stringList.Add(this.reader["Cod"].ToString());
        stringList.Add(this.reader["Nume"].ToString());
        stringList.Add(this.reader["Cant"].ToString());
        if (this.reader["Cant"].ToString() == "0")
          stringList.Add("Indisponibil");
        else
          stringList.Add("In stoc");
        stringList.Add(this.reader["Masina"].ToString());
        stringList.Add(this.reader["cuid"].ToString());
        stringList.Add(this.reader["Pret"].ToString());
        stringListArray[index] = stringList;
        ++index;
      }
      this.dbConn.Close();
      this.reader.Close();
      return stringListArray;
    }
  }
}
