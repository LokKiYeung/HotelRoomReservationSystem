using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using HotelReservationSystem.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;



namespace HotelReservationSystem
{
    /// <summary>
    /// Singleton design pattern is used to get a connection to the DB
    /// Singleton can be used where there is a need to create only one instance of a given class
    /// </summary>

    class DBUtil
    {

        private static String constr = null; //holds tnsnames.ora statemnt

        private static DBUtil dbInstance;
        private OracleConnection conn;

        private DBUtil()
        {
        }

        public static DBUtil getDbInstance()
        {
            if (dbInstance == null)
            {

                dbInstance = new DBUtil();
            }
            return dbInstance;
        }

        /// <summary>
        /// this returns an oracle connection created using the connection string
        /// </summary>
        /// <returns>oracle connection</returns>
        public OracleConnection GetDBConnection()
        {
            try
            {
                createConnectionstring();                
                if (conn == null) {
                    conn = new OracleConnection(constr);
                    conn.Open();
                }
               
                Console.WriteLine("Connected");
            }
            catch (OracleException e)
            {
                Console.WriteLine("Not connected: " + e.ToString());
                Console.ReadLine();
            }

            return conn;
        }

        /// <summary>
        /// this closes the created database connection
        /// </summary>
        public void closeDBConnection()
        {
            try
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
            catch (OracleException e)
            {
                Console.WriteLine("Connection closed failed: " + e.ToString());

            }
            finally
            {
                Console.WriteLine("End..");

            }

        }

        /// <summary>
        /// Read the configurations.xml in order to create the connection string
        /// </summary>
        public static void createConnectionstring()
        {
            try
            {

                constr = Settings.Default.OracleConnectionString;
                Console.WriteLine("ConstrVariable created ");

            }
            catch (Exception ConstrError)
            {
                Console.WriteLine(ConstrError.Message);
            }

        }
    }
}