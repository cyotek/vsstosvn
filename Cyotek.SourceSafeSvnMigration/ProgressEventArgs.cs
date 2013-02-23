using System;

namespace Cyotek.SourceSafeSvnMigration
{
	public class ProgressEventArgs : EventArgs
	{
		#region  Public Constructors

		public ProgressEventArgs(double percentComplete)
			: this(null, percentComplete)
		{ }

		public ProgressEventArgs(string status)
			: this(status, 0.0)
		{ }

		public ProgressEventArgs(string status, double percentComplete)
			: this()
		{
			this.Status = status;
			this.PercentComplete = percentComplete;
		}

		#endregion  Public Constructors

		#region  Protected Constructors

		protected ProgressEventArgs()
		{ }

		#endregion  Protected Constructors

		#region  Public Properties

		public double PercentComplete { get; protected set; }

		public string Status { get; protected set; }

		#endregion  Public Properties
	}
}
