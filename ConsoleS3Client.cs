using Amazon.S3;

namespace S3CreateAndList
{
    class ConsoleS3Client
    {
        private readonly AmazonS3Client s3Client = new AmazonS3Client();
        internal async Task ListBuckets()
        {
            Console.WriteLine("\nGetting a list of your buckets...");
            var bucketNames = await GetBucketNames();
            Console.WriteLine($"Number of buckets: {bucketNames.Count()}");
            foreach (var b in bucketNames)
            {
                Console.WriteLine(b);
            }
        }

        private async Task<IEnumerable<string>> GetBucketNames()
        {
            return (await s3Client.ListBucketsAsync()).Buckets.Select(x => x.BucketName);
        }

        internal async Task PutBucketAsync(string bucketName)
        {
            Console.WriteLine($"\nCreating bucket {bucketName}...");
            Console.WriteLine($"Result: {await GetPutResponse(bucketName)}");
        }

        private async Task<string> GetPutResponse(string bucketName)
        {
            return (await s3Client.PutBucketAsync(bucketName)).HttpStatusCode.ToString();
        }
    }
}