using System.Text;
namespace S3CreateAndList
{
    class VerboseS3Client
    {
        AmazonS3ClientService amazonS3ClientService  = new(); 
        internal async Task<string> ListBuckets()
        {
            StringBuilder stringBuilder = new();
            
            stringBuilder.AppendLine("Getting a list of your buckets...");
            var bucketNames = await amazonS3ClientService.GetBucketNames();
            stringBuilder.AppendLine($"Number of buckets: {bucketNames.Count()}");
            foreach (var b in bucketNames)
            {
                stringBuilder.AppendLine(b);
            }
            return stringBuilder.ToString();
        }


        internal async Task<string> PutBucketAsync(string bucketName)
        {
            return $"Creating bucket {bucketName}..."
                   + $"\nResult: {await amazonS3ClientService.PutBucketAsync(bucketName)}";
        }
    }
}