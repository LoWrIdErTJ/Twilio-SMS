using System;
using System.Collections.Generic;
using UBotPlugin;
using Twilio;

namespace TwilioSMS
{
    // API KEY HERE
    public class PluginInfo
    {
        public static string HashCode { get { return "1177c15b95cac2bd76736b67dbab976fbd32d04f"; } }
    }

    // ---------------------------------------------------------------------------------------------------------- //
    //
    // ---------------------------------               FUNCTIONS               ----------------------------------- //
    //
    // ---------------------------------------------------------------------------------------------------------- //


    //
    //
    // Twilio send sms (working)
    //
    //

    public class TwilioSendSMS : IUBotFunction
    {

        private List<UBotParameterDefinition> _parameters = new List<UBotParameterDefinition>();

        public TwilioSendSMS()
        {
            _parameters.Add(new UBotParameterDefinition("Twilio SID", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("Twilio Token", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("From +19998889898", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("To +19998889898", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("SMS Message", UBotType.String));

        }


        public string Category
        {
            get { return "Botguru.net Twilio SMS"; }
        }

        public string FunctionName
        {
            get { return "$Twilio Send SMS"; }
        }


        private string _returnValue;
        public void Execute(IUBotStudio ubotStudio, Dictionary<string, string> parameters)
        {

            string twiliosid = parameters["Twilio SID"];
            string twiliotoken = parameters["Twilio Token"];
            string from = parameters["From +19998889898"];
            string to = parameters["To +19998889898"];
            string msg = parameters["SMS Message"];

            var accountSid = twiliosid;
            var authToken = twiliotoken;

            //TwilioRestClient client = new TwilioRestClient(accountSid, authToken);

            var twilio = new TwilioRestClient(accountSid, authToken);

            var message = twilio.SendMessage(from, to, msg);

            //var message = twilio.SendMessage("+14015371287", "[To]", null, null, null);

            //var message = client.SendSmsMessage(from, to, msg);
            //Console.WriteLine(message.Sid);

            var result = message.Sid;

            if (message.RestException != null)
            {
                _returnValue = message.RestException.Message;
            }
            if (message.RestException == null)
            {
                _returnValue = result;
            }

            // _returnValue = debug;

        }

        public object ReturnValue
        {
            // We return our variable _returnValue as the result of the function.
            get { return _returnValue; }
        }

        public UBotType ReturnValueType
        {
            // Our result is text, so the return value type is String.
            get { return UBotType.String; }
        }

        public bool IsContainer
        {
            get { return false; }
        }

        public IEnumerable<UBotParameterDefinition> ParameterDefinitions
        {
            get { return _parameters; }
        }

        public IEnumerable<string> Options
        {
            get;
            set;
        }

        public UBotVersion UBotVersion
        {
            get { return UBotVersion.Standard; }
        }

    }


    //
    //
    // Twilio send mms (working)
    //
    //

    public class TwilioSendMMS : IUBotFunction
    {

        private List<UBotParameterDefinition> _parameters = new List<UBotParameterDefinition>();

        public TwilioSendMMS()
        {
            _parameters.Add(new UBotParameterDefinition("Twilio SID", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("Twilio Token", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("From +19998889898", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("To +19998889898", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("SMS Message", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("URL to image", UBotType.String));

        }


        public string Category
        {
            get { return "Botguru.net Twilio SMS"; }
        }

        public string FunctionName
        {
            get { return "$Twilio Send MMS"; }
        }


        private string _returnValue;
        public void Execute(IUBotStudio ubotStudio, Dictionary<string, string> parameters)
        {

            string twiliosid = parameters["Twilio SID"];
            string twiliotoken = parameters["Twilio Token"];
            string from = parameters["From +19998889898"];
            string to = parameters["To +19998889898"];
            string msg = parameters["SMS Message"];
            string imageurllink = parameters["URL to image"];

            var accountSid = twiliosid;
            var authToken = twiliotoken;

            TwilioRestClient client = new TwilioRestClient(accountSid, authToken);

            var message = client.SendMessage(from, to, msg, new string[] { imageurllink });

            //Console.WriteLine(message.Sid);

            var result = message.Sid;

            if (message.RestException != null)
            {
                _returnValue = message.RestException.Message;
            }
            if (message.RestException == null)
            {
                _returnValue = result;
            }

            // _returnValue = debug;

        }

        public object ReturnValue
        {
            // We return our variable _returnValue as the result of the function.
            get { return _returnValue; }
        }

        public UBotType ReturnValueType
        {
            // Our result is text, so the return value type is String.
            get { return UBotType.String; }
        }

        public bool IsContainer
        {
            get { return false; }
        }

        public IEnumerable<UBotParameterDefinition> ParameterDefinitions
        {
            get { return _parameters; }
        }

        public IEnumerable<string> Options
        {
            get;
            set;
        }

        public UBotVersion UBotVersion
        {
            get { return UBotVersion.Standard; }
        }

    }


    //
    //
    // Twilio Get Messages (working)
    //
    //

    public class TwilioGetMessages : IUBotFunction
    {

        private List<UBotParameterDefinition> _parameters = new List<UBotParameterDefinition>();

        public TwilioGetMessages()
        {
            _parameters.Add(new UBotParameterDefinition("Twilio SID", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("Twilio Token", UBotType.String));

        }


        public string Category
        {
            get { return "Botguru.net Twilio SMS"; }
        }

        public string FunctionName
        {
            get { return "$Twilio get messages"; }
        }


        private string _returnValue;
        public void Execute(IUBotStudio ubotStudio, Dictionary<string, string> parameters)
        {

            string twiliosid = parameters["Twilio SID"];
            string twiliotoken = parameters["Twilio Token"];

            var accountSid = twiliosid;
            var authToken = twiliotoken;

            var twilio = new TwilioRestClient(accountSid, twiliotoken);

            var request = new MessageListRequest();

            var messages = twilio.ListMessages(request);

            foreach (var message in messages.Messages)
            {
                Console.WriteLine(message.Body);
            }

            var consoleData = Console.Read();

            _returnValue = consoleData.ToString();

        }

        public object ReturnValue
        {
            // We return our variable _returnValue as the result of the function.
            get { return _returnValue; }
        }

        public UBotType ReturnValueType
        {
            // Our result is text, so the return value type is String.
            get { return UBotType.String; }
        }

        public bool IsContainer
        {
            get { return false; }
        }

        public IEnumerable<UBotParameterDefinition> ParameterDefinitions
        {
            get { return _parameters; }
        }

        public IEnumerable<string> Options
        {
            get;
            set;
        }

        public UBotVersion UBotVersion
        {
            get { return UBotVersion.Standard; }
        }

    }



    //
    //
    // Twilio Read Messages (working)
    //
    //

    public class TwilioReadMessages : IUBotFunction
    {

        private List<UBotParameterDefinition> _parameters = new List<UBotParameterDefinition>();

        public TwilioReadMessages()
        {
            _parameters.Add(new UBotParameterDefinition("Twilio SID", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("Twilio Token", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("Twilio Msg ID", UBotType.String));

        }


        public string Category
        {
            get { return "Botguru.net Twilio SMS"; }
        }

        public string FunctionName
        {
            get { return "$Twilio read message"; }
        }


        private string _returnValue;
        public void Execute(IUBotStudio ubotStudio, Dictionary<string, string> parameters)
        {

            string twiliosid = parameters["Twilio SID"];
            string twiliotoken = parameters["Twilio Token"];
            string twiliomsgid = parameters["Twilio Msg ID"];

            var accountSid = twiliosid;
            var authToken = twiliotoken;

            var twilio = new TwilioRestClient(accountSid, authToken);

            var message = twilio.GetMessage(twiliomsgid);

            _returnValue = message.Body;

        }

        public object ReturnValue
        {
            // We return our variable _returnValue as the result of the function.
            get { return _returnValue; }
        }

        public UBotType ReturnValueType
        {
            // Our result is text, so the return value type is String.
            get { return UBotType.String; }
        }

        public bool IsContainer
        {
            get { return false; }
        }

        public IEnumerable<UBotParameterDefinition> ParameterDefinitions
        {
            get { return _parameters; }
        }

        public IEnumerable<string> Options
        {
            get;
            set;
        }

        public UBotVersion UBotVersion
        {
            get { return UBotVersion.Standard; }
        }

    }




    //
    //
    // Twilio Delete Messages (working)
    //
    //

    public class TwilioDeleteMessages : IUBotFunction
    {

        private List<UBotParameterDefinition> _parameters = new List<UBotParameterDefinition>();

        public TwilioDeleteMessages()
        {
            _parameters.Add(new UBotParameterDefinition("Twilio SID", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("Twilio Token", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("Twilio Msg ID", UBotType.String));

        }


        public string Category
        {
            get { return "Botguru.net Twilio SMS"; }
        }

        public string FunctionName
        {
            get { return "$Twilio delete message"; }
        }


        private string _returnValue;
        public void Execute(IUBotStudio ubotStudio, Dictionary<string, string> parameters)
        {

            string twiliosid = parameters["Twilio SID"];
            string twiliotoken = parameters["Twilio Token"];
            string twiliomsgid = parameters["Twilio Msg ID"];

            var accountSid = twiliosid;
            var authToken = twiliotoken;

            var twilio = new TwilioRestClient(accountSid, authToken);

            var message = twilio.DeleteMessage(twiliomsgid);

            _returnValue = message.ToString();

        }

        public object ReturnValue
        {
            // We return our variable _returnValue as the result of the function.
            get { return _returnValue; }
        }

        public UBotType ReturnValueType
        {
            // Our result is text, so the return value type is String.
            get { return UBotType.String; }
        }

        public bool IsContainer
        {
            get { return false; }
        }

        public IEnumerable<UBotParameterDefinition> ParameterDefinitions
        {
            get { return _parameters; }
        }

        public IEnumerable<string> Options
        {
            get;
            set;
        }

        public UBotVersion UBotVersion
        {
            get { return UBotVersion.Standard; }
        }

    }

}