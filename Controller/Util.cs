using HotelReservationSystem.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelReservationSystem.Controller
{
    internal class Util
    {
        private static Util Instance;

        private Util()
        {

        }

        public static Util getInstance()
        {
            if (Instance == null)
            {

                Instance = new Util();
            }
            return Instance;
        }

        public List<Staff> GetStaffs()
        {
            List<Staff> list = new List<Staff>();
            DataTable oDT = DBController.getInstance().executeQuery("select STAFFID, STAFFTITLE, USERNAME, PASSWORD, EMAIL, PHONENUMBER, ADDRESS, REMARK from Staff");
            if (oDT != null && oDT.Rows.Count > 0)
            {
                for (int i = 0; i < oDT.Rows.Count; i++)
                {
                    Staff staff = new Staff();
                    staff.StaffID = Convert.ToInt32(oDT.Rows[i]["STAFFID"]);
                    staff.StaffTitle = oDT.Rows[i]["STAFFTITLE"].ToString();
                    staff.UserName = oDT.Rows[i]["USERNAME"].ToString();
                    staff.Email = oDT.Rows[i]["EMAIL"].ToString();
                    staff.PhoneNumber = oDT.Rows[i]["PHONENUMBER"].ToString();
                    staff.Address = oDT.Rows[i]["ADDRESS"].ToString();
                    staff.Remark = oDT.Rows[i]["REMARK"].ToString();

                    list.Add(staff);
                }
            }
            return list;
        }

        public List<Room> GetRooms()
        {
            List<Room> list = new List<Room>();
            DataTable oDT = DBController.getInstance().executeQuery("select ROOMID, ROOMNUMBER,ROOMDESC,ROOMTYPE,ISCLEAN from ROOM");
            if (oDT != null && oDT.Rows.Count > 0)
            {
                for (int i = 0; i < oDT.Rows.Count; i++)
                {
                    Room room = new Room();
                    room.RoomID = Convert.ToInt32(oDT.Rows[i]["ROOMID"]);
                    room.RoomNumber = oDT.Rows[i]["ROOMNUMBER"].ToString();
                    room.RoomDesc = oDT.Rows[i]["ROOMDESC"].ToString();
                    room.RoomType = oDT.Rows[i]["ROOMTYPE"].ToString();
                    room.IsClean = Convert.ToBoolean(oDT.Rows[i]["ISCLEAN"]);
                    list.Add(room);
                }

            }
            return list;
        }

        public Dictionary<string, RoomType> GetRoomType()
        {
            Dictionary<string, RoomType> list = new Dictionary<string, RoomType>();
            DataTable oDT = DBController.getInstance().executeQuery("select ROOMTYPE, CAPACITY, PRICE, NONSMOKING, DESCRIPTION from ROOMTYPE");
            if (oDT != null && oDT.Rows.Count > 0)
            {
                for (int i = 0; i < oDT.Rows.Count; i++)
                {
                    RoomType roomtype = new RoomType();
                    roomtype.RoomTypeName = oDT.Rows[i]["ROOMTYPE"].ToString();
                    roomtype.Capacity = Convert.ToInt16(oDT.Rows[i]["CAPACITY"]);
                    roomtype.Price = Convert.ToDouble(oDT.Rows[i]["PRICE"]);
                    roomtype.NonSmoking = Convert.ToBoolean(oDT.Rows[i]["NONSMOKING"]);
                    roomtype.Description = oDT.Rows[i]["DESCRIPTION"].ToString();
                    list.Add(roomtype.RoomTypeName, roomtype);
                }

            }
            return list;
        }

        public List<Guest> GetGuests()
        {
            List<Guest> list = new List<Guest>();
            DataTable oDT = DBController.getInstance().executeQuery("select GUESTID, FIRSTNAME, LASTNAME, GENDER, AGE, PHONENUMBER, EMAIL, COUNTRY, ID from Guest");
            if (oDT != null && oDT.Rows.Count > 0)
            {
                for (int i = 0; i < oDT.Rows.Count; i++)
                {
                    Guest guest = new Guest();
                    guest.GuestID = Convert.ToInt32(oDT.Rows[i]["GUESTID"]);
                    guest.FirstName = oDT.Rows[i]["FIRSTNAME"].ToString();
                    guest.LastName = oDT.Rows[i]["LASTNAME"].ToString();
                    guest.Gender = Convert.ToInt32(oDT.Rows[i]["GENDER"]);
                    guest.Age = Convert.ToInt32(oDT.Rows[i]["AGE"]);
                    guest.PhoneNumber = oDT.Rows[i]["PHONENUMBER"].ToString();
                    guest.Email = oDT.Rows[i]["EMAIL"].ToString();
                    guest.Country = oDT.Rows[i]["COUNTRY"].ToString();
                    guest.ID = oDT.Rows[i]["ID"].ToString();
                    list.Add(guest);
                }


            }

            return list;
        }

        public int GenderTextToNum(string gender_string)
        {
            int gender = 0;
            switch (gender_string)
            {
                case "N/A":
                    {
                        gender = 0;
                        break;
                    }
                case "Male":
                    {
                        gender = 1;
                        break;
                    }
                case "Female":
                    {
                        gender = 2;
                        break;
                    }
                case "Other":
                    {
                        gender = 3;
                        break;
                    }
            }
            return gender;
        }

        public string GenderNumToText(int gender_num)
        {
            string gender_text = "";
            switch (gender_num)
            {
                case 0:
                    {
                        gender_text = "N/A";
                        break;
                    }
                case 1:
                    {
                        gender_text = "Male";
                        break;
                    }
                case 2:
                    {
                        gender_text = "Female";
                        break;
                    }
                case 3:
                    {
                        gender_text = "Other";
                        break;
                    }
            }
            return gender_text;
        }

        public DataTable GetAppointments()
        {

            DataTable oDT = DBController.getInstance().executeQuery("SELECT STAFFID,APPOINTMENTID,REMARK,CHECK_IN,CHECK_OUT,NUM_ADULT,NUM_CHILD,PAYMENT_ID,FIRSTNAME,LASTNAME,GENDER,AGE,PHONENUMBER,EMAIL,COUNTRY,ID,ROOMNUMBER FROM APPOINTMENT_VIEW");

            return oDT;
        }


        public DataTable GetPromitionTypes()
        {
            
            DataTable oDT = DBController.getInstance().executeQuery("SELECT PROMOTIONID, NAME, DESCRIPTION, DISCOUNTRATE FROM PROMOTIONTYPE ORDER BY DISCOUNTRATE ASC");

            return oDT;
        }
    }
}
