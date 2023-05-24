using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using TMPro;


using Mono.Data.Sqlite;
using System.Data;
using System;

public class DatabaseManager : MonoBehaviour
{
    // Path de la base de datos
    private string connectionString = "URI=file://"+Application.streamingAssetsPath+"/test.db";
    private IDbConnection dbConnection;

    // Objetos tipo TMP_Text
    public TMP_Text level_Reached_pro;
    public TMP_Text time_Played_pro;
    public TMP_Text death_pro;
    public TMP_Text enemies_Killed_pro;
    

    void Start()
    {
        // Crear la conexion a la base de datos
        dbConnection = (IDbConnection) new SqliteConnection(connectionString);
        
        // Abrir conexion
        dbConnection.Open();

        // Llamar al metodo ReadData
        ReadData();
        
    }
    // Metodo para leer valores de la base de datos
    public void ReadData(){
        
        // Variables
        string level_Reached = "";
        string time_Played = "";
        string deaths = "";
        string enemies_Killed = "";

        // Crear el comando
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT * FROM Playthrough";

        // Ejecuta el comando
        IDataReader dataReader = dbCommand.ExecuteReader();
        
        // Si en dataReader hay datos 
        while (dataReader.Read())
        {
            // Introduce los valores de la base de datos
            string last_level = dataReader.GetString(1);
            level_Reached = ""+last_level;
            level_Reached_pro.text = level_Reached;

            int time = dataReader.GetInt32(3);
            time_Played = ""+time;
            time_Played_pro.text = time_Played;

            int death = dataReader.GetInt32(4);
            deaths = ""+death;
            death_pro.text = deaths;

            int enemies = dataReader.GetInt32(5);
            enemies_Killed = ""+enemies;
            enemies_Killed_pro.text = enemies_Killed;
            
        }
        // Cierra todo lo relacionado con la base de datos
        dataReader.Close();
        dbCommand.Dispose();
        dbConnection.Close();
    }

    // Metodo para enviar valores a la base de datos
    public void SendData(){

        // Variables
        int id_play = 1;
        string level = "2";
        string health = "3";
        int time2 = 15;
        int death2 = 2;
        int id_global2 = 1;

        // Estructura para el comando
        string insertQuery = "INSERT INTO Playthrough (Id_Playthrough, Last_Level, Current_health, Play_time, Death_count, Id_global_statics ) VALUES (@Id_Playthrough, @Last_Level, @Current_health, @Play_time, @Death_count, @Id_global_statics)";
       
        // Crear el comando
        SqliteCommand insertCommand = new SqliteCommand(insertQuery, (SqliteConnection)dbConnection);

        // Define los valores para los parámetros
        insertCommand.Parameters.AddWithValue("@Id_Playthrough", id_play);
        insertCommand.Parameters.AddWithValue("@Last_Level", level);
        insertCommand.Parameters.AddWithValue("@Current_health", health);
        insertCommand.Parameters.AddWithValue("@Play_time", time2);
        insertCommand.Parameters.AddWithValue("@Death_count", death2);
        insertCommand.Parameters.AddWithValue("@Id_global_statics", id_global2);

        // Ejecuta el comando de inserción
        insertCommand.ExecuteNonQuery();
    }


}