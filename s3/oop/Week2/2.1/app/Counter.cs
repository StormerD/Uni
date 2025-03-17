using System;
namespace CounterTask {
    public class Counter {
        private int _count;
        private string _name;
        private int _limit;



        // defines Counter constructor
        public Counter(string name, int limit) {
            _name = name;
            _count = 0;
            _limit = limit;
        }

        // defines Name property
        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
            }
        }

        // defines Ticks property
        public int Ticks {
            get {
                return _count;
            }
        }

        // defines Limit property
        public int Limit {
            get {
                return _limit;
            }
        }

        // increments _count by 1
        public void Increment() {
            _count = _count + 1;
        }

        // resets _count 0
        public void Reset() {
            _count = 0;
        }
    }
}