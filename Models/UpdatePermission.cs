using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using DeviceManagement;

namespace DeviceManagement.Models
{
    public class UpdatePermission
    {
         public int id { get; set; }
        public string permission_name { get; set; }


        internal Appdb Db { get; set; }

        public UpdatePermission()
        {
        }
    }
    public class updatepermission
    {
        public Appdb Db { get; }
        public updatepermission(Appdb db)
        {
            Db = db;
        }
        async public Task updatePermission(UpdatePermission p)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = "updatepermission";
            cmd.CommandType = CommandType.StoredProcedure;
            Bindper(cmd, p);
            await cmd.ExecuteNonQueryAsync();
        }
        private void Bindper(MySqlCommand cmd, UpdatePermission p)
        {
            cmd.Parameters.Add(new MySqlParameter("permission_id", p.id));
            cmd.Parameters.Add(new MySqlParameter("permission_name", p.permission_name));

        }
    }
}








