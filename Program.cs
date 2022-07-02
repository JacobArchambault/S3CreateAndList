using S3CreateAndList.Exceptions;
using System.Text;
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
                Console.WriteLine(await PutThenListBuckets(args, s3Client));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static async Task<string> PutThenListBuckets(string[] args, VerboseS3Client s3Client)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine(args.Length == 1
                                                ? await s3Client.PutBucketAsync(args[0])
                                                : "No arguments specified. Will simply list your Amazon S3 buckets."
                                                  + "\nIf you wish to create a bucket, supply a valid, globally unique bucket name.");
            stringBuilder.AppendLine();
            stringBuilder.AppendLine(await s3Client.ListBucketsAsync());
            return stringBuilder.ToString();
        }
    }
}
