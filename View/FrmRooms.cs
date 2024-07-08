using HotelReservationSystem.Model;
using HotelReservationSystem.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservationSystem.View
{
    public partial class FrmRooms : Form
    {
        List<Room> rooms ;
        Dictionary<string,RoomType> roomTypes= new Dictionary<string,RoomType>();
        public FrmRooms()
        {
            InitializeComponent();
            
        }

        private void LoadRoomType() {
            roomTypes = Util.getInstance().GetRoomType();
        }

        private void LoadRooms()
        {
            rooms = Util.getInstance().GetRooms();
        }

        private void FrmRooms_Load(object sender, EventArgs e)
        {
            LoadRooms();
            LoadRoomType();

            DataTable oDT= new DataTable();
            oDT.Columns.Add("ROOMID", typeof(int));
            oDT.Columns.Add("ROOMNUMBER", typeof(string));
            oDT.Columns.Add("ROOMDESC", typeof(string));
            oDT.Columns.Add("ROOMTYPE", typeof(string));
            oDT.Columns.Add("CAPACITY", typeof(int));
            oDT.Columns.Add("PRICE", typeof(double));
            oDT.Columns.Add("NONSMOKING", typeof(bool));
            oDT.Columns.Add("DESCRIPTION", typeof(string));
            oDT.Columns.Add("ISCLEAN", typeof(bool));

            foreach (Room room in rooms) {
                DataRow dataRow = oDT.NewRow();
                dataRow["ROOMID"]= room.RoomID;
                dataRow["ROOMNUMBER"]=room.RoomNumber;
                dataRow["ROOMDESC"]=room.RoomDesc;
                dataRow["ROOMTYPE"]=room.RoomType;
                dataRow["CAPACITY"] = roomTypes[room.RoomType].Capacity;
                dataRow["PRICE"] = roomTypes[room.RoomType].Price;
                dataRow["NONSMOKING"] = roomTypes[room.RoomType].NonSmoking;
                dataRow["DESCRIPTION"] = roomTypes[room.RoomType].Description;
                dataRow["ISCLEAN"]= room.IsClean;
                oDT.Rows.Add(dataRow);
            }

            this.dgvRooms.DataSource = oDT;
        }
    }
}
