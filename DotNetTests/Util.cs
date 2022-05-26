namespace DotNetTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Util
    {
        /// <summary>
        /// ログオンしているユーザー名を取得.
        /// </summary>
        /// <returns>ユーザー名.</returns>
        public static string GetCurrentName()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }
    }
}
