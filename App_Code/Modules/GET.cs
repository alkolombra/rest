using System;
using System.Web;
using REST;

namespace Modules
{
    public class GET : RestEngine
    {
        public GET()
        {
            try
            {
                Type thisType = this.GetType();
                System.Reflection.MethodInfo theMethod = thisType.GetMethod("test");
                Log.Write(theMethod.Invoke(this, null).ToString());
            }
            catch (Exception)
            {
                
            }
        }
    }
}