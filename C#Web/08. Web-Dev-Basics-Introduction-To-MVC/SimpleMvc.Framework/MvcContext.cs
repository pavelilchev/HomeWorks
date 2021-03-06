﻿namespace SimpleMvc.Framework
{
    public class MvcContext
    {
        private static MvcContext Instance;

        public MvcContext() { }

        public static MvcContext Get => Instance ?? (Instance = new MvcContext());

        public string AssemblyName { get; set; }

        public string ControllersFolder { get; set; }

        public string ControllersSufix { get; set; }

        public string ViewsFolder { get; set; }

        public string ModelsFolder { get; set; }
    }
}
