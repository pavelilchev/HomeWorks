namespace SimpleMvc.App
{
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        static void Main(string[] args)
        {
            var server = new WebServer(8000, new ControllerRouter());

            MvcEngine.Run(server);
        }
    }
}
