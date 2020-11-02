namespace Platform.Services
{
    public static class TypeBroker
    {
        // private static IResponseFormatter formatter = new TextResponseFormatter();
        private static IResponseFormatter formatter = new HtmlResponseFormatter();

        //notice that this is a rather drastic shorthand for the get block of a property
        public static IResponseFormatter Formatter => formatter;
    }
}