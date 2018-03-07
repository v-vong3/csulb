namespace patterns_demo.creational.factoryMethod.implementation
{
    public static class DataStoreTypes
    {
        // If planning to use these members in a switch-case statement,
        // then these members need to have the const modifier

        public const string NoSql = nameof(NoSql); // Use of nameof operator to align member name & value

        public const string Default = nameof(Default);

        public const string File = nameof(File);
    }
}