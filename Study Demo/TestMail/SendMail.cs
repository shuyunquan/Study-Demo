using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TestMail
{
    class SendMail
    {
        string m = ConfigurationManager.AppSettings["Mail"];

        public void SendMailUseGmail()
        {
            #region MyRegion
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(new MailAddress("vae@163.com"));

            msg.From = new MailAddress("shuyunquan@qq.com");
            msg.Subject = "测试";//邮件标题    
            msg.SubjectEncoding = System.Text.Encoding.UTF8;//邮件标题编码    
            msg.Body = "终于成功了啊";//邮件内容    
            msg.BodyEncoding = System.Text.Encoding.UTF8;//邮件内容编码    
            msg.IsBodyHtml = true;//是否是HTML邮件    
            msg.Priority = MailPriority.High;//邮件优先级    
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("shuyunquan@qq.com", "hsdfonimwaoicabd");
            //上述写你的GMail邮箱和密码    
            client.Port = 25;//Gmail使用的端口    
            client.Host = "smtp.qq.com";
            client.EnableSsl = true;//经过ssl加密    
            object userState = msg;
            try
            {
                client.Send(msg);
                Console.WriteLine("发送成功");
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                throw ex;
            } 
            #endregion
          
        }


    }
}
