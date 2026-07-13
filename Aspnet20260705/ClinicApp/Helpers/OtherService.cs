using ClinicApp.Models;

namespace ClinicApp.Helpers {
    public class OtherService {

        private static int Count;

        public OtherService()
        {
            Count++;
            Console.WriteLine($"OtherService: {Count}");
        }
    }
}
