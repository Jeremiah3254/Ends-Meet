using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class dbManagement : MonoBehaviour
{

    private void Start() {
        //readDatabase();
        //addPlayer();
    }

    void readDatabase() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT id, username, rank, level, XP, maxXP, dna " + "FROM player";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string username = reader.GetString(1);
            string rank = reader.GetString(2);
            int level = reader.GetInt32(3);
            int XP = reader.GetInt32(4);
            int maxXP = reader.GetInt32(5);
            int dna = reader.GetInt32(6);
            //basic assigning values from table then printing them to console till i get more of the implimentation stuff done.
            
            Debug.Log( "id:"+id+" username:"+username+" rank:"+rank+" Level:"+level+" xp:"+XP+" maxXP:"+maxXP+" dna:"+dna);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    void addPlayer() {
        string conn = "URI=file:" + Application.dataPath + "/playerStatsDB.db"; //Path to database = Aplication.dataPath(Assets folder location) + databaseName
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Opens connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO player (username,rank,level,XP,maxXP,dna) VALUES ('newUsername', 'beginner', '1', '0', '25', '0')"; // basic testing to make sure i can change individual values from the table without having to deal with id's
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string username = reader.GetString(1);
            string rank = reader.GetString(2);
            int level = reader.GetInt32(3);
            int XP = reader.GetInt32(4);
            int maxXP = reader.GetInt32(5);
            int dna = reader.GetInt32(6);
            //basic assigning values from table then printing them to console till i get more of the implimentation stuff done.
            
            Debug.Log( "id:"+id+" username:"+username+" rank:"+rank+" Level:"+level+" xp:"+XP+" maxXP:"+maxXP+" dna:"+dna);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }
}
