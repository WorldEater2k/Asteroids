using System.Collections.Generic;

namespace Asteroids
{
    internal static class Executor
    {
        private static readonly List<IExecute> _executeList = new List<IExecute>();

        public static void AddExecuteItem(IExecute item)
        {
            _executeList.Add(item);
        }
        public static void RemoveExecuteItem(IExecute item)
        {
            _executeList.Remove(item);
        }

        public static void ExecuteAll()
        {
            foreach (var item in _executeList)
                item.Execute();
        }

        public static void RemoveAll()
        {
            foreach (var item in _executeList)
                RemoveExecuteItem(item);
        }
    }
}
