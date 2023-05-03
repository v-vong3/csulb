public static class Program
{
    public void Main(string[] args)
    {
        var archiver = new Archiver();

        archiver.PdfFilesArchiveLocation = "S:\\archives\\docs";

        if(archiver.PdfFilesArchiveLocation.EndsWith("\\"))
        {
            throw new System.Exception("Cannot have trailing slash");
        }

        archiver.PdfFilesLocation = "C:\\docs";

        if(archiver.PdfFilesLocation.EndsWith("\\"))
        {
            throw new System.Exception("Cannot have trailing slash");
        }

        archiver.TextFilesArchiveLocation = "L:\\textLogs";

        if(archiver.TextFilesArchiveLocation.EndsWith("\\"))
        {
            throw new System.Exception("Cannot have trailing slash");
        }

        archiver.TextFilesLocation = "C:\\textLogs";

        if(archiver.TextFilesLocation.EndsWith("\\"))
        {
            throw new System.Exception("Cannot have trailing slash");
        }

        if(!System.String.IsNullOrWhiteSpace(archiver.TextFilesArchiveLocation))
        {
            archiver.TryBoth = true;
        }



        archiver.ArchivePdfFilesToArchiveLocation();
        

    }
}