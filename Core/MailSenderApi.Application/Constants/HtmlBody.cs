using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApi.Application.Constants
{
    static public class HtmlBody
    {
        static public string HtmlBodyCreate { get
            {
                var body = @"
<html>
  <head>
    <style>
      body {
        font-family: Arial, sans-serif;
        background-color: #f4f4f4;
        margin: 0;
        padding: 0;
      }
      .container {
        width: 100%;
        max-width: 600px;
        margin: 0 auto;
        background-color: #ffffff;
        padding: 20px;
        border-radius: 5px;
      }
      h1 {
        color: #333333;
        font-size: 24px;
      }
      p {
        font-size: 16px;
        color: #555555;
        line-height: 1.5;
      }
      .footer {
        font-size: 12px;
        color: #888888;
        text-align: center;
        margin-top: 20px;
      }
    </style>
  </head>
  <body>
    <div class='container'>
      <h1>Welcome to Our Service!</h1>
      <p>Dear User,</p>
      <p>
        We are excited to have you on board. Thank you for signing up for our
        service. If you have any questions, feel free to reply to this email.
      </p>
      <p>Best regards,</p>
      <p>The Team</p>
      <div class='footer'>
        <p>© 2024 Your Company Name. All rights reserved.</p>
      </div>
    </div>
  </body>
</html>";
                return body;
            }
        }
    }
}
