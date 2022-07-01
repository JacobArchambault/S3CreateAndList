namespace S3CreateAndList
{
    class ConsoleS3Client
    {
        AmazonS3ClientService amazonS3ClientService  = new(); 
        internal async Task ListBuckets()
        {
            Console.WriteLine("\nGetting a list of your buckets...");
            var bucketNames = await amazonS3ClientService.GetBucketNames();
            Console.WriteLine($"Number of buckets: {bucketNames.Count()}");
            foreach (var b in bucketNames)
            {
                Console.WriteLine(b);
            }
        }


        internal async Task PrintPutResponse(string bucketName)
        {
            Console.WriteLine($"\nCreating bucket {bucketName}...");
            Console.WriteLine($"Result: {await amazonS3ClientService.PutBucketAsync(bucketName)}");
        }
    }
}