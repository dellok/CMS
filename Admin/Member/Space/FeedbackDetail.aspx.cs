using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LL.Model.Member;
using LL.BLL.Member;
public partial class Member_Space_FeedbackDetail : AdminPage
{

    public string title = "";
    public string addtime = "";
    public string ip = "";
    public string name = "";
    public string fax = "";
    public int userid = 0;
    public int submitUserID = 0;
    public string submitName = "";
    public string company = "";
    public string email = "";
    public string tel = "";
    public string address = "";
    public string zip = "";
    public string fContent = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            BindDetail();
        }
    }

    void BindDetail()
    {

        BLLphome_enewsmemberfeedback bll = new BLLphome_enewsmemberfeedback();

        phome_enewsmemberfeedback model = bll.GetModel(PageCommon.GetReqID());
        if (model!=null)
        {


            title = model.title;
            userid = model.userid;
            submitUserID = model.uid;
            submitName = model.uname;
            addtime = model.addtime.ToString();
            company = model.company;
            address = model.address;
            name = model.name;
            email = model.email;
            tel = model.phone;
            ip = model.ip;
            zip = model.zip;
            fContent = model.ftext;
            fax = model.fax;

        }
    
    
    }
}