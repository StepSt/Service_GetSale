using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.ServiceModel;
using System.Web;
using NLog;

namespace Service_GetSale
{
    public class BaseManager : IBaseManager
    {
        public SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\base\UserBase.db");

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public IDprocedure GetDataBase_procedur(int IDproc)
        {
            DataTable returnTable = new DataTable();
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Procedures where IDproc_class =" + IDproc.ToString();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(returnTable);
            con.Close();
            IDprocedure ValueBase = new IDprocedure();
            ValueBase.IDproc_class = int.Parse(returnTable.Rows[0][0].ToString());
            ValueBase.IDshop_class = int.Parse(returnTable.Rows[0][1].ToString());
            ValueBase.IDuser_class = int.Parse(returnTable.Rows[0][2].ToString());
            ValueBase.User_result = int.Parse(returnTable.Rows[0][3].ToString());
            ValueBase.Shop_result = int.Parse(returnTable.Rows[0][4].ToString());
            ValueBase.Chek = double.Parse(returnTable.Rows[0][5].ToString());
            return ValueBase;
        }


        public void SetDataBase_procedur(IDprocedure data)
        {
            try
            {
                _logger.Log(LogLevel.Info, "Начало фунцкции SetDataBase_procedur");
                con.Open();
                _logger.Log(LogLevel.Info, "Открыл соединение");
                SQLiteCommand cmd = con.CreateCommand();
                _logger.Log(LogLevel.Info, "Форма команды");
                cmd.CommandText = "INSERT INTO Procedures ('IDproc_class', 'IDshop_class', 'IDuser_class') VALUES ('" + data.IDproc_class + "', '" + data.IDshop_class + "', '" + data.IDuser_class + "')";
                _logger.Log(LogLevel.Info, "Сформировал команду" + cmd.CommandText);
                cmd.ExecuteNonQuery();
                _logger.Log(LogLevel.Info, "Выполнил команду");
                con.Close();
                _logger.Log(LogLevel.Info, "Закрыл соеденение");
            }
            catch (Exception exception)
            {
                con.Close();
                _logger.Log(LogLevel.Info, exception.ToString());
            }
            
        }
        public void SetDataBase_procedur(int IDproc, string var)
        {
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Procedures SET " + var + " = 1 WHERE IDproc_class =" + IDproc + "";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataBase GetDataBase(int id)
        {
            DataTable returnTable = new DataTable();

            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Users where ID =" + id.ToString();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(returnTable);
            con.Close();

            DataBase ValueBase = new DataBase();
            ValueBase.id = returnTable.Rows[0][0].ToString();
            ValueBase.Sale_User = returnTable.Rows[0][2].ToString();
            ValueBase.Fond_User = returnTable.Rows[0][3].ToString();
            ValueBase.Publicity = returnTable.Rows[0][4].ToString();
            return ValueBase;
        }

        public void SetDataBase(DataBase data)
        {
            throw new NotImplementedException();
        }


        public void DelDataBase_procedur(int IDproc)
        {
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM Procedures WHERE IDproc_class = "+ IDproc;
            cmd.ExecuteNonQuery();
            con.Close();
            
        }

        public void SetDataBase_CompletionProcedures(IDprocedure data)
        {
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO CompletionProcedures ('IDshop_class', 'IDuser_class', 'Chek') VALUES ('" + data.IDshop_class + "', '" + data.IDuser_class + "', '" + data.Chek + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public User GetDataBase_user(int IDuser)
        {
            DataTable returnTable = new DataTable();
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Users where ID =" + IDuser.ToString();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(returnTable);
            con.Close();
            User ValueBase = new User();
            ValueBase.id = returnTable.Rows[0][0].ToString();
            ValueBase.name = returnTable.Rows[0][1].ToString();
            ValueBase.Sale_User = returnTable.Rows[0][2].ToString();
            ValueBase.Fond_User = returnTable.Rows[0][3].ToString();
            ValueBase.Publicity = returnTable.Rows[0][4].ToString();
            return ValueBase;
        }


        public void SetDataBase_User(User data)
        {
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Users ('ID', 'Name', 'Sale_User' , 'Fond_User' , 'Publicity') VALUES ('" + data.id + "', '" + data.name + "', '" + data.Sale_User + "', '" + data.Fond_User + "', '" + data.Publicity + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void SetDataBase_User_Param(int IDproc, string var, string value)
        {
            con.Open();
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE Users SET " + var + " = " + value + " WHERE ID =" + IDproc + "";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }

}