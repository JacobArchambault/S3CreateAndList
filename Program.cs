using S3CreateAndList.Exceptions;
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
                var s3Client = new VerboseS3Client();
                Console.WriteLine(args.Length == 1 
                                    ? await s3Client.PutBucketAsync(args[0]) 
                                    : "No arguments specified. Will simply list your Amazon S3 buckets."
                                      + "\nIf you wish to create a bucket, supply a valid, globally unique bucket name.");
                Console.WriteLine();
                Console.WriteLine(await s3Client.ListBucketsAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
