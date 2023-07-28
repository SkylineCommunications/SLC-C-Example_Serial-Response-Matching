using System;

using Skyline.DataMiner.Scripting;

/// <summary>
/// DataMiner QAction Class: Process Response.
/// </summary>
public class QAction
{
	/// <summary>
	/// The QAction entry point.
	/// </summary>
	/// <param name="protocol">Link with SLProtocol process.</param>
	public static void Run(SLProtocol protocol)
	{
		try
		{
			double startOaDateTime = Convert.ToDouble(protocol.GetParameter(Parameter.commandastarttime));
			DateTime startTime = DateTime.FromOADate(startOaDateTime);

			TimeSpan duration = DateTime.Now.Subtract(startTime);

			protocol.SetParameter(Parameter.responseamatchingduration, duration.TotalMilliseconds);
		}
		catch (Exception ex)
		{
			protocol.Log("QA" + protocol.QActionID + "|" + protocol.GetTriggerParameter() + "|Run|Exception thrown:" + Environment.NewLine + ex, LogType.Error, LogLevel.NoLogging);
		}
	}
}