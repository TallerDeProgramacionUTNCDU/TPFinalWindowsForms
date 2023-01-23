using Quartz;
using Quartz.Impl.AdoJobStore.Common;
using ScottPlot.Renderable;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPFinalWindowsForms.DAL;
using TPFinalWindowsForms.DAL.EntityFramework;
using TPFinalWindowsForms.Domain;
using TPFinalWindowsForms.Visual;

namespace TPFinalWindowsForms.Quartz
{
    
    public class BackgroundJob : IJob
    {

        Fachada fachada = new Fachada();
        public async Task Execute(IJobExecutionContext context)
        {
            fachada.QuartzJob();
        }
    }
}
