using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string[] aa = { "aaa", "bbbb", "ccc", "ddd" };

        string[] bb = { "fffffffffff" };


     

        Response.Write(string.Join("-",aa)+"***********************************************<br>");

        Response.Write("*******8<br>"+string.Join("-", bb)+"***********************************************<br>");
        string signTempMatchValue = "1111";

        //第一个参数是否为'
        if (signTempMatchValue.Length > 0)
        {


            
            if (signTempMatchValue.IndexOf("'") == 0)
            {
                //那么classid,或id 为selft 或为分类集合
                //第二个
                signTempMatchValue.IndexOf("'", 1);
            }
            //得到分类集合

            string arrclassid = signTempMatchValue.Substring(0, signTempMatchValue.IndexOf("'", 1)+1);


            Response.Write(arrclassid);

        }
    }
    protected void btnRun_Click(object sender, EventArgs e)
    {
        string text = txtText.Text;
        string rule = txtRule.Text;

        Regex reg = new Regex(rule,RegexOptions.IgnorePatternWhitespace);
        MatchCollection matchs = reg.Matches(text);
        StringBuilder arrG = new StringBuilder();

        foreach (Match m in matchs)
        {
            

            arrG.AppendFormat("【M:{0}--r:{1}】", m.Value, m.Result(rule));
            GroupCollection gs = m.Groups;
            foreach (Group g in gs)
            {
                arrG.AppendFormat("【G:{0}】 ",g.Value);   
            }
            arrG.AppendFormat("<br>");
        }
        txtResult.Text = arrG.ToString();
    }
}