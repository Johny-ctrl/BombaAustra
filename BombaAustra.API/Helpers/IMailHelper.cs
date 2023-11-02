﻿using BombaAustra.Shared.Responses;

namespace BombaAustra.API.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string toName, string toEmail, string subject, string body);
    }


}
