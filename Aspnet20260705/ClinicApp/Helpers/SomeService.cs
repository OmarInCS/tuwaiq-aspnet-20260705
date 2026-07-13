using ClinicApp.Models;

namespace ClinicApp.Helpers {
    public class SomeService {

        private static int Count;

        public SomeService(OtherService otherService)
        {
            Count++;
            Console.WriteLine($"SomeService: {Count}");
        }
    }
}
