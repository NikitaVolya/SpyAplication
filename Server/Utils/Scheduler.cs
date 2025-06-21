
namespace Server.Utils
{
    class Scheduler
    {
        private static object _locker = new object();
        private Action _action;
        private TimeSpan _interval;
        private bool _work;

        public Scheduler(Action action, TimeSpan interval)
        {
            _action = action;
            _interval = interval;
        }

        public void Run()
        {
            _work = true;
            Task.Run(async () =>
            {
                while (_work)
                {
                    _action();
                    await Task.Delay(_interval);
                }
            });
        }

        public void Stop()
        {
            lock (_locker)
                _work = false;
        }
    }
}
