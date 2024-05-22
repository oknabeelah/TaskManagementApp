// defines the datalayer class within the wholesaler forms namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Devart.Data;
using Devart.Data.PostgreSql;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
namespace Whole_Saler.forms
{
    public class Datalayer
    {
        // declaring private fields (white words) of types related to postgresql database operations (green words)
        PgSqlCommand cmd_;
        PgSqlConnection conn_;
        PgSqlDataAdapter adptr_;
        PgSqlDataReader reader_;
        DataTable dtable_;
        DataSet dset_;
        public string getmessage { get; set; } //declaring public property to store messages about database operations
        public Datalayer()  //initializing datalayer class
        {
            //string cs = "User Id=postgres;Host=localhost;Database=Student;Port=5432;Initial Schema=public;password=mysys;";
            string cs = "Host=ep-blue-wood-a2vvs8vu.eu-central-1.aws.neon.tech;Port=5432;User=na.okanlawon;Password=5a3TIDUvdwqt;Database=nebidb";
            //initialises  db copnnection, commsnd, datatable, blahballl
            conn_ = new PgSqlConnection(cs); //exception here: keyword not supported "username"
            cmd_ = new PgSqlCommand();
            dtable_ = new DataTable();
            adptr_ = new PgSqlDataAdapter();
            dset_ = new DataSet();
        }
        public bool connect()  //this method attempts to open a connection to the database
        {
            try
            {
                conn_.Open();
                getmessage = "successfully connected";
                return true;
            }
            catch (Exception ex)
            {
                getmessage = "connection error" + ex.Message;
                return false;
            }
        }
        public bool disconnect()  //attempts to close cvonnection
        {
            try
            {
                conn_.Clone();  //this doiesnt close the conection, it creates a new connection object that is a copy of the current one
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string InsertUpdateDeleteCreate(string query)  //this is the methof for executing CRUD queries
        {
            string ret = "";
            string allquerys = query.ToLower();
            try
            {
                cmd_.CommandText = query.ToLower();
                cmd_.Connection = conn_;
                connect();
                cmd_.ExecuteNonQuery();
                if (allquerys.ToLower().Contains("insert into"))
                {
                    ret = getmessage = (" inserted successfully ");
                }
                else if (allquerys.Contains("Delete form"))
                {
                    ret = getmessage = ("delete successfull");
                }
                else if (allquerys.Contains("Update into") && allquerys.Contains("set"))
                {
                    ret = getmessage = ("update successfull");
                }
                else if (allquerys.Contains("Creat table"))
                {
                    ret = getmessage = ("create table successful");
                }
            }
            catch (Exception exp)
            {
                ret = getmessage = "failed to execute" + query + "\n resoin :" + exp.Message;
            }
            finally { disconnect(); }
            return ret;
        }
        public string getsingleColumnValueByIndex(string query, out string columndata, int index)
        {
            string ret, val = null;
            try
            {
                cmd_.Connection = conn_;
                cmd_.CommandText = query;
                connect();
                reader_ = cmd_.ExecuteReader(); //is the reader case sensitive? idk
                while (reader_.Read())
                {
                    val = reader_[index].ToString(); //?
                }
                ret = "Operation Successfull!";
                getmessage = "values successfully got from getSingleValueAsArrayByindex() function";
            }
            catch (Exception exp)
            {
                ret = "Error in datalayer -> getSingleValueAsArrayByIndex() Reason:" + exp.Message;
                getmessage = "Error in datalayer getSingleValueAsArrayByIndex() for reader_ \n" + exp.Message;
            }
            finally
            {
                disconnect();
            }
            columndata = val;
            return ret;
        }
    }
}