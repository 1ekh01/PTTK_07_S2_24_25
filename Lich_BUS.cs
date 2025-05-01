using System;
using System.Data;
using PTTK_07.Data;

namespace PTTK_07.Business
{
	public class Lich_BUS
	{
		private Lich_DAO lichDao;

		public Lich_BUS()
		{
			lichDao = new Lich_DAO();
		}

		public bool KiemTraLichThi(DateTime ngay)
		{
			DataTable dt = lichDao.LayLichTheoNgay(ngay);
			return dt.Rows.Count > 0;
		}

		public DataTable LayLichTheoNgay(DateTime ngay)
		{
			return lichDao.LayLichTheoNgay(ngay);
		}
	}
}