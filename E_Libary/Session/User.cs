using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Libary.Session
{
    public static class List<UserLogin>
    { }
    public static class UserLogin
    {
        public static string username { get; set; }
        public static string pass { get; set; }
        public static string code { get; set; }
    }
}