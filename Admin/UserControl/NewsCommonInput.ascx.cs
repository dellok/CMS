using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Common;
using LL.Common;
using System.Text;

public partial class UserControl_NewsCommonInput : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string TitleFont
    {

        get
        {
            //得到所选项

            StringBuilder fs = new StringBuilder();
            foreach (ListItem item in cboxTitleFontStyle.Items)
            {
                if (item.Selected)
                {
                    fs.AppendFormat("{0}{1}", item.Value, PubConstant.Key_Sign_BrokenbarSign.ToString());
                }
            }
            string f = Util.FilterStartAndEndSign(fs.ToString(), PubConstant.Key_Sign_BrokenbarSign.ToString());

            return string.Format("{0}{1}{2}", txtFontColor.Text.Replace("#", "").Trim(),
                PubConstant.Key_Sign_CommaSign,
                f);
        }
        set
        {

            if (!string.IsNullOrEmpty(value))
            {
                //显示标题样式
                string[] arrTitleStyle = value.Split(new string[] { PubConstant.Key_Sign_CommaSign.ToString() }, 2, System.StringSplitOptions.None);
                if (arrTitleStyle.Length == 2)
                {
                    if (!string.IsNullOrEmpty(arrTitleStyle[0]))
                    {
                        txtFontColor.Text = arrTitleStyle[0];
                        txtShowColor.Attributes.Add("style", string.Format("background:#{0}", arrTitleStyle[0].Replace("#", "")));

                    }
                    if (!string.IsNullOrEmpty(arrTitleStyle[1]))
                    {
                        string fontb = arrTitleStyle[1];
                        string[] arrTitleFont = fontb.Split(new string[] { PubConstant.Key_Sign_BrokenbarSign.ToString() }, 3, System.StringSplitOptions.RemoveEmptyEntries);
                        foreach (string item in arrTitleFont)
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                if (cboxTitleFontStyle.Items.FindByValue(item) != null)
                                {
                                    cboxTitleFontStyle.Items.FindByValue(item).Selected = true;
                                }

                            }


                        }
                    }
                }
            }
        }

    }


    public string FilenameQZ
    {

        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                txtFilenameQZ.Text = value;

            }

        }
        get
        {

            return txtFilenameQZ.Text.Trim();
        }
    }


    public string TitlePicUrl
    {

        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                txtTitlePicUrl.Text = value;

            }

        }
        get
        {

            return txtTitlePicUrl.Text.Trim();
        }
    }

    public string LabelTitle
    {

        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                lblTitle.Text = value;
            }
            else
            {
                lblTitle.Text = "标题";
            }
        }
    }
    public string TxtTitle
    {
        get
        {
            return txtTitle.Text.Trim();
        }
        set
        {
            txtTitle.Text = value;

        }
    }




    public int IsTop
    {
        get
        {
            return Format.DataConvertToInt(drplIsTop.SelectedValue);
        }
        set
        {

            drplIsTop.SelectedIndex = drplIsTop.Items.IndexOf(drplIsTop.Items.FindByValue(value.ToString()));

        }

    }
    public int CloseFeedback
    {
        get
        {
            return cboxClosePL.Checked ? 1 : 0;
        }
        set
        {

            cboxClosePL.Checked = Format.DataConvertToInt(value) > 0 ? true : false;

        }

    }

    public int FirstTitle
    {
        get
        {
            return cboxFirstTitle.Checked ? 1 : 0;
        }
        set
        {

            cboxFirstTitle.Checked = Format.DataConvertToInt(value) > 0 ? true : false;

        }

    }

    public int IsGood
    {
        get
        {
            return cboxIsGood.Checked ? 1 : 0;
        }
        set
        {

            cboxIsGood.Checked = Format.DataConvertToInt(value) > 0 ? true : false;

        }

    }

    public int IsChecked
    {
        get
        {
            return cboxChecked.Checked ? 1 : 0;
        }
        set
        {

            bool isb = Format.DataConvertToInt(value) > 0 ? true : false;
            cboxChecked.Checked = isb;
        }

    }




    public string TitleOutUrl
    {

        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                txtOutUrl.Text = value;


            }

        }
        get
        {

            return txtOutUrl.Text.Trim();
        }
    }


    public string KeyWord
    {

        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                txtKeyWord.Text = value;
            }

        }
        get
        {

            return txtKeyWord.Text.Trim();
        }
    }
}