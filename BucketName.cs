namespace S3CreateAndList
{
    static class BucketName
    {
        // 
        // Method to parse the command line.
        internal static Boolean Get(string[] args, out String bucketName)
        {
            Boolean retval = false;
            bucketName = String.Empty;
            if (args.Length == 0)
            {
                Console.WriteLine("\nNo arguments specified. Will simply list your Amazon S3 buckets." +
                  "\nIf you wish to create a bucket, supply a valid, globally unique bucket name.");
                bucketName = String.Empty;
                retval = false;
            }
            else if (args.Length == 1)
            {
                bucketName = args[0];
                retval = true;
            }
            return retval;
        }


    }
}
