using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Configuration;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
      

        
        Timer time = new Timer();


        public Service1()
        {
            InitializeComponent();
            time.Interval = 5000;
            time.AutoReset = true;
            time.Elapsed += new ElapsedEventHandler(JJ);
            //JJ(null,null); // 调试吧
        }


        public void JJ(object sender, System.Timers.ElapsedEventArgs e)
        {
            //搞事吧
            ConfigurationManager.RefreshSection("tag");
            string tag = ConfigurationManager.AppSettings["tag"];
            Log.Save(tag);
        }


        protected override void OnStart(string[] args)
        {
            time.Enabled = true;
            Log.Save("Start");
        }

        protected override void OnStop()
        {
            time.Enabled = false;
            Log.Save("Stop");
        }
    

    }
}
