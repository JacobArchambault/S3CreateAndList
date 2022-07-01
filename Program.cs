namespace S3CreateAndList
{
    class Program
    {
        // Main method
        static async Task Main(string[] args)
        {
            try
            {
                if (args.Length > 1)
                {
                    throw new TooManyArgumentsException();
                }
                var s3Client = new ConsoleS3Client();
                if (args.Length == 1)
                {
                    await s3Client.PrintPutResponse(args[0]);
                }
                else
                {
                    Console.WriteLine("\nNo arguments specified. Will simply list your Amazon S3 buckets."
                                       + "\nIf you wish to create a bucket, supply a valid, globally unique bucket name.");

                }
                await s3Client.ListBuckets();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
