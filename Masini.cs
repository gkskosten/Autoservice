// Decompiled with JetBrains decompiler
// Type: AutoService_DB.Masini
// Assembly: AutoService DB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 240DB792-C889-40BE-B646-EFC1464AE5EC
// Assembly location: C:\Users\dave\AppData\Local\Apps\2.0\647YKJ4H.GHK\3AWPWZPZ.4JB\auto..tion_30d31642ebe3e3dd_0001.0000_4bc64601c13bfbf9\AutoService DB.exe

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoService_DB
{
  public class Masini
  {
    private MySqlConnection dbConn = new MySqlConnection("Persist Security Info=False;server=localhost;database=autoservice;uid=root;password=");
    public string[] uid;
    public string[] an;
    public string[] marca;
    public string[] model;
    public string[] serie;
    public string[] motor;
    public string[] kW;
    public string[] cmc;
    public int count;
    private MySqlCommand cmd;
    private MySqlDataReader reader;

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
      MySqlCommand command = this.dbConn.CreateCommand();
      string lower = type.ToLower();
      if (!(lower == "marca"))
      {
        if (!(lower == "model"))
        {
          if (!(lower == "an"))
          {
            if (!(lower == "motor"))
            {
              if (!(lower == "kw"))
              {
                if (lower == "cmc")
                {
                  this.cmd.CommandText = string.Format("SELECT * from masina where cmc = {0} and `sters` = 0", (object) input);
                  command.CommandText = string.Format("SELECT count(`uid`) from masina where cmc = {0} and `sters` = 0", (object) input);
                }
              }
              else
              {
                this.cmd.CommandText = string.Format("SELECT * from masina where kW = '{0}' and `sters` = 0", (object) input);
                command.CommandText = string.Format("SELECT count(`uid`) from masina where kW = '{0}' and `sters` = 0", (object) input);
              }
            }
            else
            {
              this.cmd.CommandText = string.Format("SELECT * from masina where motor = '{0}' and `sters` = 0", (object) input);
              command.CommandText = string.Format("SELECT count(`uid`) from masina where motor = '{0}' and `sters` = 0", (object) input);
            }
          }
          else
          {
            this.cmd.CommandText = string.Format("SELECT * from masina where an = '{0}' and `sters` = 0", (object) input);
            command.CommandText = string.Format("SELECT count(`uid`) from masina where an = '{0}' and `sters` = 0", (object) input);
          }
        }
        else
        {
          this.cmd.CommandText = string.Format("SELECT * from masina where model = '{0}' and `sters` = 0", (object) input);
          command.CommandText = string.Format("SELECT count(`uid`) from masina where model = '{0}' and `sters` = 0", (object) input);
        }
      }
      else
      {
        this.cmd.CommandText = string.Format("SELECT * from masina where marca = '{0}'", (object) input);
        command.CommandText = string.Format("SELECT count(`uid`) from masina where marca = '{0}' and `sters` = 0", (object) input);
      }
      MySqlDataReader mySqlDataReader = command.ExecuteReader();
      mySqlDataReader.Read();
      List<string>[] stringListArray = new List<string>[int.Parse(mySqlDataReader[0].ToString())];
      mySqlDataReader.Close();
      this.reader = this.cmd.ExecuteReader();
      int index1 = 0;
      while (this.reader.Read())
      {
        List<string> stringList = new List<string>();
        for (int index2 = 0; index2 < this.reader.FieldCount; ++index2)
        {
          string str = this.reader[index2].ToString();
          stringList.Add(str);
        }
        stringListArray[index1] = stringList;
        ++index1;
      }
      this.dbConn.Close();
      this.reader.Close();
      return stringListArray;
    }

    public void init()
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
      this.cmd.CommandText = "SELECT count(`uid`) from `masina` where `sters` = 0";
      this.reader = this.cmd.ExecuteReader();
      this.reader.Read();
      this.count = int.Parse(this.reader[0].ToString());
      this.uid = new string[this.count];
      this.an = new string[this.count];
      this.marca = new string[this.count];
      this.model = new string[this.count];
      this.serie = new string[this.count];
      this.motor = new string[this.count];
      this.kW = new string[this.count];
      this.cmc = new string[this.count];
      this.cmd.CommandText = "SELECT * from masina  where `sters` = 0";
      this.reader.Close();
      this.reader = this.cmd.ExecuteReader();
      int index = 0;
      while (this.reader.Read())
      {
        this.uid[index] = this.reader["uid"].ToString();
        this.an[index] = this.reader["an"].ToString();
        this.marca[index] = this.reader["marca"].ToString();
        this.model[index] = this.reader["model"].ToString();
        this.serie[index] = this.reader["serie"].ToString();
        this.motor[index] = this.reader["motor"].ToString();
        this.kW[index] = this.reader["kW"].ToString();
        this.cmc[index] = this.reader["cmc"].ToString();
        ++index;
      }
      this.reader.Close();
      this.dbConn.Close();
    }

    public bool insert(string input)
    {
      if (input.Contains("<") && input.Contains(">") || input == "" || input == null)
        return false;
      try
      {
        this.dbConn.Open();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Erro" + (object) ex);
        return false;
      }
      this.cmd.CommandText = string.Format(input);
      this.cmd.ExecuteNonQuery();
      int num1 = (int) MessageBox.Show("Masina adaugata cu succes");
      this.dbConn.Close();
      return true;
    }

    public bool delete(string input)
    {
      try
      {
        this.dbConn.Open();
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Erro" + (object) ex);
        return false;
      }
      this.cmd.CommandText = string.Format("UPDATE `masina` SET `sters`= 1 WHERE `uid`= '{0}'", (object) input);
      this.cmd.ExecuteNonQuery();
      this.dbConn.Close();
      return true;
    }

    private static string str_rand(int length)
    {
      Random random = new Random();
      return new string(Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", length).Select<string, char>((Func<string, char>) (s => s[random.Next(s.Length)])).ToArray<char>());
    }

    public void Dispose()
    {
      try
      {
        this.reader.Dispose();
      }
      catch
      {
      }
      try
      {
        this.dbConn.Dispose();
      }
      catch
      {
      }
    }
  }
}
