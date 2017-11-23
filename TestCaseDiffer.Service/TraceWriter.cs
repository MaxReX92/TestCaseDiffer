using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Tracing;

namespace TestCaseDiffer.Service
{
	internal class TraceWriter : ITraceWriter
	{
		/// <summary>
		///  NLog implementation of webapi's ITraceWriter tracing extensibility point.
		///   <remarks>More info about ITraceWriter, please see: "http://blogs.msdn.com/b/roncain/archive/2012/04/12/tracing-in-asp-net-web-api.aspx"</remarks>
		/// </summary>
		public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
		{
			var logger = LogManager.GetLogger("");
			try
			{
				var logLevel = GetLogLevel(level);
				if (logger.IsEnabled(logLevel))
				{
					logger.Log(CreateEvent(CreateTraceRecord(request, category, level, traceAction), logLevel));
				}
			}
			catch (Exception ex)
			{
				logger.Error(ex, "Failed to trace message due to an error.");
			}
		}

		private static TraceRecord CreateTraceRecord(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
		{
			var record = new TraceRecord(request, category, level);
			traceAction(record);
			return record;
		}

		/// <summary>
		/// Create new log event info based off TraceRecord properties specified by app.
		/// </summary>
		private static LogEventInfo CreateEvent(TraceRecord record, LogLevel logLevel) =>
			new LogEventInfo
			{
				Level = logLevel,
				Message = $"{record.RequestId} | {record.Operator}.{record.Operation} | {record.Kind}: {record.Message}",
				LoggerName = $"{record.Category}",
				Exception = record.Exception,
				TimeStamp = record.Timestamp.ToLocalTime()
			};

		/// <summary>
		/// Translates webapi log level to nlog log level.
		/// </summary>
		private static LogLevel GetLogLevel(TraceLevel level)
		{
			return LogLevel.FromString(level.ToString());
		}

	}
}
