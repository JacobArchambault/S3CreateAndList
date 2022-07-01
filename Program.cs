using System;
using System.Threading.Tasks;

// To interact with Amazon S3.
using Amazon.S3;
using Amazon.S3.Model;

namespace S3CreateAndList
{
    class Program
    {
        // Main method
        static async Task Main(string[] args)
        {
            Console.WriteLine("dotnet_tutorials - A utility to list your Amazon S3 buckets and optionally create a new one." +
                  "\n\nUsage: S3CreateAndList [bucket_name]" +
                  "\n - bucket_name: A valid, globally unique bucket name." +
                  "\n - If bucket_name isn't supplied, this utility simply lists your buckets.");
            if (args.Length > 1)
            {
                Console.WriteLine("\nToo many arguments specified.");
                Environment.Exit(1);
            }
            if (args.Length == 0)
            {
                Console.WriteLine("\nNo arguments specified. Will simply list your Amazon S3 buckets." + "\nIf you wish to create a bucket, supply a valid, globally unique bucket name.");
            }
            var s3Client = new AmazonS3Client();
            if (args.Length == 1)
            {
                await TryPutBucket(args, s3Client);
            }
            await ListBuckets(s3Client);
        }

        private static async Task ListBuckets(AmazonS3Client s3Client)
        {
            Console.WriteLine("\nGetting a list of your buckets...");
            var bucketNames = (await s3Client.ListBucketsAsync()).Buckets.Select(x => x.BucketName);
            Console.WriteLine($"Number of buckets: {bucketNames.Count()}");
            foreach (var b in bucketNames)
            {
                Console.WriteLine(b);
            }
        }

        private static async Task TryPutBucket(string[] args, AmazonS3Client s3Client)
        {
            try
            {
                Console.WriteLine($"\nCreating bucket {args[0]}...");
                Console.WriteLine($"Result: {(await s3Client.PutBucketAsync(args[0])).HttpStatusCode.ToString()}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Caught exception when creating a bucket:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
