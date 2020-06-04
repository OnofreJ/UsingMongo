namespace UsingMongo.Infrastructure.CrossCutting.Settings
{
	/// <summary>
	/// This class represents the settings used in the application.
	/// </summary>
	public class AppSettings
	{
		/// <summary>
		/// Gets or sets the name of the application.
		/// </summary>
		/// <value>The name of the application.</value>
		public string ApplicationName { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is enable.
		/// </summary>
		/// <value><c>true</c> if enable; otherwise, <c>false</c>.</value>
		public bool Enable { get; set; }

		/// <summary>
		/// Gets or sets the HTTP client user agent.
		/// </summary>
		/// <value>The HTTP client user agent.</value>
		public string HttpClientUserAgent { get; set; }

		/// <summary>
		/// Gets or sets the service port.
		/// </summary>
		/// <value>The service port.</value>
		public int Port { get; set; }
	}
}