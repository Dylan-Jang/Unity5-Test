namespace Rhyme.Common
{
	// Low -----> High
	public enum LogSeverity
	{
		/// <summary>
		/// Almost nothing. can caused by normal interaction frequently
		/// </summary>
		Ignorable,

		/// <summary>
		/// Sometimes occurred. Easily caused by lagging
		/// </summary>
		OutOfSync,

		/// <summary>
		/// Low importance. better not happened
		/// </summary>
		Low,

		/// <summary>
		/// Medium importance.
		/// Should be alarmed and requires attention by operatives
		/// </summary>
		Medium,

		/// <summary>
		/// High importance. Should never happen
		/// </summary>
		/// Should be alarmed to developers
		High,

		/// <summary>
		/// Fatal importance. Should never happen
		/// Can corrupt whole service. Should be alarmed & requires response from ALL personnel immediately
		/// </summary>
		Fatal,
	}
}
