using System;
using System.Threading;

namespace BinarySemaphore
{
    public class AtomicBool
    {
        private const int TrueValue = 1;
        private const int FalseValue = 0;
        private int _state = FalseValue;
        
        public AtomicBool(bool value)
        {
            Value = value;
        }

        public bool Value
        {
            get => _state == TrueValue;
            set => _state = value ? TrueValue : FalseValue;
        }

        public void SetTrue()
        {
            SetValue(true, Value);
        }
        
        public void SetFalse()
        {
            SetValue(false, Value);
        }

        private void SetValue(bool setValue, bool existValue)
        {
            int comparand = existValue ? TrueValue : FalseValue;
            Interlocked.CompareExchange(ref _state, (setValue ? TrueValue : FalseValue), comparand);
        }
    }
}