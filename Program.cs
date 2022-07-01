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
            // Before running this app:
            // - Credentials must be specified in an AWS profile. If you use a profile other than
            //   the [default] profile, also set the AWS_PROFILE environment variable.
            // - An AWS Region must be specified either in the [default] profile
            //   or by setting the AWS_REGION environment variable.

            // Create an S3 client object.
            var s3Client = new AmazonS3Client();

            // Parse the command line arguments for the bucket name.
            if (BucketName.Get(args, out String bucketName))
            {
                // If a bucket name was supplied, create the bucket.
                // Call the API method directly
                try
                {
                    Console.WriteLine($"\nCreating bucket {bucketName}...");
                    Console.WriteLine($"Result: {(await s3Client.PutBucketAsync(bucketName)).HttpStatusCode.ToString()}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Caught exception when creating a bucket:");
                    Console.WriteLine(e.Message);
                }
            }

            // List the buckets owned by the user.
            // Call a class method that calls the API method.
            Console.WriteLine("\nGetting a list of your buckets...");
            var listResponse = await s3Client.ListBucketsAsync();
            Console.WriteLine($"Number of buckets: {listResponse.Buckets.Count}");
            foreach (S3Bucket b in listResponse.Buckets)
            {
                Console.WriteLine(b.BucketName);
            }
        }

    }
}
