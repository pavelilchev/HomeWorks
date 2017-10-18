namespace SimpleMvc.Framework
{
	using System;
    using WebServer;
	
    public static class MvcEngine
    {
        public static void Run(WebServer server)
        {
            RegisterAssemblyName();
            RegisterControllersData();
            RegisterViewsData();
            RegisterModelsData();

            try
            {
                server.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
