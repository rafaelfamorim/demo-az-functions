# demo-az-functions


Simple function created for demo purpose, this function accepts HTTP requests from Github WebHook and send an email using SendGrid api as an Output.

It only sends emails for New Issues or Comments, all other event types are logged and ignored.

## If you want to run it

- Create these 3 keys in your environment:
	- `CustomSendGridKeyAppSettingName` - Your SendGrid API Key (you can create a free account to test :D )
	- `FromEmail` - The from email, this address must be validated in SendGrid platform 
	- `ToEmail` - the email would receive your notication


