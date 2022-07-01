using Amazon.S3;

namespace S3CreateAndList
{
    class ConsoleS3Client
    {
        private readonly AmazonS3Client s3Client = new AmazonS3Client();
        internal async Task ListBuckets()
        {
            Console.WriteLine("\nGetting a list of your buckets...");
            var bucketNames = (await s3Client.ListBucketsAsync()).Buckets.Select(x => x.BucketName);
            Console.WriteLine($"Number of buckets: {bucketNames.Count()}");
            foreach (var b in bucketNames)
            {
                Console.WriteLine(b);
            }
        }

        internal async Task PutBucketAsync(string bucketName)
        {
            Console.WriteLine($"\nCreating bucket {bucketName}...");
            Console.WriteLine($"Result: {(await s3Client.PutBucketAsync(bucketName)).HttpStatusCode.ToString()}");
        }

    }
}