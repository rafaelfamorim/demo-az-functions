using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using System.Reflection.Metadata.Ecma335;

namespace Demo.AzFunction
{
    public static class GitHubIntegration
    {
        [FunctionName("GitHubIntegration")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function,  "post", Route = null)] HttpRequest req,
            [SendGrid(ApiKey = "CustomSendGridKeyAppSettingName")] IAsyncCollector<SendGridMessage> outMessage,
            ILogger log)
        {
            string template = "<!DOCTYPE html><html xmlns='http://www.w3.org/1999/xhtml' xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office'><head> <title></title> <meta http-equiv='X-UA-Compatible' content='IE=edge'> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'> <meta name='viewport' content='width=device-width, initial-scale=1'> <style type='text/css'> #outlook a{padding:0;}.ReadMsgBody{width:100%;}.ExternalClass{width:100%;}.ExternalClass *{line-height:100%;}body{margin:0;padding:0;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;}table, td{border-collapse:collapse;mso-table-lspace:0pt;mso-table-rspace:0pt;}img{border:0;height:auto;line-height:100%; outline:none;text-decoration:none;-ms-interpolation-mode:bicubic;}p{display:block;margin:13px 0;}</style> <style type='text/css'> @media only screen and (max-width:480px){@-ms-viewport{width:320px;}@viewport{width:320px;}}</style><!--[if mso]> <xml> <o:OfficeDocumentSettings> <o:AllowPNG/> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings> </xml><![endif]--><!--[if lte mso 11]> <style type='text/css'> .outlook-group-fix{width:100% !important;}</style><![endif]--> <link href='https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700' rel='stylesheet' type='text/css'><link href='https://fonts.googleapis.com/css?family=Cabin:400,700' rel='stylesheet' type='text/css'> <style type='text/css'> @import url(https://fonts.googleapis.com/css?family=Ubuntu:300,400,500,700);@import url(https://fonts.googleapis.com/css?family=Cabin:400,700); </style> <style type='text/css'> @media only screen and (min-width:480px){.mj-column-per-100{width:100% !important; max-width: 100%;}}</style> <style type='text/css'> @media only screen and (max-width:480px){table.full-width-mobile{width: 100% !important;}td.full-width-mobile{width: auto !important;}}</style> <style type='text/css'>.hide_on_mobile{display: none !important;}@media only screen and (min-width: 480px){.hide_on_mobile{display: block !important;}}.hide_section_on_mobile{display: none !important;}@media only screen and (min-width: 480px){.hide_section_on_mobile{display: table !important;}}.hide_on_desktop{display: block !important;}@media only screen and (min-width: 480px){.hide_on_desktop{display: none !important;}}.hide_section_on_desktop{display: table !important;}@media only screen and (min-width: 480px){.hide_section_on_desktop{display: none !important;}}[owa] .mj-column-per-100{width: 100%!important;}[owa] .mj-column-per-50{width: 50%!important;}[owa] .mj-column-per-33{width: 33.333333333333336%!important;}p{margin: 0px;}@media only print and (min-width:480px){.mj-column-per-100{width:100%!important;}.mj-column-per-40{width:40%!important;}.mj-column-per-60{width:60%!important;}.mj-column-per-50{width: 50%!important;}mj-column-per-33{width: 33.333333333333336%!important;}}</style> </head> <body style='background-color:#FFFFFF;'> <div style='background-color:#FFFFFF;'><!--[if mso | IE]> <table align='center' border='0' cellpadding='0' cellspacing='0' class='' style='width:600px;' width='600' > <tr> <td style='line-height:0px;font-size:0px;mso-line-height-rule:exactly;'><![endif]--> <div style='Margin:0px auto;max-width:600px;'> <table align='center' border='0' cellpadding='0' cellspacing='0' role='presentation' style='width:100%;'> <tbody> <tr> <td style='direction:ltr;font-size:0px;padding:9px 0px 9px 0px;text-align:center;vertical-align:top;'><!--[if mso | IE]> <table role='presentation' border='0' cellpadding='0' cellspacing='0'> <tr> <td class='' style='vertical-align:top;width:600px;' ><![endif]--> <div class='mj-column-per-100 outlook-group-fix' style='font-size:13px;text-align:left;direction:ltr;display:inline-block;vertical-align:top;width:100%;'> <table border='0' cellpadding='0' cellspacing='0' role='presentation' style='vertical-align:top;' width='100%'> <tbody><tr> <td align='left' style='font-size:0px;padding:15px 15px 15px 15px;word-break:break-word;'> <div style='font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:11px;line-height:1.5;text-align:left;color:#000000;'> <div><span style='font-size: 16px;'><strong>{{title}}</strong></span></div></div></td></tr><tr> <td style='font-size:0px;padding:10px 25px;padding-top:10px;padding-right:10px;padding-bottom:10px;padding-left:10px;word-break:break-word;'> <p style='border-top:solid 1px #000000;font-size:1;margin:0px auto;width:100%;'> </p><!--[if mso | IE]> <table align='center' border='0' cellpadding='0' cellspacing='0' style='border-top:solid 1px #000000;font-size:1;margin:0px auto;width:580px;' role='presentation' width='580px' > <tr> <td style='height:0;line-height:0;'> &nbsp; </td></tr></table><![endif]--> </td></tr><tr> <td align='left' style='font-size:0px;padding:0px 0px 0px 0px;word-break:break-word;'> <table border='0' cellpadding='0' cellspacing='0' role='presentation' style='border-collapse:collapse;border-spacing:0px;'> <tbody> <tr> <td style='width:108px;'> <a target='_blank'> <img src='{{avatar_img}}' height='auto' style='border:0;display:block;outline:none;text-decoration:none;height:auto;width:100%;font-size:13px;' width='108'> </a> </td></tr></tbody> </table> </td></tr><tr> <td align='left' style='font-size:0px;padding:15px 15px 15px 15px;word-break:break-word;'> <div style='font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:11px;line-height:1.5;text-align:left;color:#000000;'> <p>{{username}}</p></div></td></tr><tr> <td align='left' style='font-size:0px;padding:15px 15px 15px 15px;word-break:break-word;'> <div style='font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:11px;line-height:1.5;text-align:left;color:#000000;'> <p><span style='font-size: 14px;'>The user  '{{username}}' has just {{action}}.</span></p></div></td></tr><tr> <td align='left' style='font-size:0px;padding:15px 15px 15px 15px;word-break:break-word;'> <div style='font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:11px;line-height:1.5;text-align:left;color:#000000;'> </div></td></tr><tr> <td style='font-size:0px;padding:10px 25px;padding-top:10px;padding-right:10px;padding-bottom:10px;padding-left:10px;word-break:break-word;'> <p style='border-top:solid 1px #000000;font-size:1;margin:0px auto;width:100%;'> </p><!--[if mso | IE]> <table align='center' border='0' cellpadding='0' cellspacing='0' style='border-top:solid 1px #000000;font-size:1;margin:0px auto;width:580px;' role='presentation' width='580px' > <tr> <td style='height:0;line-height:0;'> &nbsp; </td></tr></table><![endif]--> </td></tr><tr> <td align='left' style='font-size:0px;padding:15px 15px 15px 15px;word-break:break-word;'> <div style='font-family:Ubuntu, Helvetica, Arial, sans-serif;font-size:11px;line-height:1.5;text-align:left;color:#000000;'> <p style='text-align: center;'><span style='color: #e03e2d; font-size: 18px;'><strong>CHECK THIS OUT</strong></span></p></div></td></tr><tr> <td align='center' vertical-align='middle' style='font-size:0px;padding:20px 20px 20px 20px;word-break:break-word;'> <table border='0' cellpadding='0' cellspacing='0' role='presentation' style='border-collapse:separate;line-height:100%;'> <tbody><tr> <td align='center' bgcolor='#e85034' role='presentation' style='border:0px solid #000;border-radius:24px;cursor:auto;mso-padding-alt:9px 26px 9px 26px;background:#e85034;' valign='middle'> <a href='{{issue_url}}' style='display:inline-block;background:#e85034;color:#ffffff;font-family:Ubuntu, Helvetica, Arial, sans-serif, Helvetica, Arial, sans-serif;font-size:13px;font-weight:normal;line-height:100%;Margin:0;text-decoration:none;text-transform:none;padding:9px 26px 9px 26px;mso-padding-alt:0px;border-radius:24px;' target='_blank'> GO TO GITHUB </a> </td></tr></tbody></table> </td></tr></tbody></table> </div><!--[if mso | IE]> </td></tr></table><![endif]--> </td></tr></tbody> </table> </div><!--[if mso | IE]> </td></tr></table><![endif]--> </div></body></html>";
            log.LogInformation("Our GitHub Monitor processed an action.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<Rootobject>(requestBody);

            var fromEmail = Environment.GetEnvironmentVariable("FromEmail");
            var toEmail = Environment.GetEnvironmentVariable("ToEmail");

            string title;
            string action;
            string avatar_url;
            string username;

            if (data.action == "opened")
            {
                title = "A new issue was created";
                action = "opened a new issue";
                avatar_url = data.issue.user.avatar_url;
                username = data.issue.user.login;
            }
            else if (data.action == "created")
            {
                title = "A new comment was added to an issue";
                action = "added a new comment";
                avatar_url = data.comment.user.avatar_url;
                username = data.comment.user.login;

            }
            else
            {
                return new OkResult();
            }
            log.LogInformation($"Processing Action: {data.action}");

            template = template.Replace("{{title}}", title)
                               .Replace("{{action}}",action)
                               .Replace("{{avatar_img}}", avatar_url)
                               .Replace("{{username}}", username)
                               .Replace("{{issue_url}}", data.issue.html_url);

            // log.LogInformation(requestBody);

            var message = new SendGridMessage();
            message.AddTo(toEmail);
            message.AddContent("text/html", template);
            message.SetFrom(new EmailAddress(fromEmail));
            message.SetSubject(title);

            await outMessage.AddAsync(message);

            return new OkResult();
        }
    }

    public class Rootobject
    {
        public string action { get; set; }
        public string zen { get; set; }
        public int hook_id { get; set; }
        public Hook hook { get; set; }
        public Repository repository { get; set; }
        public User sender { get; set; }
        public Issue issue { get; set; }
        public Comment comment { get; set; }

    }

    public class Hook
    {
        public string type { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public string[] events { get; set; }
        public Config config { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime created_at { get; set; }
        public string url { get; set; }
        public string test_url { get; set; }
        public string ping_url { get; set; }
        public Last_Response last_response { get; set; }
    }

    public class Issue
    {
        public string url { get; set; }
        public string html_url { get; set; }    
        public string title { get; set; }
        public User user { get; set; }
        public int comments { get; set; }
        public Comment comment { get; set; }
    }

    public class Comment
    {
        public string url { get; set; }
        public string html_url { get; set; }
        public string issue_url { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public User user { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string author_association { get; set; }
        public string body { get; set; }

    }


    public class Config
    {
        public string content_type { get; set; }
        public string insecure_ssl { get; set; }
        public string url { get; set; }
    }

    public class Last_Response
    {
        public object code { get; set; }
        public string status { get; set; }
        public object message { get; set; }
    }

    public class Repository
    {
        public int id { get; set; }
        public string node_id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public bool _private { get; set; }
        public Owner owner { get; set; }
        public string html_url { get; set; }
        public string description { get; set; }
        public bool fork { get; set; }
        public string url { get; set; }
        public string forks_url { get; set; }
        public string keys_url { get; set; }
        public string collaborators_url { get; set; }
        public string teams_url { get; set; }
        public string hooks_url { get; set; }
        public string issue_events_url { get; set; }
        public string events_url { get; set; }
        public string assignees_url { get; set; }
        public string branches_url { get; set; }
        public string tags_url { get; set; }
        public string blobs_url { get; set; }
        public string git_tags_url { get; set; }
        public string git_refs_url { get; set; }
        public string trees_url { get; set; }
        public string statuses_url { get; set; }
        public string languages_url { get; set; }
        public string stargazers_url { get; set; }
        public string contributors_url { get; set; }
        public string subscribers_url { get; set; }
        public string subscription_url { get; set; }
        public string commits_url { get; set; }
        public string git_commits_url { get; set; }
        public string comments_url { get; set; }
        public string issue_comment_url { get; set; }
        public string contents_url { get; set; }
        public string compare_url { get; set; }
        public string merges_url { get; set; }
        public string archive_url { get; set; }
        public string downloads_url { get; set; }
        public string issues_url { get; set; }
        public string pulls_url { get; set; }
        public string milestones_url { get; set; }
        public string notifications_url { get; set; }
        public string labels_url { get; set; }
        public string releases_url { get; set; }
        public string deployments_url { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime pushed_at { get; set; }
        public string git_url { get; set; }
        public string ssh_url { get; set; }
        public string clone_url { get; set; }
        public string svn_url { get; set; }
        public object homepage { get; set; }
        public int size { get; set; }
        public int stargazers_count { get; set; }
        public int watchers_count { get; set; }
        public string language { get; set; }
        public bool has_issues { get; set; }
        public bool has_projects { get; set; }
        public bool has_downloads { get; set; }
        public bool has_wiki { get; set; }
        public bool has_pages { get; set; }
        public int forks_count { get; set; }
        public object mirror_url { get; set; }
        public bool archived { get; set; }
        public bool disabled { get; set; }
        public int open_issues_count { get; set; }
        public object license { get; set; }
        public int forks { get; set; }
        public int open_issues { get; set; }
        public int watchers { get; set; }
        public string default_branch { get; set; }
    }

    public class Owner
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }

    public class User
    {
        public string login { get; set; }
        public int id { get; set; }
        public string node_id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string html_url { get; set; }
        public string followers_url { get; set; }
        public string following_url { get; set; }
        public string gists_url { get; set; }
        public string starred_url { get; set; }
        public string subscriptions_url { get; set; }
        public string organizations_url { get; set; }
        public string repos_url { get; set; }
        public string events_url { get; set; }
        public string received_events_url { get; set; }
        public string type { get; set; }
        public bool site_admin { get; set; }
    }
}
