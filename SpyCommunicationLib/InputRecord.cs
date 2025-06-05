using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpyCommunicationLib
{
    public class InputRecord
    {
        private List<int> _inputs = new List<int>();
        private bool _working = false;
        private Thread _inputThread;
        private readonly object _lock = new object();

        public bool IsWorking => _working;

        public void Run()
        {
            if (_working) return;

            _working = true;
            _inputThread = new Thread(CaptureInputs);
            _inputThread.IsBackground = true;
            _inputThread.Start();
        }

        public void Stop()
        {
            _working = false;
            _inputThread?.Join();
        }

        public IEnumerator<int> GetInputs()
        {
            lock (_lock)
            {
                return new List<int>(_inputs).GetEnumerator();
            }
        }

        public void ClearInputs()
        {
            lock (_lock)
            {
                _inputs.Clear();
            }
        }

        private void CaptureInputs()
        {
            while (_working)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true);
                    lock (_lock)
                    {
                        _inputs.Add((int)key.Key);
                    }
                }
                Thread.Sleep(10); // зменшує навантаження на CPU
            }
        }
    }
}
