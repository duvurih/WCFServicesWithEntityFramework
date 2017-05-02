using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HKWCFServices.Business.Shared.ExceptionHandling
{
    public class GlobalExceptionHandling : IErrorHandler
    {

        public bool HandleError(Exception error)
        {
            //string sSource;
            //string sLog;
            //string sEvent;

            //sSource = "HKWCFService Application";
            //sLog = "Application";
            //sEvent = "Global Exception Event";

            //if (!EventLog.SourceExists(sSource))
            //    EventLog.CreateEventSource(sSource, sLog);

            //sEvent = error.Message + error.StackTrace;
            //EventLog.WriteEntry(sSource, sEvent);
            //EventLog.WriteEntry(sSource, sEvent, EventLogEntryType.Warning, 234);

            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException)
                return;

            FaultException faultException = new FaultException("Global Exception");
            MessageFault messageFault = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, messageFault, null);
        }
    }
}
