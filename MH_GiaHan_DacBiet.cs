using PTTK_07.Data;

namespace PTTK_07.Business
{
    public class MH_GiaHan_DacBiet
    {
        private PhieuGiaHan_DAO giaHanDao;

        public MH_GiaHan_DacBiet()
        {
            giaHanDao = new PhieuGiaHan_DAO();
        }

        public bool KiemTraMaPDTvaMaTS(string maPDT, string maTS)
        {
            return giaHanDao.KiemTraMaPDTvaMaTS(maPDT, maTS);
        }
    }
}