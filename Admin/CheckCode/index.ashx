<%@ WebHandler Language="C#" Class="index" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Drawing;
public class index : IHttpHandler, IRequiresSessionState
{


 
 
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "image/gif";
        InitCodeNum(context);
    }

    
    


    private void InitCodeNum(HttpContext context)
    {
        string Key = "CheckCode";
        string tmp = RndNum(4).ToUpper();
        HttpCookie a = new HttpCookie(Key, tmp);
        //存入session中
      //  context.Session[Key] = tmp;
        LL.Common.Cache.SessionManager.SetSession(LL.Common.PubConstant.Key_CheckCode, tmp);
        //存入cookies中
        context.Response.Cookies.Add(a);
        this.CreateImage(tmp,context);
    }




    private void CreateImage(string checkCode, HttpContext context)
    {
        int iwidth = (int)(checkCode.Length * 15);
        Bitmap image = new Bitmap(iwidth, 25);
       Graphics g = Graphics.FromImage(image);
        g.Clear(Color.White);
        //定义颜色
        Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
        //定义字体           
        string[] font = { "宋体" };
        Random rand = new Random();
        //随机输出噪点
        for (int i = 0; i < 50; i++)
        {
            int x = rand.Next(image.Width);
            int y = rand.Next(image.Height);
            g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
        }

        //输出不同字体和颜色的验证码字符
        for (int i = 0; i < checkCode.Length; i++)
        {
            int cindex = rand.Next(7);
            int findex = rand.Next(5);

            // Font f = new Font(font[findex], 14, FontStyle.Bold);
            Font f = new Font("Arial", 15, FontStyle.Bold);
            Brush b = new SolidBrush(c[cindex]);
            int ii = 8;
            if ((i + 1) % 2 == 0)
            {
                ii = 2;
            }

            g.DrawString(checkCode.Substring(i, 1), f, b, (i * 12) + 3, 0);
            //g.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * 12), ii);
        }
        //画一个边框
        g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);

        //输出到浏览器
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        context.Response.ClearContent();
        context.Response.ContentType = "image/Jpeg";
        context.Response.BinaryWrite(ms.ToArray());
        g.Dispose();
        image.Dispose();
    }
    private string RndNum(int VcodeNum)
    {
        // string Vchar = "1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,p,q,r,s,t,u,v,w,x,y,z";
        string Vchar = "1,2,3,4,5,6,7,8,9,0";
        string[] VcArray = Vchar.Split(new Char[] { ',' });
        string VNum = "";
        int temp = -1;

        Random rand = new Random();

        for (int i = 1; i < VcodeNum + 1; i++)
        {
            if (temp != -1)
            {
                rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
            }

            int t = rand.Next(10);
            if (temp != -1 && temp == t)
            {
                return RndNum(VcodeNum);
            }
            temp = t;
            VNum += VcArray[t];
        }
        return VNum;
    } 
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}