namespace S3CreateAndList.Exceptions
{
    sealed class TooManyArgumentsException : Exception
    {
        public override string Message {get  => "Too many arguments specified."
                                        + "\ndotnet_tutorials - A utility to list your Amazon S3 buckets and optionally create a new one."
                                        + "\n\nUsage: S3CreateAndList [bucket_name]"
                                        + "\n - bucket_name: A valid, globally unique bucket name."
                                        + "\n - If bucket_name isn't supplied, this utility simply lists your buckets.";}

    }
}