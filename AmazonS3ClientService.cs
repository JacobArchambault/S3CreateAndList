using Amazon.S3;
namespace S3CreateAndList
{
    class AmazonS3ClientService
    {
        private readonly AmazonS3Client s3Client = new AmazonS3Client();

        internal async Task<IEnumerable<string>> GetBucketNames()
        {
            return (await s3Client.ListBucketsAsync()).Buckets.Select(x => x.BucketName);
        }

        internal async Task<string> PutBucketAsync(string bucketName)
        {
            return (await s3Client.PutBucketAsync(bucketName)).HttpStatusCode.ToString();
        }


    }
}