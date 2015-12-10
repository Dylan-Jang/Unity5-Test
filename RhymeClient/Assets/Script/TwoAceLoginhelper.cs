//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;

//using Newtonsoft.Json;

//using Rhyme.Bot.Common;
//using Rhyme.Common;

//namespace Rhyme.Bot.Service.Platform
//{
//	class TwoAceLoginHelper
//	{
//		private const string AuthorizationKey = @"c3eca13b-4ecb-cf36-3728-3c15c02c4696";

//		private const string SessionCreateURL = @"/two-ace-client/api/users/session/create";
//		private const string LoginUserTokenURL = @"/two-ace-client/api/users/token";
//		private const string SessionDeleteURL = @"/two-ace-client/api/users/session/delete";

//		private static Uri GetBaseAddress(string env)
//		{
//			switch (env)
//			{
//				case "dev":
//				case "test":
//					return new Uri(@"http://106.241.31.236:47002");
//				case "uat":
//					return new Uri(@"http://123.56.111.7:80");
//				case "live":
//					throw new InvalidOperationException("Not support LIVE !");
//				default:
//					return new Uri(@"http://106.241.31.236:47002");
//			}
//		}

//		public static async Task<PlatformSession> GetPlatformSession(string env, string loginId, string password)
//		{
//			var baseAddress = GetBaseAddress(env);

//			try
//			{
//				var handler = new HttpClientHandler { UseCookies = false };
//				var session = new HttpClient(handler) { BaseAddress = baseAddress };

//				// This needs to go over as a dict.
//				var formContent = new Dictionary<string, string>
//				{
//					{"username", loginId},
//					{"password", password}
//				};

//				// Login to 2Ace Auth Server and Convert the dict to form encoded content.
//				session.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthorizationKey);
//				var result = await session.PostAsync(SessionCreateURL, new FormUrlEncodedContent(formContent));

//				// Variable to hold the authentication cookie.
//				var setCookie = string.Empty;

//				// Get the authentication cookie from the login request.
//				foreach (var header in result.Headers.Where(header => header.Key == "Set-Cookie"))
//				{
//					foreach (var value in header.Value)
//					{
//						setCookie = value;
//						break; // Stop after finding something..
//					}
//					break; // We only care about the first match.
//				}

//				// Uh oh, something bad happened...
//				if (setCookie.Trim().Equals(""))
//				{
//					throw new Exception("No authentication cookie from login call!");
//				}

//				// Make sure the accept headers are empty.
//				session.DefaultRequestHeaders.Accept.Clear();
//				session.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//				return new PlatformSession
//				{
//					Client = session,
//					CookieString = setCookie,
//					Env = env,
//					LoginId = loginId,
//				};
//			}
//			catch (Exception ex)
//			{
//				//Logger.Log(LogInfo.Error, new
//				//{
//				//	Event = "get_platform_session_exception_by_twoace",
//				//	BaseAddress = baseAddress == null ? "(null)" : baseAddress.ToString(),
//				//	Env = env,
//				//	LoginId = loginId,
//				//	ExceptionMessage = ex.Message,
//				//	//ExceptionStackTrace = ex.StackTrace
//				//});

//				return null;
//			}
//		}

//		private static async Task<HttpResponseMessage> GetHttpResponseMessage(PlatformSession session, HttpMethod method, string restUrl)
//		{
//			var message = new HttpRequestMessage(method, restUrl);
//			message.Headers.Add("Cookie", session.CookieString);

//			// Get a list of processes.
//			var result = await session.Client.SendAsync(message);

//			// Make sure a success code was returned.
//			return result.EnsureSuccessStatusCode();
//		}

//		public static async Task<PlatformToken> GetAuthToken(PlatformSession session)
//		{
//			try
//			{
//				var result = await GetHttpResponseMessage(session, HttpMethod.Get, LoginUserTokenURL);

//				var resultContent = await result.Content.ReadAsStringAsync();
//				return JsonConvert.DeserializeObject<PlatformToken>(resultContent);
//			}
//			catch (Exception ex)
//			{
//				Logger.Log(LogInfo.Error, new
//				{
//					Event = "acquire_token_failed_by_twoace",
//					PlatformSession = session,
//					ExceptionMessage = ex.Message,
//					//ExceptionStackTrace = ex.StackTrace
//				});

//				return null;
//			}
//		}

//		public static async Task PlatformLogOut(PlatformSession session)
//		{
//			try
//			{
//				await GetHttpResponseMessage(session, HttpMethod.Post, SessionDeleteURL);
//			}
//			catch (Exception ex)
//			{
//				Logger.Log(LogInfo.Error, new
//				{
//					Event = "platform_logout_exception_by_twoace",
//					PlatformSession = session,
//					ExceptionMessage = ex.Message,
//					//ExceptionStackTrace = ex.StackTrace
//				});
//			}
//		}
//	}
//}
