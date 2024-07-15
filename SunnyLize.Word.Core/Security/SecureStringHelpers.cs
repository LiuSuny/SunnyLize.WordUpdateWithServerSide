
using System;
using System.Runtime.InteropServices;
using System.Security;
namespace SunnyLize.Word.Core
{
    /// <summary>
    /// Helper for the <see cref="SecureString"/> class
    /// </summary>
    public static class SecureStringHelpers
    {
        /// <summary>
        /// Unsecure a <see cref="SecureString"/> to plain text(password)
        /// </summary>
        /// <param name="secureString">the secure string</param>
        /// <returns></returns>
        public static string UnSecure(this SecureString secureString)
        {
            //Make sure we have a secure string
            if (secureString == null)
                return string.Empty;

            //Get a pointer for an unsecure string in memory
            var UnManagedString = IntPtr.Zero;

            try
            {
                //Unsecure the password
                UnManagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);

                return Marshal.PtrToStringUni(UnManagedString);
            }
            finally
            {
                //way of cleaning up any memory allocation
                Marshal.ZeroFreeGlobalAllocUnicode(UnManagedString);
            }
        }
    }
}
