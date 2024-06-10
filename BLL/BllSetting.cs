using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using JKTS_Contract_system.DAL;


namespace JKTS_Contract_system.BLL
{
    public class BllSetting
    {
        // to get method from DalSetting
        DalSetting datalayerSetting = new DalSetting();

        //get everything from the database table (Setting)
        public DataSet GetSetting( )
        {

            datalayerSetting = new DalSetting();
            return datalayerSetting.GetSetting();
        }

        //get the Logo(Picture) from database table (Setting)
        public DataSet GetLogo()
        {

            datalayerSetting = new DalSetting();
            return datalayerSetting.GetLogo();
        }

        //to get the Email of the System Administrator
        public DataSet GetSystemAdmin()
        {
            datalayerSetting = new DalSetting();
            return datalayerSetting.GetSystemAdmin();
        }
        //to update logo/copyright in database table (Setting)

        public int UpdateSettingDetails(string id, string logo, string copyright)
        {
            datalayerSetting = new DalSetting();
            return datalayerSetting.UpdateSettingDetails(id, logo, copyright );
        }
    }
}