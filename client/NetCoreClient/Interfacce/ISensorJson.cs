namespace NetCoreClient.Sensors
{
    interface ISensorJson
    {
        string ToJson();
        string GetSlug();
    }
}
