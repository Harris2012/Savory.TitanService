using Savory.TitanService.Contract;
using Savory.TitanService.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Savory.TitanService
{
    public class TitanService : ServiceBase, ITitanService
    {
        ServiceHost host = null;

        #region ServiceBase Members
        protected override void OnStart(string[] args)
        {
            try
            {
                host = new ServiceHost(this.GetType());

                host.Open();
            }
            catch (Exception ex)
            {
                string fileName = string.Format("OnStartException_{0:yyyyMMddHHmmss}", DateTime.Now);

                File.WriteAllText(fileName, ex.ToString());
            }
        }

        protected override void OnStop()
        {
            try
            {
                host.Close();
            }
            catch (Exception ex)
            {
                string fileName = string.Format("OnStopException_{0:yyyyMMddHHmmss}", DateTime.Now);

                File.WriteAllText(fileName, ex.ToString());
            }
        }
        #endregion

        #region ITitanService Members
        public string GetConnString(string dbName)
        {
            return TitanRepository.GetConnString(dbName);
        }
        #endregion
    }
}
