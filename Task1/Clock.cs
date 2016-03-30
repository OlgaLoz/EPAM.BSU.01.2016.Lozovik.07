using System;
using System.Threading;

namespace Task1
{
    #region NewMessageEventArgs
    public sealed class NewMessageEventArgs : EventArgs
    {       
        private readonly string text;
        private readonly int time;

        public string Text => text;
        public int Time => time;

        public NewMessageEventArgs(string text, int time)
        {
            this.text = text;
            this.time = time;
        }
    }
    #endregion

    #region Timer
    public class Timer
    {
        public event EventHandler<NewMessageEventArgs> TimerTick= delegate {};

        protected virtual void OnTimerTick(NewMessageEventArgs e)
        {
            EventHandler<NewMessageEventArgs> temp = TimerTick;
            temp?.Invoke(this, e);
        }

        public void SimulateTimerTick(string text,int time)
        {
            Thread.Sleep(time * 1000);
            OnTimerTick(new NewMessageEventArgs(text, time));
        }
    }
    #endregion
}
