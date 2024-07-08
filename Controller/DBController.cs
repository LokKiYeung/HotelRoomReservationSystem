using HotelReservationSystem.Model;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HotelReservationSystem
{
    internal class DBController
    {
        private static DBController Instance;

        private DBController()
        {

        }

        public static DBController getInstance()
        {
            if (Instance == null)
            {

                Instance = new DBController();
            }
            return Instance;
        }

        public int executeCreateAppointmentStoredProcedure(int operatorid, int guestid, string remark,
          DateTime check_in, DateTime check_out, int num_adult, int num_child, string roomNum)
        {

            OracleConnection con = DBUtil.getDbInstance().GetDBConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "APPOINTMENT_PKG.CREATE_APPOINTMENT_SP";

            int appointmentid = 0;

            cmd.Parameters.Add(new OracleParameter("in_userid", OracleDbType.Int64, operatorid, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_guestid", OracleDbType.Int64, guestid, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_remark", OracleDbType.Varchar2, remark, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_check_in", OracleDbType.Date, check_in, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_check_out", OracleDbType.Date, check_out, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_num_adult", OracleDbType.Int64, num_adult, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_num_child", OracleDbType.Int64, num_child, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_room_num", OracleDbType.Varchar2, roomNum, ParameterDirection.Input));

            cmd.Parameters.Add(new OracleParameter("out_appointmentid", OracleDbType.Int64, ParameterDirection.Output));

            cmd.ExecuteNonQuery();
            appointmentid = Convert.ToInt32(cmd.Parameters["out_appointmentid"].Value.ToString());
            cmd.Dispose();

            System.Console.WriteLine(appointmentid);

            return appointmentid;
        }

        public int executeCreateGuestStoredProcedure(int operatorid, string firstname, string lastname,
            int gender, int age, string phonenumber, string email, string country, string ID)
        {

            OracleConnection con = DBUtil.getDbInstance().GetDBConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CREATE_GUEST_SP";

            int guestid = 0;

            cmd.Parameters.Add(new OracleParameter("in_userid", OracleDbType.Int64, operatorid, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_firstname", OracleDbType.Varchar2, firstname, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_lastname", OracleDbType.Varchar2, lastname, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_gender", OracleDbType.Int32, gender, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_age", OracleDbType.Int32, age, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_phonenumber", OracleDbType.Varchar2, phonenumber, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_email", OracleDbType.Varchar2, email, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_country", OracleDbType.Varchar2, country, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_id", OracleDbType.Varchar2, ID, ParameterDirection.Input));

            cmd.Parameters.Add(new OracleParameter("out_guestid", OracleDbType.Int64, ParameterDirection.Output));

            cmd.ExecuteNonQuery();
            guestid = Convert.ToInt32(cmd.Parameters["out_guestid"].Value.ToString());
            cmd.Dispose();

            System.Console.WriteLine(guestid);


            return guestid;
        }
        public int executeGetUserStoredProcedure(string username, string password)
        {

            OracleConnection con = DBUtil.getDbInstance().GetDBConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "staff_pkg.get_user_sp";

            int staffid = 0;


            cmd.Parameters.Add(new OracleParameter("in_username", OracleDbType.Varchar2, username, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_password", OracleDbType.Varchar2, password, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("out_staffid", OracleDbType.Int64, ParameterDirection.Output));


            try
            {
                cmd.ExecuteNonQuery();
                if (cmd.Parameters["out_staffid"].Value.ToString() != "null")
                {
                    staffid = Convert.ToInt32(cmd.Parameters["out_staffid"].Value.ToString());
                }

                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception("Fail to login for three times");

            }

            return staffid;
        }

        public int executeUpdatePasswordStoredProcedure(int operatorid, int staffid, string password)
        {

            OracleConnection con = DBUtil.getDbInstance().GetDBConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "staff_pkg.UPDATE_PASSWORD_SP";

            int rowaffected = 0;

            cmd.Parameters.Add(new OracleParameter("in_userid", OracleDbType.Int64, operatorid, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_staffid", OracleDbType.Int64, staffid, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_password", OracleDbType.Varchar2, password, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("out_affectedRowCnt", OracleDbType.Int64, ParameterDirection.Output));

            cmd.ExecuteNonQuery();
            rowaffected = Convert.ToInt32(cmd.Parameters["out_affectedRowCnt"].Value.ToString());
            cmd.Dispose();

            System.Console.WriteLine(rowaffected);


            return rowaffected;
        }

        public int executeMakePaymentStoredProcedure(int operatorid, int appointmentid, string in_payment_type, double in_payment, int in_promotion_id)
        {

            OracleConnection con = DBUtil.getDbInstance().GetDBConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "MAKE_PAYMENT_SP";

            int promotionid = 0;

            cmd.Parameters.Add(new OracleParameter("in_userid", OracleDbType.Int64, operatorid, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_appointment_id", OracleDbType.Int64, appointmentid, ParameterDirection.Input));

            cmd.Parameters.Add(new OracleParameter("in_payment_type", OracleDbType.Varchar2, in_payment_type, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_payment", OracleDbType.Decimal, in_payment, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_promotion_id", OracleDbType.Int32, in_promotion_id == 0 ? null : in_promotion_id, ParameterDirection.Input));


            cmd.Parameters.Add(new OracleParameter("out_paymentid", OracleDbType.Int64, ParameterDirection.Output));

            cmd.ExecuteNonQuery();
            promotionid = Convert.ToInt32(cmd.Parameters["out_paymentid"].Value.ToString());
            cmd.Dispose();

            System.Console.WriteLine(promotionid);


            return promotionid;
        }

        public int executeCancelAppointmentStoredProcedure(int operatorid, int appointmentid)
        {

            OracleConnection con = DBUtil.getDbInstance().GetDBConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "APPOINTMENT_PKG.CANCEL_APPOINTMENT_SP";

            int rowaffected = 0;

            cmd.Parameters.Add(new OracleParameter("in_userid", OracleDbType.Decimal, operatorid, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_appointment_id", OracleDbType.Decimal, appointmentid, ParameterDirection.Input));

            cmd.Parameters.Add(new OracleParameter("out_affectedRowCnt", OracleDbType.Int64, ParameterDirection.Output));

            cmd.ExecuteNonQuery();
            rowaffected = Convert.ToInt32(cmd.Parameters["out_affectedRowCnt"].Value.ToString());
            cmd.Dispose();

            System.Console.WriteLine(rowaffected);


            return rowaffected;
        }

        public double executeGetRevenueStoredProcedure(int in_year, int in_month)
        {

            OracleConnection con = DBUtil.getDbInstance().GetDBConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_REVENUE_SP";
            double revenue = 0;

            cmd.Parameters.Add(new OracleParameter("in_year", OracleDbType.Decimal, new OracleDecimal(in_year), ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("in_month", OracleDbType.Decimal, new OracleDecimal(in_month), ParameterDirection.Input));

            cmd.Parameters.Add(new OracleParameter("out_revenue", OracleDbType.Decimal, ParameterDirection.Output));

            cmd.ExecuteNonQuery();
            revenue = Convert.ToDouble(cmd.Parameters["out_revenue"].Value.ToString());
            cmd.Dispose();

            System.Console.WriteLine(revenue);


            return revenue;
        }

        public double executeGetRoomPriceStoredProcedure(int appointmentid)
        {

            OracleConnection con = DBUtil.getDbInstance().GetDBConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GET_ROOM_PRICE_SP";
            double roomprice = 0;

            cmd.Parameters.Add(new OracleParameter("in_appointmentid", OracleDbType.Decimal, new OracleDecimal(appointmentid), ParameterDirection.Input));

            cmd.Parameters.Add(new OracleParameter("out_roomprice", OracleDbType.Decimal, ParameterDirection.Output));

            cmd.ExecuteNonQuery();
            roomprice = Convert.ToDouble(cmd.Parameters["out_roomprice"].Value.ToString());
            cmd.Dispose();

            System.Console.WriteLine(roomprice);

            return roomprice;
        }

        public int executeNonQuery(string query)
        {
            int result = 0;

            OracleConnection con = DBUtil.getDbInstance().GetDBConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            // Execute command, create OracleDataReader object
            result = cmd.ExecuteNonQuery();
            // clean up
            cmd.Dispose();

            return result;
        }

        public object executeScaler(string query)
        {
            object result;

            OracleConnection con = DBUtil.getDbInstance().GetDBConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            // Execute command, create OracleDataReader object
            result = cmd.ExecuteScalar();
            // clean up
            cmd.Dispose();

            return result;
        }

        public DataTable executeQuery(string query)
        {
            var dataTable = new DataTable();

            OracleConnection con = DBUtil.getDbInstance().GetDBConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            // Execute command, create OracleDataReader object
            OracleDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);

            // Clean up
            reader.Dispose();
            cmd.Dispose();

            return dataTable;
        }

    }
}
