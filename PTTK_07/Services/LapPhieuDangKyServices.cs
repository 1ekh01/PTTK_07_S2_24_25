using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using PTTK_07.Helpers;

namespace PTTK_07.Services
{
    internal class LapPhieuDangKyServices
    {
        //public static DataTable GetKhachHang_NVTiepNhan()
        //{
        //    //if (DatabaseHelper.Connection == null || DatabaseHelper.Connection.State != ConnectionState.Open)
        //    //{
        //    //    MessageBox.Show("Chưa kết nối database.");
        //    //    return null;
        //    //}
        //    var table = new DataTable();
        //    try
        //    {
        //        using (var conn = DatabaseHelper.conn)
        //        using (var cmd = new SqlCommand("SELECT * FROM PTTK_TTLT_ACCI.KHACH_HANG", DatabaseHelper.Connection))
        //        using (var adapter = new SqlDataAdapter(cmd))
        //        {
        //            adapter.Fill(table);
        //        }
        //        return table;
        //    }
        //    catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }
        //}

        //public static DataTable GetKhachHang_NVTiepNhan()
        //{
        //    if (DatabaseHelper.Connection == null || DatabaseHelper.Connection.State != ConnectionState.Open)
        //    {
        //        MessageBox.Show("Chưa kết nối database.");
        //        return null;
        //    }
        //    var cmd = new SqlCommand("SELECT * FROM KHACH_HANG", DatabaseHelper.Connection);
        //    var adapter = new SqlDataAdapter(cmd);
        //    {
        //        var table = new DataTable();
        //        try
        //        {
        //            adapter.Fill(table);
        //            return table;
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //            return null;
        //        }
        //    }

        //    //var table = new DataTable();

        //    //try
        //    //{
        //    //    using (var conn = DatabaseHelper.Connection)
        //    //    using (var cmd = new SqlCommand("SELECT * FROM PTTK_TTLT_ACCI.KHACH_HANG", conn))
        //    //    using (var adapter = new SqlDataAdapter(cmd))
        //    //    {
        //    //        adapter.Fill(table);
        //    //    }
        //    //    return table;
        //    //}
        //    //catch (SqlException ex)
        //    //{
        //    //    // Handle SQL Server exception
        //    //    // MessageBox.Show($"SQL Error [{ex.Number}]: {ex.Message}");
        //    //    return null;
        //    //}
        //}
    }
}
