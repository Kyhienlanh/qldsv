using System.Linq;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Security.Authentication;

class ResetPassword
{
    private static readonly Byte[] _privateKey = new Byte[] { 0xDE, 0xAD, 0xBE, 0xEF }; // NOTE: You should use a private-key that's a LOT longer than just 4 bytes.
    private static readonly TimeSpan _passwordResetExpiry = TimeSpan.FromMinutes(5);
    private const Byte _version = 1; // Increment this whenever the structure of the message changes.

    public static String CreatePasswordResetHmacCode(Int32 userId)
    {
        Byte[] message = Enumerable.Empty<Byte>()
            .Append(_version)
            .Concat(BitConverter.GetBytes(userId))
            .Concat(BitConverter.GetBytes(DateTime.UtcNow.ToBinary()))
            .ToArray();

        using (HMACSHA256 hmacSha256 = new HMACSHA256(key: _privateKey))
        {
            Byte[] hash = hmacSha256.ComputeHash(buffer: message, offset: 0, count: message.Length);

            Byte[] outputMessage = message.Concat(hash).ToArray();
            String outputCodeB64 = Convert.ToBase64String(outputMessage);
            String outputCode = outputCodeB64.Replace('+', '-').Replace('/', '_');
            return outputCode;
        }
    }

    public static Boolean VerifyPasswordResetHmacCode(String codeBase64Url, out Int32 userId)
    {
        Byte[] message;
        try
        {
            String base64 = codeBase64Url.Replace('-', '+').Replace('_', '/');
            //.PadRight(4 * ((codeBase64Url.Length + 3) / 4), '=')
            message = Convert.FromBase64String(base64);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            userId = -1;
            return false;
        }

        Byte version = message[0];
        if (version < _version)
        {
            throw new InvalidCredentialException("difference of version");
        }
        userId = BitConverter.ToInt32(message, startIndex: 1); // Reads bytes message[1,2,3,4]
        Int64 createdUtcBinary = BitConverter.ToInt64(message, startIndex: 1 + sizeof(Int32)); // Reads bytes message[5,6,7,8,9,10,11,12]

        DateTime createdUtc = DateTime.FromBinary(createdUtcBinary);
        if (createdUtc.Add(_passwordResetExpiry) < DateTime.UtcNow) return false;

        const Int32 _messageLength = 1 + sizeof(Int32) + sizeof(Int64); // 1 + 4 + 8 == 13

        using (HMACSHA256 hmacSha256 = new HMACSHA256(key: _privateKey))
        {
            Byte[] hash = hmacSha256.ComputeHash(message, offset: 0, count: _messageLength);

            Byte[] messageHash = message.Skip(_messageLength).ToArray();
            return Enumerable.SequenceEqual(hash, messageHash);
        }

    }

    public static void SendEmail(Int32 userId, string _subject, MailAddress _from, MailAddress _to, List<MailAddress> _cc, List<MailAddress> _bcc = null)
    {
        //create token for mailing
        string temp = ResetPassword.CreatePasswordResetHmacCode(userId);
        Console.WriteLine(temp);

        var mailClient = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("nguyengialac99@gmail.com", "elhkroxkqdkjytsq") //change email & pass
        };

        MailMessage msgMail = new MailMessage(); ;
        string Text = "Here your token, please use this token to reset your password: " + temp;
        msgMail.From = _from;
        msgMail.To.Add(_to);
        foreach (MailAddress addr in _cc)
        {
            msgMail.CC.Add(addr);
        }
        if (_bcc != null)
        {
            foreach (MailAddress addr in _bcc)
            {
                msgMail.Bcc.Add(addr);
            }
        }
        msgMail.Subject = _subject;
        msgMail.Body = Text;
        msgMail.IsBodyHtml = true;
        mailClient.Send(msgMail);
        msgMail.Dispose();
    }
}
