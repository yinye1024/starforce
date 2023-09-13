using System;

namespace GameMain.Base
{
    public static class ErrorUtils
    {
        public static void ThrowBsException(string errorMsg) {
            throw new BsException(errorMsg);
        }
        
        public static void ThrowBsException(string errorMsg,Exception oriException) {
            throw new BsException(errorMsg,oriException);
        }

        public static void SafeRun(Func<object> func)
        {
            try
            {
                func();
            }
            catch (BsException e)
            {
                UnityEngine.Debug.LogError("Caught custom BsException: " + e.Message);
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError("Caught generic exception: " + e.Message);
            }
        }

    }
    public class BsException : Exception
    {
        public BsException(string message) : base(message) { }
        public BsException(string message, Exception inner) : base(message, inner) { }
    }

}