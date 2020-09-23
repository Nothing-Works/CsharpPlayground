using System;

namespace CsharpPlayground.Delegate
{
    public class PhotoProcessor
    {
        public delegate void FilterHandler(string path);

        private Action<string> _internalFilter;

        public PhotoProcessor()
        {
            _internalFilter = FilterA;
            _internalFilter += FilterB;
            _internalFilter += FilterC;
        }

        public void Process(Action<string> filter)
        {
            //process.
            Console.WriteLine("Processing");

            //apply filter.
            Console.WriteLine("Applying filter/filters");

            _internalFilter += filter;
            _internalFilter("Test");
        }

        private void FilterB(string path)
        {
            Console.WriteLine("filter b");
        }

        private void FilterC(string path)
        {
            Console.WriteLine("filter c");
        }

        private void FilterA(string path)
        {
            Console.WriteLine("filter a");
        }
    }
}