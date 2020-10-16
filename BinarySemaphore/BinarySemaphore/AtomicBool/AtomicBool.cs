using System;
using System.Threading;

namespace BinarySemaphore
{
    public class AtomicBool: IAtomicBool
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

        public bool SetTrue()
        {
            return SetValue(true, false);
        }
        
        public bool SetFalse()
        {
            return SetValue(false, true);
        }
        private bool SetValue(bool setValue, bool existValue)
        {
            int comparand = existValue ? TrueValue : FalseValue;
            int result = Interlocked.CompareExchange(ref _state, (setValue ? TrueValue : FalseValue), comparand);
            bool preResult = result == TrueValue;
            return preResult == existValue;
        }
    }
}