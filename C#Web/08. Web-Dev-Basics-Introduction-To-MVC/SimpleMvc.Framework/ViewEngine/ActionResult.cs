namespace SimpleMvc.Framework.ViewEngine
{
    using SimpleMvc.Framework.Interfaces;
    using System;
	
    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifedName)
        {
            var type = GetType(viewFullQualifedName);
            this.Action = (IRenderable)Activator
                .CreateInstance(type);
        }

        public IRenderable Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }

        private Type GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null)
            {
                return type;
            }

            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                {
                    return type;
                }
            }

            return null;
        }
    }
}
