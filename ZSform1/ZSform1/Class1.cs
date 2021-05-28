using Kingdee.BOS.Core.DynamicForm;
using Kingdee.BOS.Core.Metadata;
using Kingdee.BOS.Core.Report.PlugIn;
using Kingdee.BOS.Util;
using System;

public class ZSform1 : AbstractSysReportPlugIn
{
    /// <summary>    
    /// 简单账表1表单插件    
    /// </summary>    
    /// <param name="Args"></param>    
    public override void CellDbClick(Kingdee.BOS.Core.Report.PlugIn.Args.CellEventArgs Args)
    {
        //fprojecnumber FDATAVALUE fid FCreateTime
        base.CellDbClick(Args);
        if (Args.Header.FieldName.Equals("FSumPrice", StringComparison.CurrentCultureIgnoreCase) || Args.Header.FieldName.Equals("fprojecnumber", StringComparison.CurrentCultureIgnoreCase) || Args.Header.FieldName.Equals("FDATAVALUE", StringComparison.CurrentCultureIgnoreCase) || Args.Header.FieldName.Equals("fid", StringComparison.CurrentCultureIgnoreCase) || Args.Header.FieldName.Equals("FbeginTime", StringComparison.CurrentCultureIgnoreCase) || Args.Header.FieldName.Equals("FendTime", StringComparison.CurrentCultureIgnoreCase))
        {
            string sWorkCenterId = this.SysReportView.SelectedDataRows[0]["fprojecnumber"].ToString();
            string sBeginTime = this.SysReportView.SelectedDataRows[0]["Fbegintime"].ToString();
            string sEndTime = this.SysReportView.SelectedDataRows[0]["Fendtime"].ToString();
            //long workCenterId;            
            ////汇总行没有工作中心的值            
            //if (long.TryParse(sWorkCenterId, out workCenterId))            
            //{                
            //    DynamicFormShowParameter billShowPara2 = new DynamicFormShowParameter();                
            //    billShowPara2.OpenStyle.ShowType = ShowType.NewTabPage;                
            //    billShowPara2.ParentPageId = this.View.PageId;                
            //    billShowPara2.FormId = "k9ffb98f0cd174177b5055698bb715ead";                
            //   // billShowPara2.CustomComplexParams.Add("FDetailID", workCenterId);                
            //    this.View.ShowForm(billShowPara2);            
            //}  
            Kingdee.BOS.Core.Report.SysReportShowParameter RptParameter = new Kingdee.BOS.Core.Report.SysReportShowParameter
            {
                ParentPageId = this.View.PageId,
                FormId = "k02f170e0ccd44f06a2085bea0e2dcc45",//第二个简单账表的标识
                IsShowFilter = false



            };
            RptParameter.PageId = SequentialGuid.NewGuid().ToString();
            RptParameter.OpenStyle.ShowType = Kingdee.BOS.Core.DynamicForm.ShowType.MainNewTabPage;
            RptParameter.CustomComplexParams.Add("F_DEV_PRONO", sWorkCenterId);
            RptParameter.CustomComplexParams.Add("F_DEV_BEGINTIME", sBeginTime);
            RptParameter.CustomComplexParams.Add("F_DEV_ENDTIME", sEndTime);
            this.View.ShowForm(RptParameter);
        }
    }
}