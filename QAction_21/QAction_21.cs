using System;

using Skyline.DataMiner.Scripting;

/// <summary>
/// DataMiner QAction Class: SendCommandB.
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
			protocol.SetParameter(Parameter.commandbstarttime, DateTime.Now.ToOADate());
			protocol.CheckTrigger(101);
		}
		catch (Exception ex)
		{
			protocol.Log("QA" + protocol.QActionID + "|" + protocol.GetTriggerParameter() + "|Run|Exception thrown:" + Environment.NewLine + ex, LogType.Error, LogLevel.NoLogging);
		}
	}
}