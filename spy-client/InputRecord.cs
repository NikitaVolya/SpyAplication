namespace SpyCommunicationLib
{
    public class InputRecord
    {
        private List<int> _inputs = new List<int>();
        private bool _working = false;
        private Thread _inputThread;
        private readonly object _lock = new object();

        // Indicates whether the input capturing thread is currently running
        public bool IsWorking => _working;

        // Starts the background thread to capture key inputs if it's not already running
        public void Run()
        {
            if (_working) return;

            _working = true;
            _inputThread = new Thread(CaptureInputs);
            _inputThread.IsBackground = true;
            _inputThread.Start();
        }

        // Stops the input capturing thread and waits for it to finish
        public void Stop()
        {
            _working = false;
            _inputThread?.Join();
        }

        // Returns a thread-safe copy of the captured input keys as integers
        public IEnumerable<int> GetInputs()
        {
            lock (_lock)
            {
                return new List<int>(_inputs);
            }
        }

        // Clears the list of captured input keys in a thread-safe manner
        public void ClearInputs()
        {
            lock (_lock)
            {
                _inputs.Clear();
            }
        }

        // Continuously captures unique key presses and stores them while the thread is active
        private void CaptureInputs()
        {
            HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey>();

            while (_working)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true).Key;

                    lock (_lock)
                    {
                        if (!pressedKeys.Contains(key))
                        {
                            _inputs.Add((int)key);
                            pressedKeys.Add(key);
                        }
                    }
                }
                else
                {
                    pressedKeys.Clear();
                }

                Thread.Sleep(10);
            }
        }
    }
}
