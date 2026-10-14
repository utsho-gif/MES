using System.Collections.Generic;

namespace MES.Core.Setting
{
    public class EmailConfiguration
    {
        public string From { get; set; } = "mes-alerts@company.com";
        public string SmtpServer { get; set; } = "smtp.company.com";
        public int Port { get; set; } = 587;
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public List<string> EmailSendTo { get; set; } = new List<string>();
        public string AlertSubject { get; set; } = "MES Production Alert";
    }
}
