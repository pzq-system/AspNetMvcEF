using System.Web;

namespace Service
{
    public class RequestSession
    {
        public static string SESSION_USER = "SESSION_USER";

        public static void AddSessionUser(SessionUser user)
        {
            AddSessionUser(user, SESSION_USER);
        }

        public static void AddSessionUser(SessionUser user, string SessionId)
        {
            HttpContext rq = HttpContext.Current;
            rq.Session[SessionId] = user;
            rq.Session.Timeout = 5;
        }

        public static SessionUser GetSessionUserInfo => GetSessionUser();

        public static SessionUser GetSessionUser()
        {
            return GetSessionUser(SESSION_USER);
        }

        public static SessionUser GetSessionUser(string SessionId)
        {
            HttpContext rq = HttpContext.Current;
            if (rq.Session == null)
            {
                AddEmptySessionUser();
            }
            else if (rq.Session[SessionId] == null)
            {
                AddEmptySessionUser();
            }
            return (SessionUser)rq.Session[SessionId];
        }

        public static void RemoveLoginSession()
        {
            HttpContext rq = HttpContext.Current;
            rq.Session[SESSION_USER] = null;
            rq.Session.Remove(SESSION_USER);
        }

        public static void RemoveSession(string SessionId)
        {
            HttpContext rq = HttpContext.Current;
            rq.Session[SessionId] = null;
            rq.Session.Remove(SessionId);
        }

        private static void AddEmptySessionUser()
        {
            SessionUser user = new SessionUser
            {
                Useraccount = "",
                UserName = ""
            };
            AddSessionUser(user);
        }
    }
}