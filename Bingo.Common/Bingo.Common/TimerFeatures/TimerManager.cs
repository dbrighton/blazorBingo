using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bingo.Common.TimerFeatures
{
    public class TimerManager
    {
        private Timer _timer;
        private AutoResetEvent _autoResetEvent;
        private Action _action;

        public DateTime TimeStarted { get; set; }

        public TimerManager(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 1000, 2000);

        }

        private void Execute(object state)
        {
            _action();

            if ((DateTime.Now - TimeStarted).Seconds > 60)
            {
                _timer.Dispose();
            }
        }
    }
}
