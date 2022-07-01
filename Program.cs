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
                    throw new Exception("Too many arguments specified."
                                        + "\ndotnet_tutorials - A utility to list your Amazon S3 buckets and optionally create a new one."
                                        + "\n\nUsage: S3CreateAndList [bucket_name]"
                                        + "\n - bucket_name: A valid, globally unique bucket name."
                                        + "\n - If bucket_name isn't supplied, this utility simply lists your buckets.");
                }
                var s3Client = new ConsoleS3Client();
                if (args.Length == 1)
                {
                    await s3Client.PutBucketAsync(args[0]);
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
